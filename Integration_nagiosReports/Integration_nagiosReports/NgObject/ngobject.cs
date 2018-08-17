using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_nagiosReports
{
    public class Result
    {
        public long query_time { get; set; }
        public string cgi { get; set; }
        public string user { get; set; }
        public string query { get; set; }
        public string query_status { get; set; }
        public long program_start { get; set; }
        public long last_data_update { get; set; }
        public int type_code { get; set; }
        public string type_text { get; set; }
        public string message { get; set; }
    }

    public class Selectors
    {
        public int availabilityobjecttype { get; set; }
        public long starttime { get; set; }
        public long endtime { get; set; }
        public string hostname { get; set; }
        public string servicedescription { get; set; }
        public bool assumeinitialstate { get; set; }
        public bool assumestateretention { get; set; }
        public bool assumestateduringnagiosdowntime { get; set; }
    }

    public class Service
    {
        public string host_name { get; set; }
        public string description { get; set; }
        public int time_ok { get; set; }
        public int time_warning { get; set; }
        public int time_critical { get; set; }
        public int time_unknown { get; set; }
        public int scheduled_time_ok { get; set; }
        public int scheduled_time_warning { get; set; }
        public int scheduled_time_critical { get; set; }
        public int scheduled_time_unknown { get; set; }
        public int time_indeterminate_nodata { get; set; }
        public int time_indeterminate_notrunning { get; set; }
    }

    public class Data
    {
        public Selectors selectors { get; set; }
        public Service service { get; set; }
    }

    public class nagiosObject
    {
        public int format_version { get; set; }
        public Result result { get; set; }
        public Data data { get; set; }
    }
}






