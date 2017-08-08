using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Events
{
    public class SelectedPersonChangedArgs : EventArgs
    {
        public IPersonModel Person { get; set; }
    }
}
