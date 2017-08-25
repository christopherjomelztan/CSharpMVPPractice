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
        private IPersonModel _personModel;
        private IPersonView _personView;
        private IPersonModelGroup _personModelGroup;

        public PersonPresenter(IPersonView personView)
        {
            _personView = personView;
            _personView.SelectedPersonChanged += _personView_SelectedPersonChanged;
            _personView.PersonModelGroupChanged += _personView_PersonModelGroupChanged;
        }

        private void _personView_SelectedPersonChanged(object sender, Events.SelectedPersonChangedArgs e)
        {
            _personModel = e.Person;
            _personView.ID = _personModel.ID;
            _personView.MyName = _personModel.Name;
        }
        private void _personView_PersonModelGroupChanged(object sender, Events.PersonModelGroupChangedArgs e)
        {
            _personModelGroup = e.PersonGroup;
            _personView.PersonModelList = _personModelGroup.PersonModelGroupData();
        }
    }
}
