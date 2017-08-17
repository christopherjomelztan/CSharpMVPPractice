using CSharpMVPPractice.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;

namespace CSharpMVPPractice.Class
{
    public class DatabasePersonModelGroup : IPersonModelGroup
    {
        private Interface.IDbConnection _dbConnection;

        public List<PersonModel> PersonModelGroupData(Interface.IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            DataSet ds = dbConnection.SqlDatasetQuery("Select * from Person");
            return ds.Tables[0].AsEnumerable().Select(x => new PersonModel { ID = x.Field<int>("ID"), Name = x.Field<string>("PersonName") }).ToList();
        }
    }
}
