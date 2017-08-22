using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Class
{
    public class DbConnectionFactory
    {
        public Interface.IDbConnection GetDbConnection(string name)
        {
            switch (name)
            {
                case nameof(SqlDbConnection):
                    return new SqlDbConnection();
                case nameof(MySqlDbConnection):
                    return new MySqlDbConnection();
                default:
                    throw new NotImplementedException();

            }
        }
    }
}
