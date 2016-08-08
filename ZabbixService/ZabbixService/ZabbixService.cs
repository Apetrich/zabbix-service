using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ZabbixService
{
    public partial class ZabbixService : ServiceBase
    {
        private Int32 Interval;
        private DateTime LastRequestTime;
        public ZabbixService()
        {
            this.Interval = 15;
            this.LastRequestTime = DateTime.Now;

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //var interval = ConfigurationManager.AppSettings["interval"];
            //var lastRequestTime = ConfigurationManager.AppSettings["last-request-time"];



        }

        protected override void OnStop()
        {
        }
    }
}
