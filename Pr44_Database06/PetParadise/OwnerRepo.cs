using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace PetParadise
{
    public class OwnerRepo
    {
        // Reads the database
        private readonly string ConnectionString;

        // Init an owner list
        private List<Owner> owners;

        public OwnerRepo()
        {
            // Load all owner data from database via SQL statements and populate owner repository
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Ensures relative path works
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Creates the instance for owner class
            owners = new List<Owner>();

            // Our connection string to ou database to the appsettings file.
            ConnectionString = config.GetConnectionString("MyDBConnection");
        }

        //public int Add(Owner owner)
        //{
        //    //// Add new owner to database and to repository
        //    //// Return the database id of the owner

        //    //int result = -1;

        //    //using (SqlConnection con = new SqlConnection(ConnectionString))
        //    //{
        //    //    con.Open();
        //    //    using (SqlCommand cmd = new SqlCommand("INSERT INTO OWNER (FirstName, LastName, Phone, Email)" +
        //    //         "VALUES(@FirstName, @LastName, @Phone, @Email)" +
        //    //          "SELECT @@IDENTITY", con))
        //    //    {
        //    //        // Details to be added
        //    //        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = owner.FirstName;
        //    //        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = owner.LastName;
        //    //        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = owner.Phone;
        //    //        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = owner.Email;

        //    //        // Executes the query
        //    //        cmd.ExecuteNonQuery();

        //    //        // Adds the owner to our list
        //    //        owners.Add(owner);
        //    //    }
        //    //}

        //    //return result;
        //}

        public List<Owner> GetAll()
        {
            List<Owner> owners = new List<Owner>();

            // Retrieves all of our Owners and addes them to our list
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT OwnerId, FirstName, LastName, Phone, Email FROM OWNER ORDER BY OwnerId", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Owner owner = new Owner(dr.GetInt32(0))
                        {
                            FirstName = dr.GetString(1),
                            LastName = dr.GetString(2),
                            Phone = dr.IsDBNull(3) ? null : dr.GetString(3), // Ternary for checking if the value is null or not
                            Email = dr.GetString(4)
                        };
                        owners.Add(owner);
                    }
                }
            }
            return owners;
        }

        public Owner GetById(int id)
        {
            Owner? owner = null;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                // Filter for the specific OwnerId
                SqlCommand cmd = new SqlCommand("SELECT OwnerId, FirstName, LastName, Phone, Email FROM OWNER WHERE OwnerId = @OwnerId", con);
                cmd.Parameters.Add("@OwnerId", SqlDbType.Int).Value = id;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        owner = new Owner(dr.GetInt32(0))
                        {
                            FirstName = dr.GetString(1),
                            LastName = dr.GetString(2),
                            Phone = dr.IsDBNull(3) ? null : dr.GetString(3),
                            Email = dr.GetString(4)
                        };
                    }
                }
            }
            return owner;
        }

        public void Update(Owner owner)
        {
            //// Update existing owner on database

            //using (SqlConnection con = new SqlConnection(ConnectionString))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand(
            //        "UPDATE Car SET Make = @Make, Model = @Model, Year = @Year, Description = @Description WHERE Id = @Id",
            //        con);

            //    cmd.Parameters.Add("@Make", SqlDbType.NVarChar).Value = carToBeUpdated.Make;
            //    cmd.Parameters.Add("@Model", SqlDbType.NVarChar).Value = carToBeUpdated.Model;
            //    cmd.Parameters.Add("@Year", SqlDbType.Int).Value = carToBeUpdated.Year;
            //    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = carToBeUpdated.Description;
            //    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = carToBeUpdated.Id;
            //    cmd.ExecuteNonQuery();
            //}

        }

        public void Remove(Owner owner)
        {
            //// Delete existing owner in database
            //using (SqlConnection con = new SqlConnection(ConnectionString))
            //{
            //    // Opens the connection to our database
            //    con.Open();

            //    // With the usage of @ we can protect against SQL-Injection
            //    SqlCommand cmd = new SqlCommand("DELETE FROM OWNER WHERE OwnerId = @OwnerId", con);
            //    cmd.Parameters.AddWithValue("@OwnerId", owner);

            //    // Executes our query to the database with what our local variable "cmd" holds
            //    cmd.ExecuteNonQuery();
            //}
        }

    }
}
