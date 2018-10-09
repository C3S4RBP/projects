using System;
using System.Diagnostics;

namespace IntegrationNagiosLibrary.Event
{
    public class Events
    {
        String strLogName = "IntegrationNagiosService";
        String hostname = Environment.MachineName;
        String username = Environment.UserDomainName + "/" + Environment.UserName;
        String os = Environment.OSVersion.Platform + " - " + Environment.OSVersion.ServicePack + " - " + Environment.OSVersion.Version;
        public void WriteToEventLog(String strErrDetail, int typeError = 1, int codMsg = 0)
        {
            EventLog SQLEventLog = new EventLog();
            try
            {
                if (!EventLog.SourceExists(strLogName))
                    this.CreateLog(strLogName);

                SQLEventLog.Source = strLogName;
                strErrDetail = String.Format("Fecha: {0} \nHost: {1} \nUsername: {2} \nSistema Operarivo: {3} \n ====================== \n", DateTime.Now, hostname, username, os) + strErrDetail;
                SQLEventLog.WriteEntry(Convert.ToString(strErrDetail),
                                      typeError == 1 ? EventLogEntryType.Information : typeError == 0 ? EventLogEntryType.Error : EventLogEntryType.Warning,
                                      codMsg
                );
            }
            catch (Exception ex)
            {
                SQLEventLog.Source = strLogName;
                SQLEventLog.WriteEntry(Convert.ToString("INFORMATION: ")
                                      + Convert.ToString(ex.Message),
                EventLogEntryType.Information);
            }
            finally
            {
                SQLEventLog.Dispose();
                SQLEventLog = null;
            }
        }

        private bool CreateLog(String strLogName)
        {
            bool Result = false;

            try
            {
                EventLog.CreateEventSource(strLogName, strLogName);
                EventLog SQLEventLog =
            new EventLog();

                SQLEventLog.Source = strLogName;
                SQLEventLog.Log = strLogName;
                SQLEventLog.Source = strLogName;
                SQLEventLog.WriteEntry("The " + strLogName + " was successfully initialize component.", EventLogEntryType.Information);
                Result = true;
            }
            catch
            {
                Result = false;
            }

            return Result;
        }
    }
}
