using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PetParadise
{
    public class TreatmentRepo
    {
        // Reads the database
        private readonly string ConnectionString;

        private List<Treatment> treatments;

        public TreatmentRepo()
        {
            // Load all treatment data from database via SQL statements and populate treatment repository
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Ensures relative path works
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Creates the instance for pets class
            treatments = new List<Treatment>();

            // Our connection string to ou database to the appsettings file.
            ConnectionString = config.GetConnectionString("MyDBConnection");
        }

        public int Add(Treatment treatment)
        {
            // Add new treatment to database and to repository
            // Return the database id of the treatment

            int result = -1;

            // IMPLEMENT THIS!

            return result;
        }

        public List<Treatment> GetAll()
        {
            List<Treatment> result = new List<Treatment>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TreatmentId, Service, Date, Charge FROM TREATMENT ORDER BY TreatmentId", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Treatment treatment = new Treatment(dr.GetInt32(0))
                        {
                            Service = dr.GetString(1),
                            Date = dr.IsDBNull(2) ? null : DateOnly.FromDateTime(dr.GetDateTime(2)),
                            Charge = dr.GetDouble(3)
                        };
                        result.Add(treatment);
                    }
                }
            }

            return result;
        }


        public Treatment GetById(int id)
        {
            Treatment result = null;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TreatmentId, Service, Date, Charge FROM TREATMENT WHERE TreatmentId = @TreatmentId", con);
                cmd.Parameters.Add("@TreatmentId", SqlDbType.Int).Value = id;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        result = new Treatment(dr.GetInt32(0))
                        {
                            Service = dr.GetString(1),
                            Date = dr.IsDBNull(2) ? null : DateOnly.FromDateTime(dr.GetDateTime(2)),
                            Charge = dr.GetDouble(3)
                        };
                    }
                }
            }

            return result;
        }

        public void Update(Treatment treatment)
        {
            // Update existing treatment on database

            // IMPLEMENT THIS!
        }

        public void Remove(Treatment treatment)
        {
            // Delete existing treatment in database

            // IMPLEMENT THIS!
        }
    }
}
