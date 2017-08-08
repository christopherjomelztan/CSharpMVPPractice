using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Class
{
    public class PersonView : IPersonView
    {
        private MainWindow _mainWindow;
        public PersonView(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public int ID
        {
            get
            {
                return int.Parse(_mainWindow.txtID.Text);
            }

            set
            {
                _mainWindow.txtID.Text = value.ToString();
            }
        }

        public string Name
        {
            get
            {
                return _mainWindow.txtName.Text;
            }

            set
            {
                _mainWindow.txtName.Text = value;
            }
        }
    }
}
