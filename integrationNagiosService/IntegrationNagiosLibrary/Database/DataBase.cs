using IntegrationNagiosLibrary.Event;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IntegrationNagiosLibrary.Database
{
    public class DataBase
    {
        SqlConnection sqlcon = new SqlConnection();
        String sp = "";
        Events evtx = new Events();

        public Boolean connDatabase(ConnectionStringSettings settings)
        {
            Boolean response = false;
            String CN = "";
            try
            {
                if (settings != null)
                {
                    CN = settings.ConnectionString;
                }
                sqlcon.ConnectionString = CN;
                sqlcon.Open();
                response = true;
                
                evtx.WriteToEventLog("Se encuentra conectado a la BD " + sqlcon.Database, 1, 100);
            }
            catch (SqlException ex)
            {
                evtx.WriteToEventLog(ex.Message, 0, 200);
            }
            return response;
        }

        public Boolean existData(String mes, int anio, ConnectionStringSettings settings)
        {
            SqlConnection scn = new SqlConnection(settings.ConnectionString);
            SqlDataReader dr = null;
            Boolean rta = false;
            sp = "NG_SELECT";
            SqlCommand spcmd = new SqlCommand(sp, scn);
            spcmd.Parameters.Add(new SqlParameter("@V_OPERATION", 1));
            spcmd.Parameters.Add(new SqlParameter("@V_ANIO", anio));
            spcmd.Parameters.Add(new SqlParameter("@V_MES", mes));
            spcmd.CommandType = CommandType.StoredProcedure;
            scn.Open();
            dr = spcmd.ExecuteReader();
            while (dr.Read())
            {
                rta = dr.GetValue(0).Equals(0) ? true : false;
            }
            dr.Close();
            scn.Close();
            return rta;
        }

        public Boolean existDataDiary(String mes, int anio,int day , ConnectionStringSettings settings)
        {
            SqlConnection scn = new SqlConnection(settings.ConnectionString);
            SqlDataReader dr = null;
            Boolean rta = false;
            sp = "NG_SELECT_DIARY";
            SqlCommand spcmd = new SqlCommand(sp, scn);
            spcmd.Parameters.Add(new SqlParameter("@V_OPERATION", 1));
            spcmd.Parameters.Add(new SqlParameter("@V_ANIO", anio));
            spcmd.Parameters.Add(new SqlParameter("@V_MES", mes));
            spcmd.Parameters.Add(new SqlParameter("@V_DAY", day));
            spcmd.CommandType = CommandType.StoredProcedure;
            scn.Open();
            dr = spcmd.ExecuteReader();
            while (dr.Read())
            {
                rta = dr.GetValue(0).Equals(0) ? true : false;
            }
            dr.Close();
            scn.Close();
            return rta;
        }

        public DataTable getHostService(String operation, int anio, String mes, Boolean isMonthly, ConnectionStringSettings settings, int dia = 0)
        {
            DataTable dt = new DataTable();
            sp = isMonthly ? "NG_SELECT" : "NG_SELECT_DIARY";
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection scn = new SqlConnection(settings.ConnectionString);
            try
            {
                cmd = new SqlCommand(sp, scn);
                cmd.Parameters.Add(new SqlParameter("@V_OPERATION", 2));
                cmd.Parameters.Add(new SqlParameter("@V_ANIO", anio));
                cmd.Parameters.Add(new SqlParameter("@V_MES", mes));
                if(sp == "NG_SELECT_DIARY")
                {
                    cmd.Parameters.Add(new SqlParameter("@V_DAY", dia));
                }
                cmd.CommandType = CommandType.StoredProcedure;
                scn.Open();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (SqlException x)
            {
                Console.WriteLine(x.Message);
                evtx.WriteToEventLog("x.Message", 2, 600);
            }
            finally
            {
                cmd.Dispose();
                scn.Close();
            }
            return dt;
        }

        public void insertUpdateData(String operation, int option, int idHostService, int anio, String mes, int v_ok, int v_warnign, int v_critial, int v_nodata, String url, ConnectionStringSettings settings)
        {
            SqlConnection scn = new SqlConnection(settings.ConnectionString);
            try
            {
                sp = "NG_INSERT_UPDATE";
                SqlCommand spcmd = new SqlCommand(sp, scn);
                spcmd.Parameters.Add(new SqlParameter("@I_OPERATION", operation));
                spcmd.Parameters.Add(new SqlParameter("@I_OPTION", option));
                spcmd.Parameters.Add(new SqlParameter("@I_IDHOST", idHostService));
                spcmd.Parameters.Add(new SqlParameter("@I_ANIO", anio));
                spcmd.Parameters.Add(new SqlParameter("@I_MES", mes));
                spcmd.Parameters.Add(new SqlParameter("@I_OK", v_ok));
                spcmd.Parameters.Add(new SqlParameter("@I_WARNING", v_warnign));
                spcmd.Parameters.Add(new SqlParameter("@I_CRITICAL", v_critial));
                spcmd.Parameters.Add(new SqlParameter("@I_NODATA", v_nodata));
                spcmd.Parameters.Add(new SqlParameter("@I_URL", url));
                spcmd.Parameters.Add(new SqlParameter("@I_HOSTIP", ""));
                spcmd.Parameters.Add(new SqlParameter("@I_HOSTNAME", ""));
                spcmd.CommandType = CommandType.StoredProcedure;
                scn.Open();
                spcmd.ExecuteReader();
            }
            catch (SqlException x)
            {
                Console.WriteLine(x.Message);
            }
            finally
            {
                scn.Close();
            }
        }

        public void insertUpdateDataDiary(String operation, int option, int idHostService, int anio, String mes, int day, int v_ok, int v_warnign, int v_critial, int v_nodata, String url, ConnectionStringSettings settings)
        {
            SqlConnection scn = new SqlConnection(settings.ConnectionString);
            sp = "NG_INSERT_UPDATE_DIARY";
            SqlCommand spcmd = new SqlCommand(sp, scn);
            spcmd.Parameters.Add(new SqlParameter("@I_OPERATION", operation));
            spcmd.Parameters.Add(new SqlParameter("@I_OPTION", option));
            spcmd.Parameters.Add(new SqlParameter("@I_IDHOST", idHostService));
            spcmd.Parameters.Add(new SqlParameter("@I_ANIO", anio));
            spcmd.Parameters.Add(new SqlParameter("@I_MES", mes));
            spcmd.Parameters.Add(new SqlParameter("@I_DAY", day));
            spcmd.Parameters.Add(new SqlParameter("@I_OK", v_ok));
            spcmd.Parameters.Add(new SqlParameter("@I_WARNING", v_warnign));
            spcmd.Parameters.Add(new SqlParameter("@I_CRITICAL", v_critial));
            spcmd.Parameters.Add(new SqlParameter("@I_NODATA", v_nodata));
            spcmd.Parameters.Add(new SqlParameter("@I_URL", url));
            spcmd.Parameters.Add(new SqlParameter("@I_HOSTIP", ""));
            spcmd.Parameters.Add(new SqlParameter("@I_HOSTNAME", ""));
            spcmd.CommandType = CommandType.StoredProcedure;
            scn.Open();
            spcmd.ExecuteReader();
            scn.Close();
        }

        public int GetCurrenDay (int anio, String mes,ConnectionStringSettings settings)
        {
            SqlConnection scn = new SqlConnection(settings.ConnectionString);
            SqlDataReader dr = null;
            int rta = 0;
            sp = "NG_SELECT_DIARY";
            SqlCommand spcmd = new SqlCommand(sp, scn);
            spcmd.Parameters.Add(new SqlParameter("@V_OPERATION", 3));
            spcmd.Parameters.Add(new SqlParameter("@V_ANIO", anio));
            spcmd.Parameters.Add(new SqlParameter("@V_MES", mes));
            spcmd.Parameters.Add(new SqlParameter("@V_DAY", 0));
            spcmd.CommandType = CommandType.StoredProcedure;
            scn.Open();
            dr = spcmd.ExecuteReader();
            while (dr.Read())
            {
                rta = Int32.Parse(dr.GetValue(0).ToString());
            }
            dr.Close();
            scn.Close();
            return rta;
        }
    }
}
