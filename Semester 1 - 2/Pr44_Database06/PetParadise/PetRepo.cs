using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PetParadise
{
    public class PetRepo
    {
        // Reads the database
        private readonly string ConnectionString;

        // Init pet as a list
        private List<Pet> pets;

        public PetRepo()
        {
            // Load all pet data from database via SQL statements and populate pet repository
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Ensures relative path works
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Creates the instance for pets class
            pets = new List<Pet>();

            // Our connection string to ou database to the appsettings file.
            ConnectionString = config.GetConnectionString("MyDBConnection");
        }

        public int Add(Pet pet)
        {
            // Add new pet to database and to repository
            // Return the database id of the pet

            int result = -1;

            // IMPLEMENT THIS!

            return result;
        }

        public List<Pet> GetAll()
        {
            List<Pet> result = new List<Pet>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PetId, Name, Type, Breed, DateOfBirth, Weight FROM PET ORDER BY PetId", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Pet pet = new Pet(dr.GetInt32(0))
                        {
                            Name = dr.GetString(1),
                            PetType = (PetType)Enum.Parse(typeof(PetType), dr.GetString(2)),
                            Breed = dr.GetString(3),
                            DateOfBirth = dr.IsDBNull(4) ? null : DateOnly.FromDateTime(dr.GetDateTime(4)),
                            Weight = dr.GetDouble(5)
                        };
                        result.Add(pet);
                    }
                }
            }

            return result;
        }

        public Pet GetById(int id)
        {
            Pet result = null;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PetId, Name, Type, Breed, DateOfBirth, Weight FROM PET WHERE PetId = @PetId", con);
                cmd.Parameters.Add("@PetId", SqlDbType.Int).Value = id;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        result = new Pet(dr.GetInt32(0))
                        {
                            Name = dr.GetString(1),
                            PetType = (PetType)Enum.Parse(typeof(PetType), dr.GetString(2)),
                            Breed = dr.GetString(3),
                            DateOfBirth = dr.IsDBNull(4) ? null : DateOnly.FromDateTime(dr.GetDateTime(4)),
                            Weight = dr.GetDouble(5)
                        };
                    }
                }
            }

            return result;
        }

        public void Update(Pet pet)
        {
            // Update existing pet on database

            // IMPLEMENT THIS!
        }

        public void Remove(Pet pet)
        {
            // Delete existing pet in database

            // IMPLEMENT THIS!
        }
    }
}
