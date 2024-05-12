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


            List<Person> people = new List<Person>();
            BusinessPerson listpeoplea = new BusinessPerson();
            people = listpeoplea.GetPeopleByName(nombre);


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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Person newPerson = new Person()
            {
                Name = txtname.Text,
                Address = txtaddress.Text,
                Phone = txtcelular.Text 
            };

            BusinessPerson business = new BusinessPerson();
            business.AddNewPerson(newPerson);


            MessageBox.Show("Cliente añadido con éxito.");

        
            txtname.Text = "";
            txtaddress.Text = "";
            txtcelular.Text = "";

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtIdDelete.Text))
            {
 
                bool isNumeric = int.TryParse(txtIdDelete.Text, out int customerId);

                if (isNumeric)
                {

                    BusinessPerson business = new BusinessPerson();

                    business.DeletePerson(customerId);

   
                    MessageBox.Show("Cliente eliminado con éxito.");

                   
                    Button_Click(sender, e); 

              
                    txtIdDelete.Text = "";
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un ID válido.");
                }
            }
            else
            {
                MessageBox.Show("El campo de ID no puede estar vacío.");
            }
        }
    }
}