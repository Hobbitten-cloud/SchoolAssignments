using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ModelPersistence.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPersistence.Persistence
{
    public class SubjectRepo
    {
        // A list for subjects
        private List<Subject> subjects = new List<Subject>();

        // Reads the database
        private readonly string ConnectionString;

        public SubjectRepo()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Ensures relative path works
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ConnectionString = config.GetConnectionString("MyDBConnection");
        }

        // Creates a Subject
        public void Create(Subject subject)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Subject (Name, Level) " +
                     "VALUES(@Name,@Level)" +
                      "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = subject.Name ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@Level", SqlDbType.Int).Value = subject.Level ?? (object)DBNull.Value;
                    subject.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    subjects.Add(subject);
                }
            }
        }

        // Gets the specific Subject
        public Subject? GetById(int id)
        {
            Subject? subject = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, Level FROM Subject WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        subject = new Subject
                        {
                            Id = dr.GetInt32(0),
                            Name = dr["Name"] != DBNull.Value ? (string)dr["Name"] : null,
                            Level = dr["Level"] != DBNull.Value ? (int)dr["Level"] : null
                        };
                    }
                }
            }
            return subject;
        }

        // Gets all the Subject
        public List<Subject> RetrieveAll()
        {
            List<Subject> subjects = new List<Subject>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Name, Level, FROM Subject", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Subject subject = new Subject
                        {
                            Id = dr.GetInt32(0),
                            Name = dr["Name"] != DBNull.Value ? (string)dr["Name"] : null,
                            Level = dr["Level"] != DBNull.Value ? (int)dr["Level"] : null,
                        };
                        subjects.Add(subject);
                    }
                }
            }
            return subjects;
        }

        // Updates our information
        public void Update(Subject subject)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Substitute SET Name = @Name, " +
                    "Level = @Level WHERE Id = @Id", con);

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = subject.Name ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Level", SqlDbType.Int).Value = subject.Level ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = subject.Id;
                cmd.ExecuteNonQuery();
            }
        }

        // Deletes a Subject
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Subject WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
