using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Class
{
    public class CSVPersonModelGroup : IPersonModelGroup
    {
        private PersonModel FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            PersonModel pg = new PersonModel();
            pg.ID = int.Parse(values[0]);
            pg.Name = values[1];
            return pg;
        }

        public List<PersonModel> PersonModelGroupData(IDbConnection _dbConnection)
        {
            return this.PersonModelGroupData();
        }

        public List<PersonModel> PersonModelGroupData()
        {
            List<PersonModel> values = File.ReadAllLines(Environment.CurrentDirectory + "\\CSVPerson.csv")
                                        .Select(x => this.FromCsv(x))
                                        .ToList();
            return values;
        }
    }
}
