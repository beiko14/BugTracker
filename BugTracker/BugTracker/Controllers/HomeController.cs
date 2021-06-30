using BugTracker.Models;
using BugTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class HomeController : BaseController
    {
        //sample data
        string connectionString = @"server=localhost;user id=root;database=bugtracker;password=Password";

        // use dependency injection. See startup.cs to see the data source for repository
        // ProductsDAO repository;
        public IUserDataService repository { get; set; }

        public HomeController(IUserDataService dataService)
        {
            repository = dataService;
            // repository = new ProductsDAO();
        }

        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        // if email is empty, save the email from Auth0
        [Authorize]
        public IActionResult Index()
        {
            UserModel foundUser = repository.GetUserByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);
            return View();
        }

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetTicketPriorityCount()
        {
            string[] ticketPriorityCount = new string[4];

            string sqlStatement = "SELECT COUNT(ticket_priority) as High, (select count(ticket_priority) from ticket where" +
                " ticket_priority LIKE 'Medium') as Medium, (select count(ticket_priority) from ticket where ticket_priority LIKE 'Low') as Low," +
                " (select count(*) from ticket where ticket_priority is null) as None from ticket where ticket_priority LIKE 'High';";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlStatement, connection);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter cmd1 = new MySqlDataAdapter(cmd);
                    cmd1.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        ticketPriorityCount[0] = "0";
                        ticketPriorityCount[1] = "0";
                        ticketPriorityCount[2] = "0";
                        ticketPriorityCount[3] = "0";
                    }
                    else
                    {
                        ticketPriorityCount[0] = dt.Rows[0]["High"].ToString();
                        ticketPriorityCount[1] = dt.Rows[0]["Medium"].ToString();
                        ticketPriorityCount[2] = dt.Rows[0]["Low"].ToString();
                        ticketPriorityCount[3] = dt.Rows[0]["None"].ToString();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Json(new { ticketPriorityCount });
        }


        public JsonResult GetTicketStatusCount()
        {
            string[] ticketStatusCount = new string[4];

            string sqlStatement = "SELECT COUNT(*) as Open, (select count(*) from ticket where ticket_status like 'In Progress')" +
                " as inProgress, (select count(*) from ticket where ticket_status like 'Additional Info Required') as AdditionalInfo," +
                " (select count(*) from ticket where ticket_status like 'Resolved') as Resolved from ticket" +
                " where ticket_status like 'Open';";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlStatement, connection);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter cmd1 = new MySqlDataAdapter(cmd);
                    cmd1.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        ticketStatusCount[0] = "0";
                        ticketStatusCount[1] = "0";
                        ticketStatusCount[2] = "0";
                        ticketStatusCount[3] = "0";
                    }
                    else
                    {
                        ticketStatusCount[0] = dt.Rows[0]["Open"].ToString();
                        ticketStatusCount[1] = dt.Rows[0]["InProgress"].ToString();
                        ticketStatusCount[2] = dt.Rows[0]["AdditionalInfo"].ToString();
                        ticketStatusCount[3] = dt.Rows[0]["Resolved"].ToString();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Json(new { ticketStatusCount });
        }


        public JsonResult GetTicketTypeCount()
        {
            string[] ticketTypeCount = new string[3];

            string sqlStatement = "SELECT COUNT(*) as Incident, (select count(*) from ticket where ticket_type like" +
                " 'Request for Enhancement') as RequestForEnhancement, (select count(*) from ticket where ticket_type like" +
                " 'Change Request') as ChangeRequest from ticket where ticket_type like 'Incident';";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlStatement, connection);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter cmd1 = new MySqlDataAdapter(cmd);
                    cmd1.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        ticketTypeCount[0] = "0";
                        ticketTypeCount[1] = "0";
                        ticketTypeCount[2] = "0";
                    }
                    else
                    {
                        ticketTypeCount[0] = dt.Rows[0]["Incident"].ToString();
                        ticketTypeCount[1] = dt.Rows[0]["RequestForEnhancement"].ToString();
                        ticketTypeCount[2] = dt.Rows[0]["ChangeRequest"].ToString();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Json(new { ticketTypeCount });
        }


        public JsonResult GetAdminDevCount() // Admin Dev distribution?
        {
            string[] devCount = new string[2];

            string sqlStatement = "SELECT COUNT(*) AS Admin, (SELECT count(*) FROM user WHERE role LIKE 'Developer') " +
                "AS Developer FROM user WHERE role LIKE 'Admin';";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlStatement, connection);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter cmd1 = new MySqlDataAdapter(cmd);
                    cmd1.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        devCount[0] = "0";
                        devCount[1] = "0";
                    }
                    else
                    {
                        devCount[0] = dt.Rows[0]["Admin"].ToString();
                        devCount[1] = dt.Rows[0]["Developer"].ToString();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Json(new { devCount });
        }


    }
}
