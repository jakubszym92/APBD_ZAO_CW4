using APBD_ZAO_CW4.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace APBD_ZAO_CW4.DAL
{
    public class DbService : IDbService
    {
        private readonly string connectionString = "Data Source=db-mssql;Initial Catalog=s20289;Integrated Security=True";
        private IConfiguration _configuration;
        public DbService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CheckAnimalById(int idAnimal)
        {
            using (SqlConnection connection = new(connectionString))
            {
                using SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from Animal where IdAnimal like @idAnimal", connection);
                connection.Open();
                sqlCommand.Parameters.AddWithValue("@idAnimal", idAnimal);
                int userCount = (int)sqlCommand.ExecuteScalar();
                if (userCount > 0)
                    return true;
            }
            return false;
        }

        public void ChangeAnimal(int idAnimal, Animal animal)
        {

            using SqlConnection connection = new(connectionString);
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "INSERT INTO Animal (Name, Description, Category, Area) VALUES( '" + animal.Name + "','" + animal.Description + "','" + animal.Area + "','" + animal.Category + "')"
            };
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

       

        public void CreateAnimal(Animal animal)
        {
           
            using SqlConnection connection = new(connectionString);
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "UPDATE Animal SET Name = '" + animal.Name + "', Description = '" + animal.Description + "', Area = '" + animal.Area + "', Category = '" + animal.Category + "' WHERE IdAnimal = '" + animal.IdAnimal + "'"
            };
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            
        }

        public void DeleteAnimal(int idAnimal)
        {
            using SqlConnection connection = new(connectionString);
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "DELETE FROM Animal WHERE IdAnimal = '" + idAnimal + "'"
            };
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Animal> GetAnimals(string orderBy)
        {
            var animals = new List<Animal>();
            
            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new()
                {
                    Connection = connection
                };
                if (orderBy != null)
                    command.CommandText = "SELECT * FROM Animal ORDER BY " + orderBy;
                else command.CommandText = "SELECT * FROM Animal ORDER BY name";
                connection.Open();



                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    animals.Add(new Animal
                    {
                        IdAnimal = int.Parse(dr["IdAnimal"].ToString()),
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Category = dr["Category"].ToString(),
                        Area = dr["Area"].ToString()
                    });

                }

                connection.Close();
            }            


            return animals;
        }
    }
}
