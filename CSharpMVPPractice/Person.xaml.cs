using CSharpMVPPractice.Class;
using CSharpMVPPractice.Events;
using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace CSharpMVPPractice
{
    /// <summary>
    /// Interaction logic for Person.xaml
    /// </summary>
    public partial class Person : UserControl, IPersonView
    {
        IPersonModelGroup pg = new PersonModelGroup();
        public Person()
        {
            InitializeComponent();
            LvwPersonBinding();
            PrepareListView(pg.PersonModelGroupData(new MySqlDbConnection()));
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

        public event EventHandler<SelectedPersonChangedArgs> SelectedPersonChanged;

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
            foreach (PersonModel person in personList)
            {
                this.lvwPerson.Items.Add(person);
            }
        }

        private void lvwPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPersonChanged?.Invoke(this, new SelectedPersonChangedArgs { Person = (PersonModel)lvwPerson.SelectedItem });
        }
    }
}
