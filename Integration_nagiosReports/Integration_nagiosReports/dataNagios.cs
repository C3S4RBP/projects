﻿using Integration_nagiosReports.NgObject;
using System;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Integration_nagiosReports
{
    public class dataNagios
    {

        public Service getDataNagios(String url)
        {
            INR principal = new INR();
            var json = "";
            nagiosObject objRta = new nagiosObject();
            try
            {
                var client = new WebClient();
                String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("gestion:G3st10n"));
                client.Headers[HttpRequestHeader.Authorization] = String.Format(
                    "Basic {0}", credentials);
                json = client.DownloadString(url);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                objRta = ser.Deserialize<nagiosObject>(json);
                return objRta.data.service;
            }catch(Exception ex)
            {
                principal.WriteToEventLog("nagiosReports", String.Format("Error: ", ex.Message), 0, 100);
                return objRta.data.service;
            }
        }

        public Host getDetailHost(String url)
        {
            INR principal = new INR();
            var json = "";
            objectHost objRta = new objectHost();
            try
            {
                var client = new WebClient();
                String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("gestion:G3st10n"));
                client.Headers[HttpRequestHeader.Authorization] = String.Format(
                    "Basic {0}", credentials);
                json = client.DownloadString(url);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                objRta = ser.Deserialize<objectHost>(json);
                return objRta.data.host;
            }
            catch (Exception ex)
            {
                principal.WriteToEventLog("nagiosReports", String.Format("Error: ", ex.Message), 0, 100);
                return objRta.data.host;
            }
        }
    }
}
