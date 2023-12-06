using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApplication1
{
    public class DbHelper
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Practice_Album_SystemConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rd;
        public bool DbConn() 
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
                return true;
            }
            else if (conn.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public SqlCommand DbShow(string sql) 
        {
            cmd.Connection = conn;
            cmd.CommandText= sql;
            return cmd;
        }

        public void DbClose() 
        {
            conn.Close();
        }
    }
}