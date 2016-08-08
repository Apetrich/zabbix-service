using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Models
{
    public class ItemModel
    {
        public string id { get; set; }
        public string itemname { get; set; }
        public string jsonrpc { get; set; }
        public IEnumerable<ItemResult> result { get; set; }
        public DateTime StoreDate { get; set; }
    }
    public class ItemResult
    {
        public string itemid { get; set; }
        public string type { get; set; }
        public string snmp_community { get; set; }
        public string snmp_oid { get; set; }
        public string hostid { get; set; }
        public string hostname { get; set; }
        public string key_ { get; set; }
        public string delay { get; set; }
        public string history { get; set; }
        public string trends { get; set; }
        public string status { get; set; }
        public string value_type { get; set; }
        public string trapper_hosts { get; set; }
        public string units { get; set; }
        public string multiplier { get; set; }
        public string delta { get; set; }
        public string snmpv3_securityname { get; set; }
        public string snmpv3_securitylevel { get; set; }
        public string snmpv3_authpassphrase { get; set; }
        public string snmpv3_privpassphrase { get; set; }
        public string formula { get; set; }
        public string error { get; set; }
        public string lastlogsize { get; set; }
        public string logtimefmt { get; set; }
        public string templateid { get; set; }
        public string valuemapid { get; set; }
        public string delay_flex { get; set; }
        public string @params { get; set; }
        public string ipmi_sensor { get; set; }
        public string data_type { get; set; }
        public string authtype { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string publickey { get; set; }
        public string privatekey { get; set; }
        public string mtime { get; set; }
        public string flags { get; set; }
        public string interfaceid { get; set; }
        public string port { get; set; }
        public string description { get; set; }
        public string inventory_link { get; set; }
        public string lifetime { get; set; }
        public string snmpv3_authprotocol { get; set; }
        public string snmpv3_privprotocol { get; set; }
        public string state { get; set; }
        public string snmpv3_contextname { get; set; }
        public string evaltype { get; set; }
        public string lastclock { get; set; }
        public string lastns { get; set; }
        public string lastvalue { get; set; }
        public string prevvalue { get; set; }
    }
}
