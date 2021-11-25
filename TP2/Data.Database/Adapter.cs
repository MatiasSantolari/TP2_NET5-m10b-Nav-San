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

<<<<<<< HEAD
        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringExpress";

        public SqlConnection sqlConn { get; set; }

        protected void OpenConnection()
        {
            string connstr= ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection(connstr);
            sqlConn.Open();
=======
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
>>>>>>> MATT-FRANC
        }

        protected void CloseConnection() //cierra conexion
        {
<<<<<<< HEAD
            sqlConn.Close();
            sqlConn = null;
=======
            try
            {
                sqlConnection.Close();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
>>>>>>> MATT-FRANC
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
