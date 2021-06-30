using BugTracker.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;



namespace BugTracker.Services
{
    public class UsersDAO : IUserDataService
    {
        // sample data
        string connectionString = @"server=localhost;user id=root;database=bugtracker;password=Password";


        public int InsertEmail(string searchEmail)
        {

            int newId = -1;

            string sqlStatement = "INSERT INTO bugtracker.user (email) VALUES (@Email)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Email", searchEmail);

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

        public UserModel GetUserByEmail(string searchEmail)
        {
            UserModel foundUser = null;

            string sqlStatement = "SELECT * FROM bugtracker.user WHERE email LIKE @Email";

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

                    if (reader.HasRows)
                    {
                        foundUser = new UserModel
                        {
                            UserId = (int)reader[0],
                            EmailAddress = (string)reader[1],
                            FirstName = (string)reader[2],
                            LastName = (string)reader[3],
                            BirthDate = (DateTime)reader[4],
                            Role = (string)reader[5],
                            PhoneNumber = (string)reader[6]
                        };
                    }
                    else
                    {
                        InsertEmail(searchEmail);
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundUser;
        }
        

        public string GetUserRole(string searchEmail)
        {
            string foundRole = null;

            string sqlStatement = "SELECT role FROM bugtracker.user WHERE email LIKE @Email";

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

                    if (reader.HasRows)
                    {
                        foundRole = (string)reader[0];
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundRole;
        }


        public List<UserModel> GetAllUsers()
        {
            List<UserModel> foundUsers = new List<UserModel>();

            string sqlStatement = "SELECT * FROM user";

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
                        foundUsers.Add(new UserModel
                        {
                            UserId = (int)reader[0],
                            EmailAddress = (string)reader[1],
                            FirstName = (string)reader[2],
                            LastName = (string)reader[3],
                            BirthDate = (DateTime)reader[4],
                            Role = (string)reader[5],
                            PhoneNumber = (string)reader[6]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundUsers;
        }


        public UserModel GetUserById(int id)
        {
            UserModel foundUser = null;

            string sqlStatement = "SELECT * FROM bugtracker.user WHERE user_id = @Id";

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

                    if (reader.HasRows)
                    {
                        foundUser = new UserModel
                        {
                            UserId = (int)reader[0],
                            EmailAddress = (string)reader[1],
                            FirstName = (string)reader[2],
                            LastName = (string)reader[3],
                            BirthDate = (DateTime)reader[4],
                            Role = (string)reader[5],
                            PhoneNumber = (string)reader[6]
                        };
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return foundUser;
        }


        public int Update(UserModel user)
        {
            int newIdNumber = -1;

            string sqlStatement = "UPDATE user SET first_name = @FirstName, last_name = @LastName, " +
                "birthdate = @BirthDate, phone_number = @PhoneNumber, role = @Role WHERE user_id = @Id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // communicate with the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@BirthDate", user.BirthDate);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Id", user.UserId);

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


        public int UpdateRole(UserModel user)
        {
            int newIdNumber = -1;

            string sqlStatement = "UPDATE user SET role = @Role WHERE email = @EmailAddress";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Hier drin kann man schließlich mit der Datenbank interagieren
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);

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
