using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ModelPersistence.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ModelPersistence.Persistence
{
    public class SubstituteRepo
    {
        // A list for substitutes
        private List<Substitute> Substitutes = new List<Substitute>();

        // Reads the database
        private readonly string ConnectionString;

        public SubstituteRepo()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Ensures relative path works
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ConnectionString = config.GetConnectionString("MyDBConnection");
        }

        // Creates a Substitute
        public void Create(Substitute substitute)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Substitute (Name, Email, Region, " +
                    "Phone, PersonNumber, Verified) " +
                     "VALUES(@Name,@Model,@Email,@Region,@Phone,@PersonNumber,@Verified)" +
                      "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = substitute.Name ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = substitute.Email ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@Region", SqlDbType.NVarChar).Value = substitute.Region ?? (object?)DBNull.Value;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = substitute.Phone ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@PersonNumber", SqlDbType.NVarChar).Value = substitute.PersonNumber ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@Verified", SqlDbType.Bit).Value = substitute.Verified ?? (object)DBNull.Value;
                    substitute.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    Substitutes.Add(substitute);
                }
            }
        }

        // Gets the specific Substitute
        public Substitute? GetById(int id)
        {
            Substitute? substitute = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, Email, Region, " +
                    "Phone, PersonNumber, Verified FROM Substitute WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        substitute = new Substitute
                        {
                            Id = dr.GetInt32(0),
                            Name = dr["Name"] != DBNull.Value ? (string)dr["Name"] : null,
                            Email = dr["Email"] != DBNull.Value ? (string)dr["Email"] : null,
                            Region = dr["Region"] != DBNull.Value ? (string?)dr["Region"] : null,
                            Phone = dr["Phone"] != DBNull.Value ? (string)dr["Phone"] : null,
                            PersonNumber = dr["PersonNumber"] != DBNull.Value ? (string)dr["PersonNumber"] : null,
                            Verified = dr["Verified"] != DBNull.Value ? (bool)dr["Verified"] : null
                        };
                    }
                }
            }
            return substitute;
        }

        // Gets all the Substitutes
        public List<Substitute> RetrieveAll()
        {
            List<Substitute> substitutes = new List<Substitute>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, Email, Region, Phone, PersonNumber, Verified FROM Substitute", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Substitute substitute = new Substitute
                        {
                            Id = dr.GetInt32(0),
                            Name = dr["Name"] != DBNull.Value ? (string)dr["Name"] : null,
                            Email = dr["Email"] != DBNull.Value ? (string)dr["Email"] : null,
                            Region = dr["Region"] != DBNull.Value ? (string?)dr["Region"] : null,
                            Phone = dr["Phone"] != DBNull.Value ? (string)dr["Phone"] : null,
                            PersonNumber = dr["PersonNumber"] != DBNull.Value ? (string)dr["PersonNumber"] : null,
                            Verified = dr["Verified"] != DBNull.Value ? (bool)dr["Verified"] : null
                        };
                        substitutes.Add(substitute);
                    }
                }
            }
            return substitutes;
        }

        // Updates our information
        public void Update(Substitute substitute)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Substitute SET Name = @Name, " +
                    "Email = @Email, " +
                    "Region = @Region, " +
                    "Phone = @Phone, " +
                    "PersonNumber = @PersonNumber, " +
                    "Verified = @Verified WHERE Id = @Id",
                    con);

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = substitute.Name ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = substitute.Email ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Region", SqlDbType.NVarChar).Value = substitute.Region ?? (object?)DBNull.Value;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = substitute.Phone ?? (object)DBNull.Value;
                cmd.Parameters.Add("@PersonNumber", SqlDbType.NVarChar).Value = substitute.PersonNumber ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Verified", SqlDbType.Bit).Value = substitute.Verified ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = substitute.Id;
                cmd.ExecuteNonQuery();
            }
        }

        // Deletes a Substitute
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Substitute WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
