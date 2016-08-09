using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixApi.Models
{
    public class LogInResult
    {
        public string jsonrpc { get; set; }
        public string result { get; set; }
        public string id { get; set; }
    }
}
