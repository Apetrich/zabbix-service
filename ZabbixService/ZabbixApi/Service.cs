using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZabbixApi.Models;

namespace ZabbixApi
{
    class Service
    {
        private string _apiUrl;
        private string _authHash;
        public Service()
        {
            _apiUrl = "http://192.168.1.204/zabbix/api_jsonrpc.php";
            LogIn();
        }

        public void LogIn()
        {
            var res = SendPost(new
            {
                jsonrpc = "2.0",
                method = "user.login",
                @params = new
                {
                    user = "admin",
                    password = "zabbix"
                },
                id = 1
            });
            var resJson = JsonConvert.DeserializeObject<LogInResult>(res);
            _authHash = resJson.result;
        }

        public ItemModel GetItemByName(string value)
        {
            var tempResult = SendPost(new
            {
                jsonrpc = "2.0",
                method = "item.get",
                @params = new
                {
                    output = "extend",
                    filter = new
                    {
                        name = value
                    }
                },
                auth = _authHash,
                id = 1
            });

            var tempResultJson = JsonConvert.DeserializeObject<ItemModel>(tempResult);
            var result = new List<ItemResult>();

            foreach (var item in tempResultJson.result)
            {
                var host = SendPost(new
                {
                    jsonrpc = "2.0",
                    method = "host.get",
                    @params = new
                    {
                        output = "extend",
                        filter = new
                        {
                            hostid = item.hostid
                        }
                    },
                    auth = _authHash,
                    id = 1
                });
                var hostJson = JsonConvert.DeserializeObject<HostModel>(host);
                if (hostJson.result.Count == 0) continue;
                item.hostname = hostJson.result[0].name;
                result.Add(item);
            }

            tempResultJson.itemname = value;
            tempResultJson.result = result;
            return tempResultJson;
        }

        public HostModel GetHostByName(string value)
        {
            var tempResult = SendPost(new
            {
                jsonrpc = "2.0",
                method = "host.get",
                @params = new
                {
                    output = "extend",
                    filter = new
                    {
                        name = value
                    }
                },
                auth = _authHash,
                id = 1
            });
            var resJson = JsonConvert.DeserializeObject<HostModel>(tempResult);
            return resJson;
        }

        public string GetItemNameById(string id)
        {
            var res = SendPost(new
            {
                jsonrpc = "2.0",
                method = "item.get",
                @params = new
                {
                    output = "extend",
                    itemids = id
                },
                auth = _authHash,
                id = 1
            });
            var resJson = JsonConvert.DeserializeObject<ItemModel>(res);
            return resJson.itemname;
        }

        public HistoryModel GetHistory(string[] itemIds, string[] hostids, double from, double to)
        {
            var res = SendPost(new
            {
                jsonrpc = "2.0",
                method = "history.get",
                @params = new
                {
                    output = "extend",
                    itemids = itemIds,
                    sortfield = "clock",
                    sortorder = "DESC",
                    time_from = from,
                    time_till = to,
                    hostids = hostids

                },
                id = 1,
                auth = _authHash
            });
            var resJson = JsonConvert.DeserializeObject<HistoryModel>(res);
            return resJson;
        }

        public ItemModel GetItemByNameAndHosts(string itemName, string[] hosts)
        {
            var res = SendPost(new
            {
                jsonrpc = "2.0",
                method = "item.get",
                @params = new
                {
                    output = "extend",
                    hostids = hosts,
                    filter = new
                    {
                        name = itemName
                    }
                },
                auth = _authHash,
                id = 1
            });
            var resJson = JsonConvert.DeserializeObject<ItemModel>(res);
            return resJson;
        }

        public string SendPost(object obj)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_apiUrl);
            httpWebRequest.ContentType = "application/json-rpc";
            httpWebRequest.Method = "POST";

            var serializer = new JsonSerializer();
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                using (var tw = new JsonTextWriter(streamWriter))
                {
                    serializer.Serialize(tw, obj);
                }
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                return responseText;
            }
        }
    }
}
