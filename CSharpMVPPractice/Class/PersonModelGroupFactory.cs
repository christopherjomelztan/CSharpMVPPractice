using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Class
{
    public class PersonModelGroupFactory
    {
        public IPersonModelGroup GetPersonModelGroup(string name)
        {
            switch(name)
            {
                case nameof(DatabasePersonModelGroup):
                    return new DatabasePersonModelGroup();
                case nameof(SamplePersonModelGroup):
                    return new SamplePersonModelGroup();
                case nameof(CSVPersonModelGroup):
                    return new CSVPersonModelGroup();
                default:
                    throw new NotImplementedException();
                    
            }
        }
    }
}
