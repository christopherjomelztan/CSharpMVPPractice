using CSharpMVPPractice.Class;
using CSharpMVPPractice.Events;
using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;

namespace CSharpMVPPractice
{
    /// <summary>
    /// Interaction logic for Person.xaml
    /// </summary>
    public partial class Person : UserControl, IPersonView
    {
        private IReflectionUtility _refutil;
        private PersonModelGroupFactory _pf;
        private DbConnectionFactory _df;

        public event EventHandler<SelectedPersonChangedArgs> SelectedPersonChanged;
        public event EventHandler<PersonModelGroupChangedArgs> PersonModelGroupChanged;

        public Person()
        {
            _refutil = new ReflectionUtility();
            _pf = new PersonModelGroupFactory();
            _df = new DbConnectionFactory();
            InitializeComponent();
            PrepareCboConnectionType();
            LvwPersonBinding();
            
        }

        public int ID
        {
            get
            {
                return int.Parse(txtID.Text);
            }

            set
            {
                txtID.Text = value.ToString();
            }
        }
        public string MyName
        {
            get
            {
                return txtName.Text;
            }

            set
            {
                txtName.Text = value;
            }
        }

        public List<PersonModel> PersonModelList { get; set; }


        private void PrepareCboConnectionType()
        {
            foreach (IPersonModelGroup instance in _refutil.GetImplementations(typeof(IPersonModelGroup)))
            {
                if (!cboConnectionType.Items.Cast<string>().Contains(instance.GetType().Name))
                {
                    cboConnectionType.Items.Add(instance.GetType().Name);
                }
            }
            foreach (Interface.IDbConnection instance in _refutil.GetImplementations(typeof(Interface.IDbConnection)))
            {
                if (!cboDbConnection.Items.Cast<string>().Contains(instance.GetType().Name))
                {
                    cboDbConnection.Items.Add(instance.GetType().Name);
                }
            }
        }

        private void LvwPersonBinding()
        {
            var gridView = new GridView();
            this.lvwPerson.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "ID",
                DisplayMemberBinding = new Binding("ID")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
        }

        private void PrepareListView(List<PersonModel> personList)
        {
            lvwPerson.Items.Clear();
            foreach (PersonModel person in personList)
            {
                this.lvwPerson.Items.Add(person);
            }
        }

        private void lvwPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPersonChanged?.Invoke(this, new SelectedPersonChangedArgs { Person = (PersonModel)lvwPerson.SelectedItem });
        }

        private void cboConnectionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonModelGroupChanged?.Invoke(this, new PersonModelGroupChangedArgs { PersonGroup = _pf.GetPersonModelGroup(cboConnectionType.SelectedValue.ToString()) });
            PrepareListView(PersonModelList);
        }

        private void cboDbConnection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
