using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerBusiness
    {
        public List<Customer> GetCustomers()
        {
            List<Customer> customer = new List<Customer>();
            CustomerData data = new CustomerData();
            customer = data.GetCustomers();
            return customer;
        }
        public List<Customer> GetCustomerByName(string name)
        {
            List<Customer> customer = new List<Customer>();
            CustomerData data = new CustomerData();
            customer = data.GetCustomers();
            var result = customer.Where(x => x.Name.Contains(name)).ToList();
            return customer;
        }
        public void InsertCustomer(Customer customer)
        {
            // Crear una instancia de la clase CustomerData
            CustomerData data = new CustomerData();

            // Llamar al método InsertCustomer de CustomerData
            data.InsertCustomer(customer);
        }

    }
}
