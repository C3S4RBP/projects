using IntegrationNagiosLibrary.Nagios;
using System;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace integrationNagiosService
{
    public partial class integrationNagiosService : ServiceBase
    {
        Timer timer = new Timer();
        String hourSync = "";
        public integrationNagiosService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var lapso = ConfigurationManager.AppSettings["lapso"];
            WriteToFile("Service fue inciado a las " + DateTime.Now);
            WriteToFile("Con un lapso de  " + lapso);
            hourSync = ConfigurationManager.AppSettings["hourSync"];
            WriteToFile("Rango de horas " + hourSync);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = Convert.ToDouble(lapso); //number in milisecinds   30000
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToFile("Service fue detenido a las " + DateTime.Now);
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            var currentHour = DateTime.Now.ToString("HH");
            if (currentHour == hourSync)//02
            {
                WriteToFile("Start nagios process " + DateTime.Now);
                nagiosCore ngCore = new nagiosCore();
                ngCore.integrationProcess();
            }
            else
            {
                WriteToFile("Fuera del horario " + DateTime.Now);
            }
           
        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_Nagios.log";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }

        

    }
}
