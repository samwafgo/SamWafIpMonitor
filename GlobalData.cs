using SamWafIpMonitor.domain; 

namespace SamWafIpMonitor
{
    internal class GlobalData
    {
        public static List<NetBeanLog> logList = new List<NetBeanLog>();
        public static Queue<NetBeanLog> queueNetBeanLogs = new Queue<NetBeanLog>();
    }
}
