using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Models
{
    public class HostModel
    {
        public string jsonrpc { get; set; }
        public List<HostResult> result { get; set; }
    }

    public class HostResult
    {
        public IEnumerable<string> maintenances { get; set; }
        public string hostid { get; set; }
        public string proxy_hostid { get; set; }
        public string host { get; set; }
        public string status { get; set; }
        public string disable_until { get; set; }
        public string error { get; set; }
        public string available { get; set; }
        public string errors_from { get; set; }
        public string lastaccess { get; set; }
        public string ipmi_authtype { get; set; }
        public string ipmi_privilege { get; set; }
        public string ipmi_username { get; set; }
        public string ipmi_password { get; set; }
        public string ipmi_disable_until { get; set; }
        public string ipmi_available { get; set; }
        public string snmp_disable_until { get; set; }
        public string snmp_available { get; set; }
        public string maintenanceid { get; set; }
        public string maintenance_status { get; set; }
        public string maintenance_type { get; set; }
        public string maintenance_from { get; set; }
        public string ipmi_errors_from { get; set; }
        public string snmp_errors_from { get; set; }
        public string jsoipmi_errornrpc { get; set; }
        public string snmp_error { get; set; }
        public string jmx_disable_until { get; set; }
        public string jmx_available { get; set; }
        public string jmx_errors_from { get; set; }
        public string jmx_error { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
