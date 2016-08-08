using System;
using System.Collections.Generic;

namespace ZabbixApi.Models
{
    public class HistoryModel
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public List<HistoryResult> result { get; set; }
        public DateTime storeDate { get; set; }
        public string itemType { get; set; }
    }

    public class HistoryResult
    {
        public string hostid { get; set; }
        public string hostname { get; set; }
        public string itemid { get; set; }
        public string clock { get; set; }
        public string value { get; set; }
        public string ns { get; set; }
    }
}
