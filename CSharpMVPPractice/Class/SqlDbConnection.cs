using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CSharpMVPPractice.Class
{
    public class SqlDbConnection : Interface.IDbConnection
    {
        public DataSet SqlDatasetQuery(string query)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SqlServerConnectionString"]))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query,conn);
                da.Fill(ds);
                conn.Close();
                conn.Dispose();
                da.Dispose();
            }
            return ds;
        }
    }
}
