using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        protected SqlConnection sqlConnection;
        public Adapter()
        {
            sqlConnection = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Academia;Integrated Security=True");
        }

        protected void OpenConnection() //abre conexion
        {
            try
            {
                sqlConnection.Open();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        protected void CloseConnection() //cierra conexion
        {
            try
            {
                sqlConnection.Close();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
