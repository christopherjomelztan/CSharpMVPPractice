using CSharpMVPPractice.Class;
using CSharpMVPPractice.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Interface
{
    public interface IPersonView
    {
        int ID { get; set; }
        string MyName { get; set; }

        List<PersonModel> PersonModelList { get; set; }

        event EventHandler<SelectedPersonChangedArgs> SelectedPersonChanged;
        event EventHandler<PersonModelGroupChangedArgs> PersonModelGroupChanged;
    }
}
