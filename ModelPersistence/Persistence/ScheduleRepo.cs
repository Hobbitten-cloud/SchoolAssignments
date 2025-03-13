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
    public class ScheduleRepo
    {
        // A list for Schedule
        private List<Schedule> schedules = new List<Schedule>();

        // Reads the database
        private readonly string ConnectionString;

        public ScheduleRepo()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Ensures relative path works
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ConnectionString = config.GetConnectionString("MyDBConnection");
        }

        // Creates a Schedule
        public void Create(Schedule schedule)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Schedule (Date, Avaliability) " +
                     "VALUES(@Date,@Avaliability)" +
                      "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = schedule.Date ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@Avaliability", SqlDbType.Int).Value = schedule.Avaliability ?? (object)DBNull.Value;
                    schedule.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    schedules.Add(schedule);
                }
            }
        }

        // Gets the specific Schedule
        public Schedule? GetById(int id)
        {
            Schedule? schedule = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Date, Avaliability FROM Schedule WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        schedule = new Schedule
                        {
                            Id = dr.GetInt32(0),
                            Date = dr["Date"] != DBNull.Value ? (DateOnly)dr["Date"] : null,
                            Avaliability = dr["Avaliability"] != DBNull.Value ? (Avaliability)(int)dr["Avaliability"] : null
                        };
                    }
                }
            }
            return schedule;
        }

        // Gets all the Schedules
        public List<Schedule> RetrieveAll()
        {
            List<Schedule> schedules = new List<Schedule>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Date, Avaliability, FROM Schedule", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Schedule schedule = new Schedule
                        {
                            Id = dr.GetInt32(0),
                            Date = dr["Date"] != DBNull.Value ? (DateOnly)dr["Date"] : null,
                            Avaliability = dr["Avaliability"] != DBNull.Value ? (Avaliability)(int)dr["Avaliability"] : null
                        };
                        schedules.Add(schedule);
                    }
                }
            }
            return schedules;
        }

        // Updates our information
        public void Update(Schedule schedule)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Substitute SET Date = @Date, " +
                    "Avaliability = @Avaliability WHERE Id = @Id", con);

                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = schedule.Date ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Avaliability", SqlDbType.Int).Value = schedule.Avaliability ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = schedule.Id;
                cmd.ExecuteNonQuery();
            }
        }

        // Deletes a Schedule
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Schedule WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
