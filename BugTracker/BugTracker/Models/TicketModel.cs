using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class TicketModel
    {
        public int TicketId { get; set; }

        [Required]
        [DisplayName("Ticketname")]
        public string TicketName { get; set; }

        [Required]
        [DisplayName("Beschreibung")]
        public string TicketDescription { get; set; }

        [Required]
        [DisplayName("Status")]
        public string TicketStatus { get; set; }

        [Required]
        [DisplayName("Ticket-Typ")]
        public string TicketType { get; set; }

        [Required]
        [DisplayName("Priorität")]
        public string TicketPriority { get; set; }
        public int ProjectId { get; set; }

        [DisplayName("Projektname")]
        public string ProjectName { get; set; }
        public List<string> ProjectNameList { get; set; }

        [DisplayName("Startdatum")]
        public DateTime TicketStart { get; set; }
        public int SubmitterId { get; set; }
        public string Submitter { get; set; }

        [DisplayName("Zuständiger Developer")]
        public string Dev { get; set; }
        public List<string> DevList { get; set; }
        public List<CommentModel> CommentModel { get; set; }
        public List<string> CommentList { get; set; }

        [Required]
        [DisplayName("Kommentar hinzufügen:")]
        public string CommentInput { get; set; }
        public List<TicketModel> TicketHistory { get; set; }
    }
}
