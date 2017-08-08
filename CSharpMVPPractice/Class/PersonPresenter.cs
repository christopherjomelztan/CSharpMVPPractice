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

        public PersonPresenter(IPersonModel personModel, IPersonView personView)
        {
            _personModel = personModel;
            _personView = personView;

            _personView.ID = _personModel.ID;
            _personView.Name = _personModel.Name;
        }

        public void UpdateModel()
        {
            _personModel.ID = _personView.ID;
            _personModel.Name = _personView.Name;
        }
    }
}
