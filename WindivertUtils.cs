using SamWafIpMonitor.domain;
using SamWafIpMonitor.wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WindivertDotnet;
namespace SamWafIpMonitor
{
    internal class WindivertUtils
    {
        static WinDivert? divert;
        public static async Task StartInst() {
            var filter2 = Filter.Compile("tcp.DstPort == 80 ||tcp.DstPort == 443 ", WinDivertLayer.Network);
            var filter = Filter.True
    .And(f => f.Tcp.DstPort == 80)
    .And(f => f.Tcp.Ack == true);

            divert = new WinDivert(filter2, WinDivertLayer.Network);
            using var packet = new WinDivertPacket();
            using var addr = new WinDivertAddress();

            while (true)
            { 
                // 读包
                await divert.RecvAsync(packet, addr);

                ProcessPacket(packet, addr);

                // 修改后发出
                await divert.SendAsync(packet, addr);
            }
        }
        public static void StopInst() { 
        
        }

        static unsafe void ProcessPacket(WinDivertPacket packet, WinDivertAddress addr)
        {
            // 解包
            var result = packet.GetParseResult();

            Console.WriteLine("\r\n");
            if (result.DataLength > 0)
            {
                NetBeanLog netBeanLog = new NetBeanLog();
                // 改包
                //result.TcpHeader->DstPort = 443;
                byte* byteArray = result.Data;

                String lastData = Encoding.ASCII.GetString(byteArray, result.DataLength);

                Console.WriteLine($"请求：{result.Protocol} " +
                 //$"{lastData} " +
                 $" {result.IPV4Header->SrcAddr}-> {result.IPV4Header->DstAddr}  " +
                 $" {result.TcpHeader->SrcPort} " +
                 $" {result.TcpHeader->DstPort} ");
                netBeanLog.nowTime = DateTime.Now;
                netBeanLog.srcIp = result.IPV4Header->SrcAddr.ToString();
                netBeanLog.dstIp = result.IPV4Header->DstAddr.ToString();
                netBeanLog.dstPort = result.TcpHeader->DstPort.ToString();

                var match = Regex.Match(lastData, @"Host:\s*(?<host>[^\s]+)\s*");
                if (match.Success)
                {
                    var domain = match.Groups["host"].Value;
                    Console.WriteLine("Domain: " + domain);

                    // 获取请求地址
                    var pathMatch = Regex.Match(lastData, @"GET\s+(?<path>[^\s]+)\s+HTTP");
                    if (pathMatch.Success)
                    {
                        var path = pathMatch.Groups["path"].Value;
                        Console.WriteLine("Request path: " + path);
                    }
                }
                var port = result.TcpHeader->SrcPort;
                int pid = GetPidFromPort(port);
                if (pid != -1)
                {
                    netBeanLog.pid = pid.ToString();
                    string windowProgramName = WindowTitle.GetFileNameFromPid(pid);
                    string windowTitle = WindowTitle.GetWindowTitle(pid);
                    Console.WriteLine($" 来源端口: {port} \r\n 来源Pid: {pid} \r\n 标题: {windowTitle} \r\n 程序位置:{windowProgramName}");
                    netBeanLog.path = windowProgramName;
                    netBeanLog.title = windowTitle;
                }
                else
                {
                    Console.WriteLine($"No process is using port {port}");
                }
                //GlobalData.logList.Add( netBeanLog );
                GlobalData.queueNetBeanLogs.Enqueue( netBeanLog );

                // 重算checksums
                packet.CalcChecksums(addr);
            }
        }
        static int GetPidFromPort(ushort srcPort)
        {
            TcpTable tcpTable = ManagedIpHelper.GetExtendedTcpTable(false);

            foreach (var item in tcpTable)
            {
                if (item.LocalEndPoint.Port == srcPort)
                {

                    return item.ProcessId;
                }
            }


            return -1;
        }
    }
}
