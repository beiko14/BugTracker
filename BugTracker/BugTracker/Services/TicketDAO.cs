using BugTracker.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public class TicketDAO : ITicketDataService
    {
        // sample data
        string connectionString = @"server=localhost;user id=root;database=bugtracker;password=Password";


        public List<CommentModel> GetAllCommentsByTicketId(int id)
        {
            List<CommentModel> comment = new List<CommentModel>();

            string sqlStatement = "SELECT comment.text, user.email, comment.date FROM comment JOIN user" +
                " ON user.user_id = comment.user_id WHERE comment.ticket_id = @TicketId;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@TicketId", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comment.Add(new CommentModel
                        {
                            CommentText = (string)reader[0],
                            Email = (string)reader[1],
                            CommentStart = (DateTime)reader[2]
                        });
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return comment;
        }


        public List<TicketModel> GetAllTickets()
        {
            List<TicketModel> foundTickets = new List<TicketModel>();

            string sqlStatement = "SELECT ticket.ticket_id, ticket.ticket_name, ticket.ticket_type, ticket.ticket_description," +
                " ticket.ticket_status, ticket.ticket_priority, ticket.ticket_start, project.project_name, user.email " +
                "FROM bugtracker.ticket JOIN project ON project.project_id = ticket.project_id JOIN user ON user.user_id = ticket.dev_id";

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
                        foundTickets.Add(new TicketModel
                        {
                            TicketId = (int)reader[0],
                            TicketName = (string)reader[1],
                            TicketType = (string)reader[2],
                            TicketDescription = (string)reader[3],
                            TicketStatus = (string)reader[4],
                            TicketPriority = (string)reader[5],
                            TicketStart = (DateTime)reader[6],
                            ProjectName = (string)reader[7],
                            Dev = (string)reader[8]
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


        public List<TicketModel> GetYourTickets(string email)
        {
            List<TicketModel> foundTickets = new List<TicketModel>();

            string sqlStatement = "SELECT ticket.ticket_id, ticket.ticket_name, ticket.ticket_type, ticket.ticket_description," +
                " ticket.ticket_status, ticket.ticket_priority, ticket.ticket_start, project.project_name, user.email " +
                "FROM bugtracker.ticket JOIN project ON project.project_id = ticket.project_id JOIN user ON user.user_id = ticket.dev_id " +
                "WHERE user.email = @Dev";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Dev", email);

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
                            TicketType = (string)reader[2],
                            TicketDescription = (string)reader[3],
                            TicketStatus = (string)reader[4],
                            TicketPriority = (string)reader[5],
                            TicketStart = (DateTime)reader[6],
                            ProjectName = (string)reader[7],
                            Dev = (string)reader[8]
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


        public List<TicketModel> GetAllTicketsById(int id)
        {
            throw new NotImplementedException();
        }


        public TicketModel GetTicketById(int id)
        {
            TicketModel foundTicket = null;

            string sqlStatement = "SELECT ticket.ticket_id, ticket.ticket_name, ticket.ticket_type, ticket.ticket_description," +
                " ticket.ticket_status, ticket.ticket_priority, ticket.ticket_start, project.project_name, user.email FROM" +
                " bugtracker.ticket JOIN project ON project.project_id = ticket.project_id JOIN user ON user.user_id = ticket.dev_id" +
                " WHERE ticket_id = @TicketId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@TicketId", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    foundTicket = new TicketModel
                    {
                        TicketId = (int)reader[0],
                        TicketName = (string)reader[1],
                        TicketType = (string)reader[2],
                        TicketDescription = (string)reader[3],
                        TicketStatus = (string)reader[4],
                        TicketPriority = (string)reader[5],
                        TicketStart = (DateTime)reader[6],
                        ProjectName = (string)reader[7],
                        Dev = (string)reader[8]
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundTicket;
        }


        public int GetSubmitterIdByEmail(string searchEmail)
        {
            int foundUserId = 0;

            string sqlStatement = "SELECT user.user_id FROM user WHERE user.email = @Email;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Email", searchEmail);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    foundUserId = (int)reader[0];

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundUserId;
        }


        public int Insert(TicketModel ticket)
        {
            int newId = -1;

            string sqlStatement = "INSERT INTO ticket (ticket_name, ticket_type, ticket_description, ticket_status, ticket_priority, project_id, submitter_id, dev_id)" +
                " SELECT @TicketName, @TicketType, @TicketDescription, @TicketStatus, @TicketPriority, project.project_id, @SubmitterId, user.user_id" +
                " FROM user" +
                " CROSS JOIN project" +
                " WHERE project.project_name LIKE @ProjectName" +
                " AND email = @Dev;" +
                " SELECT LAST_INSERT_ID();"; //returns the created ticket_id

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@TicketName", ticket.TicketName);
                command.Parameters.AddWithValue("@TicketType", ticket.TicketType);
                command.Parameters.AddWithValue("@TicketDescription", ticket.TicketDescription);
                command.Parameters.AddWithValue("@TicketStatus", ticket.TicketStatus);
                command.Parameters.AddWithValue("@TicketPriority", ticket.TicketPriority);
                command.Parameters.AddWithValue("@ProjectName", ticket.ProjectName);
                command.Parameters.AddWithValue("@SubmitterId", ticket.SubmitterId);
                command.Parameters.AddWithValue("@Dev", ticket.Dev);

                try
                {
                    connection.Open();

                    // also possible: newId = command.ExecuteNonQuery();
                    newId = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return newId;
        }


        public int InsertComment(TicketModel ticket)
        {
            int newId = ticket.TicketId;

            string sqlStatement = "INSERT INTO comment (text, user_id, ticket_id) SELECT @CommentInput, user.user_id, @TicketId" +
                " FROM user WHERE user_id = @SubmitterId;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@CommentInput", ticket.CommentInput);
                command.Parameters.AddWithValue("@TicketId", ticket.TicketId);
                command.Parameters.AddWithValue("@SubmitterId", ticket.SubmitterId);

                try
                {
                    connection.Open();

                    // also possible: newId = command.ExecuteNonQuery();
                    Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return newId;
        }


        public bool Delete(TicketModel ticket)
        {
            int newIdNumber = -1;

            string sqlStatement = "DELETE FROM ticket WHERE ticket_id = @TicketId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@TicketId", ticket.TicketId);

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


        public int Update(TicketModel ticket)
        {
            int newIdNumber = -1;

            string sqlStatement = "UPDATE ticket SET ticket_name = @TicketName, ticket_type = @TicketType," +
                " ticket_description = @TicketDescription, ticket_status = @TicketStatus, ticket_priority = @TicketPriority," +
                " dev_id = (SELECT user.user_id FROM user WHERE user.email = @Dev) WHERE ticket_id = @TicketId;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@TicketName", ticket.TicketName);
                command.Parameters.AddWithValue("@TicketType", ticket.TicketType);
                command.Parameters.AddWithValue("@TicketDescription", ticket.TicketDescription);
                command.Parameters.AddWithValue("@TicketStatus", ticket.TicketStatus);
                command.Parameters.AddWithValue("@TicketPriority", ticket.TicketPriority);
                command.Parameters.AddWithValue("@Dev", ticket.Dev);
                command.Parameters.AddWithValue("@TicketId", ticket.TicketId);

                try
                {
                    connection.Open();

                    Convert.ToInt32(command.ExecuteScalar());
                    newIdNumber = ticket.TicketId;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return newIdNumber;
        }

        public List<string> GetAllProjectNames()
        {
            List<string> projectNameList = new List<string>();

            string sqlStatement = "SELECT project_name FROM project;";

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
                        if (!reader.IsDBNull(0))
                            projectNameList.Add(reader.GetString(0));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return projectNameList;
        }

        public List<string> GetAllDevs()
        {
            List<string> devList = new List<string>();

            string sqlStatement = "SELECT email FROM user;";

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
                        if (!reader.IsDBNull(0))
                            devList.Add(reader.GetString(0));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return devList;
        }


        public List<TicketModel> GetTicketHistoryById(int id)
        {
            List<TicketModel> foundTicketHistory = new List<TicketModel>();

            string sqlStatement = "SELECT dt_datetime AS 'Änderungsdatum', ticket_name AS Name, ticket_description AS Beschreibung," +
                " ticket_status AS Status, ticket_type AS Typ, ticket_priority AS Priorisierung, user.email AS Entwickler" +
                " FROM ticket_history JOIN user ON dev_id = user.user_id WHERE ticket_id = @TicketId;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@TicketId", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundTicketHistory.Add(new TicketModel
                        {
                            TicketStart = (DateTime)reader[0],
                            TicketName = (string)reader[1],
                            TicketDescription = (string)reader[2],
                            TicketStatus = (string)reader[3],
                            TicketType = (string)reader[4],
                            TicketPriority = (string)reader[5],
                            Dev = (string)reader[6]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundTicketHistory;
        }
    }
}
