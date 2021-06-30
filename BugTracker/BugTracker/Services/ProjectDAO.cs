using BugTracker.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public class ProjectDAO : IProjectDataService
    {
        // sample data
        string connectionString = @"server=localhost;user id=root;database=bugtracker;password=Password";
        

        // "Meine Projekte" - Index
        public List<ProjectModel> GetAllProjects()
        {
            List<ProjectModel> foundProjects = new List<ProjectModel>();

            string sqlStatement = "SELECT * FROM project";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProjects.Add(new ProjectModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Description = (string)reader[2],
                            StartTime = (DateTime)reader[3]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundProjects;
        }


        // "Meine Projekte" - details - left table
        public List<UserModel> GetAllWorkingOnProject(int id)
        {
            List<UserModel> foundData = new List<UserModel>();

            string sqlStatement = "SELECT email, CONCAT(first_name, ' ', last_name) AS Name, role" +
                " FROM user JOIN ticket ON dev_id = user_id WHERE project_id = @ProjectId;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ProjectId", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundData.Add(new UserModel
                        {
                            EmailAddress = (string)reader[0],
                            FullName = (string)reader[1],
                            Role = (string)reader[2]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundData;
        }


        // "Meine Projekte" - details - right table
        public List<TicketModel> GetAllTicketsByProject(int id)
        {
            List<TicketModel> foundTickets = new List<TicketModel>();

            string sqlStatement = "SELECT t.ticket_id, t.ticket_name, CONCAT(u.first_name, ' ', u.last_name) AS SubmitterName," +
                " concat(uu.first_name, ' ', uu.last_name) AS DevName, t.ticket_status, t.ticket_start FROM ticket t" +
                " JOIN user u ON u.user_id = t.submitter_id JOIN user uu ON uu.user_id = t.dev_id WHERE t.project_id = @ProjectId;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ProjectId", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundTickets.Add(new TicketModel
                        {
                            TicketId = (int)reader[0],
                            TicketName = (string)reader[1],
                            Submitter = (string)reader[2],
                            Dev = (string)reader[3],
                            TicketStatus = (string)reader[4],
                            TicketStart = (DateTime)reader[5]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundTickets;
        }


        public ProjectModel GetProjectById(int id)
        {
            ProjectModel foundProject = null;

            string sqlStatement = "SELECT * FROM project WHERE project_id = @Id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    foundProject = new ProjectModel
                    {
                        Id = (int)reader[0],
                        Name = (string)reader[1],
                        Description = (string)reader[2],
                        StartTime = (DateTime)reader[3]
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundProject;
        }


        public int Insert(ProjectModel project)
        {
            int newId = -1;

            string sqlStatement = "INSERT INTO project(project_name, project_description) VALUES (@Name, @Description); SELECT LAST_INSERT_ID();";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", project.Name);
                command.Parameters.AddWithValue("@Description", project.Description);

                try
                {
                    connection.Open();

                    // Was auch geht: newId = command.ExecuteNonQuery();
                    newId = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return newId;
        }


        public bool Delete(ProjectModel project)
        {
            int newIdNumber = -1;

            string sqlStatement = "DELETE FROM project WHERE project_id = @Id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", project.Id);

                try
                {
                    connection.Open();

                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return (newIdNumber > 0);
        }


        public int Update(ProjectModel project)
        {
            int newIdNumber = -1;

            string sqlStatement = "UPDATE project SET project_name = @Name, project_description = @Description WHERE project_id = @Id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", project.Name);
                command.Parameters.AddWithValue("@Description", project.Description);
                command.Parameters.AddWithValue("@Id", project.Id);

                try
                {
                    connection.Open();

                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return newIdNumber;
        }


    }
}
