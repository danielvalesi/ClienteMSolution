using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

namespace ClienteWeb.Models
{
    public abstract class Model : IDisposable
    {
        protected SqlConnection conn;

        public Model()
        {
            // DESKTOP-UP6R27O
            string strConn = @"Data Source = localhost; 
                Initial Catalog = BDCliente;
                Integrated Security = true";                
            conn = new SqlConnection(strConn);
            conn.Open();

        }

        public void Dispose()
        {
            conn.Close();
        }
      
    }
}