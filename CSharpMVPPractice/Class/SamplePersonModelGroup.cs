using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Class
{
    public class SamplePersonModelGroup : IPersonModelGroup
    {
        public List<PersonModel> PersonModelGroupData()
        {
            List<PersonModel> personList = new List<PersonModel>();
            personList.Add(new PersonModel() { ID = 1, Name = "Name1" });
            personList.Add(new PersonModel() { ID = 2, Name = "Name2" });
            personList.Add(new PersonModel() { ID = 3, Name = "Name3" });
            personList.Add(new PersonModel() { ID = 4, Name = "Name4" });
            personList.Add(new PersonModel() { ID = 5, Name = "Name5" });
            personList.Add(new PersonModel() { ID = 6, Name = "Name6" });
            return personList;
        }

        public List<PersonModel> PersonModelGroupData(IDbConnection _dbConnection)
        {
            throw new NotImplementedException();
        }
    }
}
