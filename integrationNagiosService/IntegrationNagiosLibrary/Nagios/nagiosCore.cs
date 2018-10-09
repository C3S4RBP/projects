using IntegrationNagiosLibrary.Database;
using IntegrationNagiosLibrary.Event;
using IntegrationNagiosLibrary.objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace IntegrationNagiosLibrary.Nagios
{
    public class nagiosCore
    {
        String serverNagios = ConfigurationManager.AppSettings["servernagios"];
        ConnectionStringSettings settingsDB = ConfigurationManager.ConnectionStrings["ngconn"];
        String url = "/cgi-bin/archivejson.cgi?query=availability&availabilityobjecttype=services&hostname={0}&servicedescription={1}&starttime={2}&endtime={3}";
        DataBase db = new DataBase();
        Events evtx = new Events();
        int anio = DateTime.Now.Year, currentDay = DateTime.Now.Day, cantDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

        
        public void integrationProcess()
        {
            evtx.WriteToEventLog("Iniciar procesos Integration", 1, 0);
            checkConnDatabase();
        }

        private void checkConnDatabase()
        {
            if (db.connDatabase(settingsDB))
            {
                String mes = GetNameMonth(DateTime.Now.Month);
                var currentDayDB = db.GetCurrenDay(anio, mes, settingsDB);
                if(currentDayDB == 1 && currentDay != currentDayDB)
                {
                    for (int d = (currentDayDB + 1); d <= DateTime.Now.Day; d++)
                    {
                        currentDay = d;
                        evtx.WriteToEventLog("dia: " + currentDay, 1, 0);
                        getDataDay(DateTime.Now.Month, "I");
                    }
                }
                else
                {
                    if (ExistData(mes, false))
                    {
                        evtx.WriteToEventLog("dia: " + currentDay, 1, 0);
                        getDataDay(DateTime.Now.Month, "I");
                    }
                    else
                    {
                        if (currentDay == currentDayDB)
                        {
                            evtx.WriteToEventLog("dia: " + currentDay, 1, 0);
                            getDataDay(DateTime.Now.Month, "U");
                        }
                        else
                        {
                            for (int d = (currentDayDB + 1); d <= DateTime.Now.Day; d++)
                            {
                                currentDay = d;
                                evtx.WriteToEventLog("dia: " + currentDay, 1, 0);
                                getDataDay(DateTime.Now.Month, "U");
                            }
                        }
                    }
                }

                
                if (cantDays == DateTime.Now.Day)
                {
                    /* Cargar todo el mes */
                    if (ExistData(mes, true))
                    {
                        evtx.WriteToEventLog("Inicia cargue del mes: " + mes, 1, 100);
                        getData(mes, "I");
                    }
                    else
                    {
                        evtx.WriteToEventLog("Inicia actualización del mes: " + mes, 1, 100);
                        getData(mes, "U");
                    }
                }
                evtx.WriteToEventLog("Finalizacion procesos Integration");
            }
        }

        private Service getDataNagios(String url)
        {
            var json = "";
            nagiosObj objRta = new nagiosObj();
            try
            {
                var client = new WebClient();
                String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("gestion:G3st10n"));
                client.Headers[HttpRequestHeader.Authorization] = String.Format(
                    "Basic {0}", credentials);
                json = client.DownloadString(serverNagios+url);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                objRta = ser.Deserialize<nagiosObj>(json);
                return objRta.data.service;
            }
            catch (Exception ex)
            {
                evtx.WriteToEventLog(String.Format("Error: ", ex.Message), 0, 200);
                return objRta.data.service;
            }
        }

        private Boolean ExistData(String mes, Boolean isMonthly)
        {
            if (isMonthly)
            {
                return db.existData(mes, anio, settingsDB);
            }
            else
            {
                return db.existDataDiary(mes, anio,currentDay, settingsDB);
            }
        }

        private String GetNameMonth(int mes)
        {
            switch (mes)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Septiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                case 12: return "Diciembre";
                default:
                    return "";
            }
        }

        private void getData(String mes, String operation)
        {
            String startDate = "";
            String endDate = "";
            switch (mes)
            {
                case "Diciembre":
                    startDate = (new DateTime((anio - 1), 12, 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    endDate = (new DateTime(anio, 1, 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    break;
                default:
                    startDate = (new DateTime(anio, DateTime.Now.Month - 1, 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    endDate = (new DateTime(anio, DateTime.Now.Month, 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    break;
            }

            DataTable dt = db.getHostService(operation, anio, mes, true, settingsDB);
            foreach (DataRow row in dt.Rows)
            {
                String url_final = String.Format(url, row.ItemArray[0], row.ItemArray[1], startDate, endDate);
                var response = getDataNagios(url_final);
                if (response != null)
                {
                    if (!(response.time_ok == 0 && response.time_warning == 0 && response.time_critical == 0))
                    {
                        db.insertUpdateData(operation, 1, Convert.ToInt32(row.ItemArray[2]), anio, mes, response.time_ok, response.time_warning, response.time_critical, response.time_indeterminate_nodata, url_final, settingsDB);
                    }
                    else
                    {
                        evtx.WriteToEventLog("El host/Servicio no retorno datos en el mes, por ende no se requiere obtener datos diarios \n " + url_final, 0, 201);
                        db.insertUpdateData("I", 3, Convert.ToInt32(row.ItemArray[2]), anio, mes, 0, 0, 0, 0, "", settingsDB);
                    }
                }
                else
                {
                    db.insertUpdateData("I", 3, Convert.ToInt32(row.ItemArray[2]), anio, mes, 0, 0, 0, 0, "", settingsDB);
                }
            }
            db.insertUpdateData(operation, 2, 0, anio, mes, 0, 0, 0, 0, "", settingsDB);
            evtx.WriteToEventLog(String.Format("Termina Cargue del proceso del mes de: {0}", mes), 1, 300);
        }

        private void getDataDay(int mes, String operation)
        {
            String startDate = "";
            String endDate = "";
            if (currentDay == 1)
            {
                endDate = (new DateTime(anio, mes, currentDay).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                if (GetNameMonth(mes) == "Enero")
                {
                    startDate = (new DateTime((anio - 1), 12, 31).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                }
                else
                {
                    startDate = (new DateTime(anio, mes - 1, (DateTime.DaysInMonth(anio, mes - 1))).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                }
            }
            else
            {
                startDate = (new DateTime(anio, mes, currentDay-1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                endDate = (new DateTime(anio, mes, currentDay).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            }

            DataTable dt = db.getHostService(operation, anio, GetNameMonth(mes), false, settingsDB, currentDay-1);
            foreach (DataRow row in dt.Rows)
            {
                String url_final = String.Format(url, row.ItemArray[0].ToString(), row.ItemArray[1].ToString(), startDate, endDate);
                var response = getDataNagios(url_final);
                if (response != null)
                {
                    if (!(response.time_ok == 0 && response.time_warning == 0 && response.time_critical == 0))
                    {
                        db.insertUpdateDataDiary(operation, 1, Convert.ToInt32(row.ItemArray[2].ToString()), anio, GetNameMonth(mes), currentDay-1, response.time_ok, response.time_warning, response.time_critical, response.time_indeterminate_nodata, url_final, settingsDB);
                    }
                    else
                    {
                        evtx.WriteToEventLog(response.host_name + " y servicio " + response.description + " - Tiempos: ok:" + response.time_ok + ", Warning:" + response.time_warning + ", Critical:" + response.time_critical, 0, 202);
                    }
                }
                else
                {
                    db.insertUpdateData("I", 3, Convert.ToInt32(row.ItemArray[2]), anio, GetNameMonth(mes), 0, 0, 0, 0, "", settingsDB);
                }
            }
            db.insertUpdateDataDiary(operation, 2, 0, anio, GetNameMonth(mes), currentDay-1, 0, 0, 0, 0, "", settingsDB);
        }
    }
}
