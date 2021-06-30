using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public interface ITicketDataService
    {
        List<TicketModel> GetAllTickets();
        List<TicketModel> GetYourTickets(string email);
        List<TicketModel> GetAllTicketsById(int id);
        List<CommentModel> GetAllCommentsByTicketId(int id);

        // List<TicketModel> GetAllTicketsByProject(int id, string email);

        TicketModel GetTicketById(int id);
        int Insert(TicketModel ticket);
        int InsertComment(TicketModel ticket);
        bool Delete(TicketModel ticket);
        int Update(TicketModel ticket);
        int GetSubmitterIdByEmail(string email);
        List<string> GetAllProjectNames();
        List<string> GetAllDevs();
        List<TicketModel> GetTicketHistoryById(int id);
    }
}
