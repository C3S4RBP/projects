using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace servicios
{
    public class Database
    {
        int[] columns;
        List<String> result = new List<String>();
        String query = "";
        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["savingconn"];

        private List<String> ExecuteQuery(String query, int[] columns)
        {
            List<String> result = null;
            using (MySqlConnection conn = new MySqlConnection(settings.ConnectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new List<string>();
                        foreach (int column in columns)
                        {
                            result.Add(reader[reader.GetName(column)].ToString());
                        }
                        return result;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }

        private DataSet ExecuteQueryData(String query)
        {
            var ds = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(settings.ConnectionString))
            {
                var dataAdapter = new MySqlDataAdapter(query, conn);
                var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(ds);
            }
            return ds;
        }

        public List<String> GetVersionDataBase()
        {
            columns = new int[] {0};
            MySqlConnectionStringBuilder builder =new MySqlConnectionStringBuilder(settings.ConnectionString);
            query = "select version from `saving`.`version`";
            result = ExecuteQuery(query, columns);
            result.Add(builder["Database"].ToString());
            return result;
        }

        public List<String> Login(String usuario, String Clave)
        {
            columns = new int[] { 0,1,2 };
            query = String.Format(
                @"SELECT nombreusuario, nameRol , saving.roles.idrol 
                FROM saving.usuarios 
                inner join saving.roles on saving.usuarios.idrol = saving.roles.idrol 
                where saving.usuarios.userstatus  = 1 and saving.usuarios.username = '{0}' and saving.usuarios.pass = '{1}'"
                , usuario
                , Clave);
            result = ExecuteQuery(query, columns);
            if(result == null)
            {
                result = new List<String>();
                result.Insert(0, "0");
            }
            else
            {
                result.Insert(0, "1");
            }
            return result;
        }

        public DataSet Usuarios(String opcion,Int32 idUsuario, Usuarios usuario)
        {
            
            switch (opcion)
            {
                case "S":
                    columns = new int[] { 0, 1, 2, 3 };
                    query = String.Format(
                        @"select usuarios.idusuarios 'Codigo Usuario',roles.nameRol Rol, usuarios.nombreusuario Nombre, usuarios.email Email, usuarios.username Username
                        from usuarios
                        inner join roles on usuarios.idrol = roles.idrol
                        where usuarios.idusuarios = {0}"
                        , idUsuario
                        );
                    break;
                case "I":
                    break;
                case "U":
                    query = String.Format(
                        @"UPDATE usuarios SET `nombreusuario` = '{1}',`email` = '{2}',username = '{3}' WHERE `idusuarios` = {0};"
                    , idUsuario
                    ,usuario.nombreusuario
                    ,usuario.email
                    ,usuario.username
                    );
                    break;
            }
            return ExecuteQueryData(query);
        }

        public DataSet Roles()
        {
            query = @"select idrol id, namerol valor 
            from roles
            order by 2 desc";
            return ExecuteQueryData(query);
        }
    }
}
