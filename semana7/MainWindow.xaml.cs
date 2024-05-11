using Business;
using Entity;
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

namespace semana7
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

        private void boton_1(object sender, RoutedEventArgs e)
        {
            CustomerBusiness business = new CustomerBusiness();
            dgCustomers.ItemsSource= business.GetCustomers();
        }

        private void boton_insertar(object sender, RoutedEventArgs e)
        {
            // Crear un nuevo objeto Customer con los datos ingresados en la interfaz de usuario
            Customer newCustomer = new Customer
            {
                Name = txtName.Text, // Suponiendo que tienes un TextBox llamado txtNombre para ingresar el nombre del cliente
                Address = txtAddress.Text, // Suponiendo que tienes un TextBox llamado txtDireccion para ingresar la dirección del cliente
                Phone = txtPhone.Text, // Suponiendo que tienes un TextBox llamado txtTelefono para ingresar el teléfono del cliente
                Active = chkActive.IsChecked ?? false // Suponiendo que tienes un CheckBox llamado chkActivo para indicar si el cliente está activo
            };

            // Crear una instancia de la clase CustomerBusiness
            CustomerBusiness business = new CustomerBusiness();

            // Llamar al método InsertCustomer de CustomerBusiness para insertar el nuevo cliente
            business.InsertCustomer(newCustomer);

            // Actualizar la lista de clientes mostrada en el DataGrid después de insertar el nuevo cliente
            dgCustomers.ItemsSource = business.GetCustomers();
        }
    }
}