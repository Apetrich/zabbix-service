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
using System.Timers;
using System.IO;

namespace ZabbixService
{
    public partial class ZabbixService : ServiceBase
    {
        private DateTime _lastRequestTime;
        private Timer _timer;
        private String _path;
        private System.Diagnostics.EventLog eventLog1;

        public ZabbixService()
        { 
            this._lastRequestTime = DateTime.Now;
            this._timer = new System.Timers.Timer();
            this._path = @"c:\temp\zabbix-service.txt";

            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {

            if (!File.Exists(_path))
            {
                File.Create(_path);
            }


            var interval = ConfigurationManager.AppSettings["interval"];

            var lastRequestTime = ConfigurationManager.AppSettings["last-request-time"];

            if (!String.IsNullOrWhiteSpace(lastRequestTime))
            {
                using (StreamWriter sw = File.AppendText(_path))
                {
                    sw.WriteLine("{0}: Continue {1}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), lastRequestTime);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(_path))
                {
                    sw.WriteLine("{0}: Service Started", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"));
                }
            }
            _timer.Interval = 3000;
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var currentTime = DateTime.Now;
            ConfigurationManager.AppSettings["last-request-time"] = _lastRequestTime.ToString();
            using (StreamWriter sw = File.AppendText(_path))
            {
                sw.WriteLine("{0}: TIMER TIKI!!!!!", ConfigurationManager.AppSettings["last-request-time"]);
            }

            _lastRequestTime = currentTime;
            
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop");
        }
    }
}
