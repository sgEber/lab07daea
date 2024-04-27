using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class PersonData
    {
        public List<Person> GetPeople()
        {
            string connectionString = "Data Source=EBER\\SQLEXPRESS; Initial Catalog=FacturaDB ;User Id=angel; Password=123456;";
            string uspp = "USPListCustomer";
            List<Person> persons = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(uspp, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person person = new Person
                            {
                                PersonID = Convert.ToInt32(reader["customer_id"]),
                                Name = reader["name"].ToString(),
                                Address = reader["address"].ToString(),
                                Phone = reader["phone"].ToString(),

                            };
                            persons.Add(person);
                        }
                    }
                }
                return persons;
            }
        }


        public void Insert() { }

        public void Update() { }

        public void Delete() { }

    }
}
