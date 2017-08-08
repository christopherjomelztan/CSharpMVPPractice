using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Class
{
    public class PersonPresenter
    {
        IPersonModel _personModel;
        IPersonView _personView;

        public PersonPresenter(IPersonView personView)
        {
            _personView = personView;

            _personView.SelectedPersonChanged += _personView_SelectedPersonChanged;
        }

        private void _personView_SelectedPersonChanged(object sender, Events.SelectedPersonChangedArgs e)
        {
            _personModel = e.Person;
            _personView.ID = _personModel.ID;
            _personView.MyName = _personModel.Name;
        }
    }
}
