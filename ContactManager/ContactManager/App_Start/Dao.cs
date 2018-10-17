using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ContactManager.App_Start
{
    public class Dao
    { 
        public Dao()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            string checkuser = "select id from Contact where Name ='Filipe';";
            SqlCommand cmd = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            if (temp == 2)
            {
                Console.Write("Conexão realizada!");
            }

            conn.Close();
        }

        public string ExecutarQuery(string query)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            string resultado = cmd.ExecuteScalar().ToString();
            conn.Close();
            return resultado;
        }



    }
}