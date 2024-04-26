using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SamWafIpMonitor.domain
{
    internal class NetBeanLog
    {
        public DateTime nowTime;
        public string pid;
        public string title;
        public string path;
        public string srcIp;
        public string dstIp;
        public string dstPort;

        public NetBeanLog() { 
        }
        public NetBeanLog(DateTime nowTime, string pid, string title, string path, string srcIp, string dstIp, string dstPort)
        {
            this.nowTime = nowTime;
            this.pid = pid;
            this.title = title;
            this.path = path;
            this.srcIp = srcIp;
            this.dstIp = dstIp;
            this.dstPort = dstPort;
        }
    }
}
