using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Integration_nagiosReports
{
    public class Database
    {
        SqlConnection sqlcon = new SqlConnection();
        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ngconn"];
        String sp = "";

        public String checkDatabase()
        {
            String rta = "";
            String CN = null;
            try
            {
                if (settings != null)
                {
                    CN = settings.ConnectionString;
                }
                sqlcon.ConnectionString = CN;
                sqlcon.Open();
                rta = "Se encuentra conectado a la BD Nagios_report";
            }
            catch (SqlException ex)
            {
                rta = ex.Message;
            }
            return rta;
        }

        public Boolean existData(String mes, int anio)
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

        public DataTable getHostService(String operation, int anio, String mes, Boolean isMonthly)
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
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (SqlException x)
            {
                Console.WriteLine(x.Message);
            }
            finally
            {
                cmd.Dispose();
                scn.Close();
            }
            return dt;
        }

        public void insertUpdateData(String operation, int option, int idHostService, int anio, String mes, int v_ok, int v_warnign, int v_critial, int v_nodata, String url)
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

        public Boolean existDataDiary(String mes, int anio)
        {
            SqlConnection scn = new SqlConnection(settings.ConnectionString);
            SqlDataReader dr = null;
            Boolean rta = false;
            sp = "NG_SELECT_DIARY";
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

        public void insertUpdateDataDiary(String operation, int option, int idHostService, int anio, String mes,int day, int v_ok, int v_warnign, int v_critial, int v_nodata, String url)
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
            spcmd.CommandType = CommandType.StoredProcedure;
            scn.Open();
            spcmd.ExecuteReader();
            scn.Close();
        }
    }
}