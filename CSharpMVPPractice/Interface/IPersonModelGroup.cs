using CSharpMVPPractice.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Interface
{
    public interface IPersonModelGroup
    {
        List<PersonModel> PersonModelGroupData(Interface.IDbConnection _dbConnection);
    }
}
