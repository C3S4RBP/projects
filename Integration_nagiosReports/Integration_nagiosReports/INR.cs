using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Integration_nagiosReports
{
    public partial class INR : Form
    {
        public INR()
        {
            InitializeComponent();
        }

        DateTime fechaActual = DateTime.Today;
        Database db = new Database();
        int anio = 0;
        dataNagios dat_nagios = new dataNagios();
        DateTime start;
        String hostname = Environment.MachineName;
        String username = Environment.UserDomainName +"/"+ Environment.UserName;
        String os = Environment.OSVersion.Platform + " - " + Environment.OSVersion.ServicePack + " - " + Environment.OSVersion.Version;
        String url = "http://192.168.100.250/nagios/cgi-bin/archivejson.cgi?query=availability&availabilityobjecttype=services&hostname={0}&servicedescription={1}&starttime={2}&endtime={3}";

        private void INR_Load(object sender, EventArgs e)
        {
            this.Show();
            WriteToEventLog("nagiosReports", db.checkDatabase(), 1, 1);
            btn_insert.Enabled = false;
            txt_log.ScrollBars = ScrollBars.Vertical;
            txt_error.ScrollBars = ScrollBars.Vertical;
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            inpyear.ReadOnly = !inpyear.ReadOnly;
            CB_mes.Enabled = !CB_mes.Enabled;
            txt_log.Clear();
            txt_error.Clear();
            anio = Convert.ToInt32(inpyear.Text);
            if (existData(CB_mes.Text,true))
            {
                start = DateTime.Now;
                WriteToEventLog("nagiosReports", String.Format("Inicia cargue para el mes de: {0} con start de: {1}", CB_mes.Text, start.ToString()), 1,300);
                btn_insert.Enabled = false;
                //MessageBox.Show(String.Format("Se incia el proceso de carga para el mes de {0} para el Año {1}. ", CB_mes.Text, anio));
                WriteToEventLog("nagiosReports", String.Format("Se incia el proceso de carga para el mes de {0} para el Año {1}. ", CB_mes.Text, anio), 2, 1);
                getData(CB_mes.Text, "I");
            }
            else
            {
                //DialogResult result = MessageBox.Show(String.Format("Ya existe informacion para el mes de {0} y Año {1}. ¿Desea actualizar la informacion?", CB_mes.Text, anio), "Alerta", MessageBoxButtons.YesNo);
                //if (result == DialogResult.Yes)
                //{
                    start = DateTime.Now;
                    btn_insert.Enabled = false;
                    WriteToEventLog("nagiosReports", String.Format("Inicia actualizacion para el mes de: {0} con start de: {1}", CB_mes.Text, start.ToString()), 1,300);
                    getData(CB_mes.Text, "U");
                //}
            }
            
        }

        private void cb_mes_cambio(object sender, EventArgs e)
        {
            btn_insert.Enabled = CB_mes.Text == "" ? false : true;
        }

        private Boolean existData(String mes, Boolean isMonthly)
        {
            anio = Convert.ToInt32(inpyear.Text);
            if (isMonthly)
            {
                return db.existData(mes, anio);
            }
            else
            {
                return db.existDataDiary(mes, anio);
            }
        }

        private void getData(String mes, String operation)
        {
            anio = Convert.ToInt32(inpyear.Text);
            String startDate = "";
            String endDate = "";
            switch (mes)
            {
                case "Diciembre":
                    startDate = (new DateTime(anio, 12, 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    endDate = (new DateTime((anio + 1), 1, 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    break;
                default:
                    startDate = (new DateTime(anio, GetDayofMonth(mes), 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    endDate = (new DateTime(anio, GetDayofMonth(mes)+1, 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    break;
            }

            DataTable dt = db.getHostService(operation,anio, mes, true);
            foreach (DataRow row in dt.Rows)
            {
                String url_final = String.Format(url, row.ItemArray[0], row.ItemArray[1], startDate, endDate);
                setMsgLog("Consumiendo el host " + row.ItemArray[0] + " Servicio " + row.ItemArray[1] + " id " + row.ItemArray[2], 1);
                var response = dat_nagios.getDataNagios(url_final);
                if (response != null)
                {
                    if (!(response.time_ok == 0 && response.time_warning == 0 && response.time_critical == 0))
                    { 
                        setMsgLog("Url " + url_final, 1);
                        setMsgLog("-----------------------------------------", 1);
                        setMsgLog("Tiempos: ok:" + response.time_ok + ", Warning:" + response.time_warning + ", Critical:" + response.time_critical + " No data: " + response.time_indeterminate_nodata, 1);
                        db.insertUpdateData(operation, 1, Convert.ToInt32(row.ItemArray[2]), anio, mes, response.time_ok, response.time_warning, response.time_critical, response.time_indeterminate_nodata, url_final);
                        setMsgLog("cargado el host " + response.host_name + " y servicio " + response.description, 1);

                        /* ************** */
                        /* cargue diario */
                        /* ************** */

                        txt_log.Clear();
                        txt_error.Clear();
                        btn_insert.Enabled = false;
                        if (existData(CB_mes.Text, false))
                        {
                            start = DateTime.Now;
                            //WriteToEventLog("nagiosReports", String.Format("Inicia cargue para el mes de: {0} con start de: {1}", CB_mes.Text, start.ToString()), 2, 2);
                            //MessageBox.Show(String.Format("Se incia el proceso de carga para el mes de {0} para el Año {1}. ", CB_mes.Text, anio));
                            getDataDay(CB_mes.Text, "I", row.ItemArray[0].ToString(), row.ItemArray[1].ToString(), row.ItemArray[2].ToString());
                        }
                        else
                        {
                            //DialogResult result = MessageBox.Show(String.Format("Ya existe informacion para el mes de {0} y Año {1}. ¿Desea actualizar la informacion?", CB_mes.Text, anio), "Alerta", MessageBoxButtons.YesNo);
                            //if (result == DialogResult.Yes)
                            //{
                                start = DateTime.Now;
                                //WriteToEventLog("nagiosReports", String.Format("Inicia actualizacion para el mes de: {0} con start de: {1}", CB_mes.Text, start.ToString()), 2, 2);
                                getDataDay(CB_mes.Text, "U", row.ItemArray[0].ToString(), row.ItemArray[1].ToString(), row.ItemArray[2].ToString());
                            //}
                        }
                        WriteToEventLog(
                           "nagiosReports",
                           "Con datos \n: " + txt_log.Text + "\n" + "****************************************************\n sin data \n **************************************************** \n " + txt_error.Text,
                           1,
                           2);
                        txt_log.Clear();
                        txt_error.Clear();
                        //btn_dataDiary_Click(sender, e);
                    }
                    else
                    {
                        //MessageBox.Show("El host/Servicio no retorno datos en el mes, por ende no se requiere obtener datos diarios");
                        WriteToEventLog("nagiosReports", "El host/Servicio no retorno datos en el mes, por ende no se requiere obtener datos diarios \n " + url_final, 0, 200);
                        setMsgLog("Url " + url_final, 1);
                        setMsgLog(response.host_name + " y servicio " + response.description + " - Tiempos: ok:" + response.time_ok + ", Warning:" + response.time_warning + ", Critical:" + response.time_critical, 2);
                        setMsgLog("=========================================", 2);
                        db.insertUpdateData("I", 3, Convert.ToInt32(row.ItemArray[2]), anio, mes, 0, 0, 0, 0, "");
                    }
                    setMsgLog("=========================================", 1);
                }
                else
                {
                    setMsgLog("la respuesta es null" + row.ItemArray[0] + " Servicio " + row.ItemArray[1], 2);
                    setMsgLog("=========================================", 1);
                    setMsgLog("=========================================", 2);
                }
            }
            db.insertUpdateData(operation, 2, 0, anio, mes, 0, 0, 0, 0,"");
            btn_insert.Enabled = true;
            inpyear.ReadOnly = !inpyear.ReadOnly;
            CB_mes.Enabled = !CB_mes.Enabled;
            WriteToEventLog("nagiosReports", String.Format("Termina Cargue del proceso del mes de: {0} tiempo de ejecución: {1}", mes, DateTime.Now.Subtract(start).ToString()), 1,300);
            //MessageBox.Show(String.Format("Termino proceso de cargue exitosamente para el mes de: {0}", mes));
        }

        private void setMsgLog(String msg, int tipoCampo)
        {
            if (tipoCampo == 1)
            {
                txt_log.AppendText(msg);
                txt_log.AppendText(Environment.NewLine);            
            }
            else
            {
                txt_error.AppendText(msg);
                txt_error.AppendText(Environment.NewLine);
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

        public void WriteToEventLog(String strLogName, String strErrDetail, int typeError, int isMonthly)
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
                                      isMonthly
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

        //private void btn_dataDiary_Click(object sender, EventArgs e)
        //{
        //    txt_log.Clear();
        //    txt_error.Clear();
        //    btn_insert.Enabled = false;
        //    if (existData(CB_mes.Text, false))
        //    {
        //        start = DateTime.Now;
        //        WriteToEventLog("nagiosReports", String.Format("Inicia cargue para el mes de: {0} con start de: {1}", CB_mes.Text, start.ToString()), 2,2);
        //        MessageBox.Show(String.Format("Se incia el proceso de carga para el mes de {0} para el Año {1}. ", CB_mes.Text, anio));
        //        getDataDay(CB_mes.Text, "I");
        //    }
        //    else
        //    {
        //        DialogResult result = MessageBox.Show(String.Format("Ya existe informacion para el mes de {0} y Año {1}. ¿Desea actualizar la informacion?", CB_mes.Text, anio), "Alerta", MessageBoxButtons.YesNo);
        //        if (result == DialogResult.Yes)
        //        {
        //            start = DateTime.Now;
        //            WriteToEventLog("nagiosReports", String.Format("Inicia actualizacion para el mes de: {0} con start de: {1}", CB_mes.Text, start.ToString()), 2,2);
        //            getDataDay(CB_mes.Text, "U");
        //        }
        //    }
        //}

        private void getDataDay(String mes, String operation, String host, String Service, String idHost)
        {
            String startDate = "";
            String endDate = "";
            anio = Convert.ToInt32(inpyear.Text);
            int cantDays = DateTime.DaysInMonth(anio, GetDayofMonth(mes));
            //DataTable dt = db.getHostService(operation,anio,mes,false);
            for(int idx = 1; idx<= cantDays; idx++)
            {
                if(idx == cantDays)
                {
                    startDate = (new DateTime(anio, GetDayofMonth(mes), idx).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    if (mes == "Diciembre")
                    {
                        endDate = (new DateTime((anio+1), 1, 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    }
                    else
                    {
                        endDate = (new DateTime(anio, GetDayofMonth(mes) + 1, 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    }
                }
                else
                {
                    startDate = (new DateTime(anio, GetDayofMonth(mes), idx).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                    endDate = (new DateTime(anio, GetDayofMonth(mes), idx + 1).ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                }

                String url_final = String.Format(url, host, Service, startDate, endDate);
                setMsgLog("Consumiendo el host " + host + " Servicio " + Service + " id " + idHost + " dia " + idx.ToString(), 1);
                var response = dat_nagios.getDataNagios(url_final);
                if (response != null)
                {
                    if (!(response.time_ok == 0 && response.time_warning == 0 && response.time_critical == 0))
                    {
                        setMsgLog("Url " + url_final, 1);
                        setMsgLog("-----------------------------------------", 1);
                        setMsgLog("Tiempos: ok:" + response.time_ok + ", Warning:" + response.time_warning + ", Critical:" + response.time_critical + " No data: " + response.time_indeterminate_nodata, 1);
                        db.insertUpdateDataDiary(operation, 1, Convert.ToInt32(idHost), anio, mes,idx, response.time_ok, response.time_warning, response.time_critical, response.time_indeterminate_nodata, url_final);
                        setMsgLog("cargado el host " + response.host_name + " y servicio " + response.description, 1);
                    }
                    else
                    {
                        setMsgLog(response.host_name + " y servicio " + response.description + " - Tiempos: ok:" + response.time_ok + ", Warning:" + response.time_warning + ", Critical:" + response.time_critical, 2);
                        setMsgLog("========================================", 2);
                    }
                    setMsgLog("========================================", 1);
                }
                else
                {
                    setMsgLog("la respuesta es null" + host + " Servicio " + Service, 2);
                    setMsgLog("=========================================", 1);
                    setMsgLog("=========================================", 2);
                }

                db.insertUpdateDataDiary(operation, 2, 0, anio, mes, idx, 0, 0, 0, 0, "");
//               WriteToEventLog("nagiosReports", String.Format("Termina Cargue del proceso del mes de: {0} y dia: {1} tiempo de ejecución: {2}, para el host:{3} - {4}", mes, idx.ToString(), DateTime.Now.Subtract(start).ToString(),host,idHost), 2,2);
                
            }
            //MessageBox.Show("Se termino el cargue de información");
        }

        private int GetDayofMonth(String mes)
        {   

            switch (mes)
            {
                case "Enero":
                    return 1;
                case "Febrero":
                    return 2;
                case "Marzo":
                    return 3;
                case "Abril":
                    return 4;
                case "Mayo":
                    return 5;
                case "Junio":
                    return 6;
                case "Julio":
                    return 7;
                case "Agosto":
                    return 8;
                case "Septiembre":
                    return 9;
                case "Octubre":
                    return 10;
                case "Noviembre":
                    return 11;
                case "Diciembre":
                    return 12;
                default:
                    return 0;
            }
        }
    }
}