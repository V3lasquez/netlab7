using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerData
    {
        public List<Customer> GetCustomers()
        {
            string connectionString = "Data Source=LAB1504-17\\SQLEXPRESS;Initial Catalog=FacturaDB;User Id=userTecsup;Password=userTecsup03";

            List<Customer> customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("ListCustomers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        CustomerId = Convert.ToInt32(reader["customer_id"]),
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Active = Convert.ToBoolean(reader["active"])
                    };
                    customers.Add(customer);
                }
                reader.Close();
            }

            return customers;
        }



       
            private string connectionString = "Data Source=LAB1504-17\\SQLEXPRESS;Initial Catalog=FacturaDB;User Id=userTecsup;Password=userTecsup03";

            public void InsertCustomer(Customer customer)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("InsertCustomerProcedure", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@Active", customer.Active);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores
                        Console.WriteLine("Error al insertar cliente: " + ex.Message);
                    }
                }
            }
    }
}
