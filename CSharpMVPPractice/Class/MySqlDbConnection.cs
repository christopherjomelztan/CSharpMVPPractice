using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CSharpMVPPractice.Class
{
    public class MySqlDbConnection : Interface.IDbConnection
    {
        public DataSet SqlDatasetQuery(string query)
        {
            DataSet ds = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["MySqlConnectionString"]))
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(ds);
                conn.Close();
                conn.Dispose();
                da.Dispose();
            }
            return ds;
        }
    }
}
