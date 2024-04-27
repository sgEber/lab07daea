using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Entity;

namespace lab07daea
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Person> people = new List<Person>();
            BusinessPerson listpeople = new BusinessPerson();
            people = listpeople.GetPeople();

            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Phone", typeof(string));

            foreach (var person in people)
            {
                dt.Rows.Add(person.PersonID, person.Name, person.Address, person.Phone);
            }

            CustomersTable.ItemsSource = dt.DefaultView;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;

            // Assuming you have a method to get people by name
            List<Person> people = new List<Person>();
            BusinessPerson listpeoplea = new BusinessPerson();
            people = listpeoplea.GetPeopleByName(nombre);

            // Create a DataTable and add columns (adjust column names as needed)
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Phone", typeof(string));

            // Populate the DataTable with people data
            foreach (var person in people)
            {
                dt.Rows.Add(person.PersonID, person.Name, person.Address, person.Phone);
            }

            // Set the DataGrid's ItemsSource to the DefaultView of the DataTable
            CustomersTable.ItemsSource = dt.DefaultView;
        }

    }
}