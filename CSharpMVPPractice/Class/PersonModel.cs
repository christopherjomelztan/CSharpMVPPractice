using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Class
{
    public class PersonModel : IPersonModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
