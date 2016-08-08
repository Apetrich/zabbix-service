using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Constants
{
    public static class Constant
    {
        //Template App Zabbix Agent
        public static readonly string AGENT_PING = "Agent ping";
        public static readonly string HOST_NAME_OF_AGENTD_RUNNING = "Host name of zabbix_agentd running";

        //Template OS Linux
        public static readonly string AVAILABLE_MEMORY = "Available memory";
        public static readonly string CPU_SYSTEM_TIME = "CPU system time";
        public static readonly string HOST_NAME_OF_LINUX = "Host name";
        public static readonly string MAX_NUM_OF_PROCESSES = "Maximum number of processes";
        public static readonly string NUM_OF_PROCESSES = "Number of processes";
        public static readonly string NUM_OF_RUNNING_PROCESSES = "Number of running processes";
        public static readonly string SYSTEM_INFO = "System information";
        public static readonly string TOTAL_MEMORY = "Total memory";
        public static readonly string USED_MEMORY = "Used Memory";

        //outcomming
        public static readonly string BYTES_TX_PORT = "Bytes Tx port $";
        //incoming
        public static readonly string BYTES_RX_PORT = "Bytes Rx port $";

        public static readonly string TEMPERATURE = "Temperature";

    }
}
