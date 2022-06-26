using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProfileApp.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Profile Link")]
        public string ProfileLink { get; set; }

        public Person Person { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}