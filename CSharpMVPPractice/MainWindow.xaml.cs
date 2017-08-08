using CSharpMVPPractice.Class;
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

namespace CSharpMVPPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PersonModel personModel = new PersonModel() { ID = 1, Name = "Name1" };
            PersonPresenter personPresenter = new PersonPresenter(personModel, new PersonView(this));
            PrepareListView();

        }

        private void PrepareListView()
        {
            List<PersonModel> personList = new List<PersonModel>();
            personList.Add(new PersonModel() { ID = 1, Name = "Name1" });
            personList.Add(new PersonModel() { ID = 2, Name = "Name2" });
            personList.Add(new PersonModel() { ID = 3, Name = "Name3" });

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
            foreach (PersonModel person in personList)
            {
                this.lvwPerson.Items.Add(person);
            }
        }

        public string TxtID
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }
        public string TxtName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        private void lvwPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonModel person;
            person = (PersonModel)lvwPerson.SelectedItem;
            PersonPresenter personPresenter = new PersonPresenter(person, new PersonView(this));
        }
    }
}
