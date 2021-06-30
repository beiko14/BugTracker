using BugTracker.Models;
using BugTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class TicketController : BaseController
    {
        // use dependency injection. See startup.cs to see the data source for repository
        // TicketDAO repository;
        public ITicketDataService repository { get; set; }

        public TicketController(ITicketDataService dataService)
        {
            repository = dataService;
            // repository = new TicketDAO();
        }

        [Authorize]
        public IActionResult Index()
        {
            UsersDAO user = new UsersDAO();
            string userRole = user.GetUserRole(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);

            if (userRole.Equals("Admin"))
            {
                return View(repository.GetAllTickets());
            }
            else if (userRole.Equals("Developer"))
            {
                return View(repository.GetYourTickets(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value));
            }
            return View("404");
        }

        [Authorize]
        public IActionResult ShowDetails(int id)
        {
            TicketModel ticketModel = new TicketModel();
            ticketModel = repository.GetTicketById(id);
            ticketModel.CommentModel = repository.GetAllCommentsByTicketId(id);
            ticketModel.TicketHistory = repository.GetTicketHistoryById(id);
            ticketModel.SubmitterId = repository.GetSubmitterIdByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);
            return View(ticketModel);
        }

        [Authorize]
        public IActionResult ProcessCreateComment(TicketModel ticket)
        {
            TicketModel ticketModel = new TicketModel();
            int ticketId = repository.InsertComment(ticket);
            ticketModel = repository.GetTicketById(ticketId);
            ticketModel.CommentModel = repository.GetAllCommentsByTicketId(ticketId);
            ticketModel.TicketHistory = repository.GetTicketHistoryById(ticketId);
            ticketModel.SubmitterId = repository.GetSubmitterIdByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);
            return View("ShowDetails", ticketModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            TicketModel ticketModel = new TicketModel();
            ticketModel.ProjectNameList = repository.GetAllProjectNames();
            ticketModel.DevList = repository.GetAllDevs();
            ticketModel.SubmitterId = repository.GetSubmitterIdByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);
            return View(ticketModel);
        }

        [Authorize]
        public IActionResult ProcessCreate(TicketModel ticket)
        {
            TicketModel ticketModel = new TicketModel();
            int ticketId = repository.Insert(ticket);
            ticketModel = repository.GetTicketById(ticketId);
            ticketModel.CommentModel = repository.GetAllCommentsByTicketId(ticketId);
            ticketModel.TicketHistory = repository.GetTicketHistoryById(ticketId);
            ticketModel.SubmitterId = repository.GetSubmitterIdByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);
            return View("ShowDetails", ticketModel);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            TicketModel foundTicket = repository.GetTicketById(id);
            foundTicket.DevList = repository.GetAllDevs();
            return View("ShowEdit", foundTicket);
        }

        [Authorize]
        public IActionResult ProcessEdit(TicketModel ticket)
        {
            TicketModel ticketModel = new TicketModel();
            int ticketId = repository.Update(ticket);
            ticketModel = repository.GetTicketById(ticketId);
            ticketModel.CommentModel = repository.GetAllCommentsByTicketId(ticketId);
            ticketModel.TicketHistory = repository.GetTicketHistoryById(ticketId);
            ticketModel.SubmitterId = repository.GetSubmitterIdByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);
            return View("ShowDetails", ticketModel);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            TicketModel ticket = repository.GetTicketById(id);
            repository.Delete(ticket);
            return View("Index", repository.GetAllTickets());
        }


    }
}
