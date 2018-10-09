using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_nagiosReports.NgObject
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

    public class CustomVariables
    {
    }

    public class Host
    {
        public string name { get; set; }
        public string display_name { get; set; }
        public string alias { get; set; }
        public string address { get; set; }
        public List<string> parent_hosts { get; set; }
        public List<object> child_hosts { get; set; }
        public List<string> services { get; set; }
        public string check_command { get; set; }
        public int initial_state { get; set; }
        public double check_interval { get; set; }
        public double retry_interval { get; set; }
        public int max_attempts { get; set; }
        public string event_handler { get; set; }
        public List<string> contact_groups { get; set; }
        public List<string> contacts { get; set; }
        public double notification_interval { get; set; }
        public double first_notification_delay { get; set; }
        public int notifications_options { get; set; }
        public string notification_period { get; set; }
        public string check_period { get; set; }
        public bool flap_detection_enabled { get; set; }
        public double low_flap_threshold { get; set; }
        public double high_flap_threshold { get; set; }
        public int flap_detection_options { get; set; }
        public int stalking_options { get; set; }
        public bool check_freshness { get; set; }
        public int freshness_threshold { get; set; }
        public bool process_performance_data { get; set; }
        public bool checks_enabled { get; set; }
        public bool accept_passive_checks { get; set; }
        public bool event_handler_enabled { get; set; }
        public bool retain_status_information { get; set; }
        public bool retain_nonstatus_information { get; set; }
        public bool obsess { get; set; }
        public bool hourly_value { get; set; }
        public string notes { get; set; }
        public string notes_url { get; set; }
        public string action_url { get; set; }
        public string icon_image { get; set; }
        public string icon_image_alt { get; set; }
        public string vrml_image { get; set; }
        public string statusmap_image { get; set; }
        public bool have_2d_coords { get; set; }
        public int x_2d { get; set; }
        public int y_2d { get; set; }
        public bool have_3d_coords { get; set; }
        public double x_3d { get; set; }
        public double y_3d { get; set; }
        public double z_3d { get; set; }
        public bool should_be_drawn { get; set; }
        public CustomVariables custom_variables { get; set; }
    }

    public class DataHost
    {
        public Host host { get; set; }
    }

    public class objectHost
    {
        public int format_version { get; set; }
        public Result result { get; set; }
        public DataHost data { get; set; }
    }
}