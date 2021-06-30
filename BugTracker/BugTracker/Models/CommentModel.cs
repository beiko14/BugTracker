using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public string Email { get; set; }
        public int TicketId { get; set; }
        public DateTime CommentStart { get; set; }
    }
}
