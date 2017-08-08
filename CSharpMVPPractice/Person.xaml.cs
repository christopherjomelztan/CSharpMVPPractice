using CSharpMVPPractice.Class;
using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CSharpMVPPractice.Events;

namespace CSharpMVPPractice
{
    /// <summary>
    /// Interaction logic for Person.xaml
    /// </summary>
    public partial class Person : UserControl, IPersonView
    {
        public Person()
        {
            InitializeComponent();
            LvwPersonBinding();
            PrepareListView(SampleData());
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

        public IEnumerable<IPersonModel> Persons
        {
            get
            {
                return lvwPerson.Items.OfType<PersonModel>();
            }
        }

        public event EventHandler<SelectedPersonChangedArgs> SelectedPersonChanged;

        private List<PersonModel> SampleData()
        {
            List<PersonModel> personList = new List<PersonModel>();
            personList.Add(new PersonModel() { ID = 1, Name = "Name1" });
            personList.Add(new PersonModel() { ID = 2, Name = "Name2" });
            personList.Add(new PersonModel() { ID = 3, Name = "Name3" });
            personList.Add(new PersonModel() { ID = 4, Name = "Name4" });
            personList.Add(new PersonModel() { ID = 5, Name = "Name5" });
            personList.Add(new PersonModel() { ID = 6, Name = "Name6" });
            return personList;
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
