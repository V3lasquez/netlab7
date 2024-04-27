using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
        public class PersonData
        {
        public List<Person> GetPeople()
        {
            string connectionString = "Data Source=LAB1504-25\\SQLEXPRESS;Initial Catalog=NeptunoDB;User Id=userTecsup;Password=userTecsup03;TrustServerCertificate=true";

            List<Person> people = new List<Person>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person
                    {
                        PersonId = Convert.ToInt32(reader["ID"]),
                        Age = Convert.ToInt32(reader["Age"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                    people.Add(person);
                }
                reader.Close();
            }

            return people;
        }
        public void Insert()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }


    }
}
