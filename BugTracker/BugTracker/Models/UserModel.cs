using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [DisplayName("E-Mail-Adresse")]
        public string EmailAddress { get; set; }

        [Required]
        [DisplayName("Vorname")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Nachname")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Name")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Geburtsdatum")]
        public DateTime BirthDate { get; set; }
        public string ProfileImage { get; set; }

        [Required]
        [DisplayName("Telefonnummer")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Rolle")]
        public string Role { get; set; }


        public List<string> EmailList { get; set; }
        public List<UserModel> UserModelList { get; set; }
    }
}
