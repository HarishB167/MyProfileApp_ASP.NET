using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProfileApp.Models
{
    public class Education
    {
        public int Id { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public string Institute { get; set; }

        [Required]
        public string Score { get; set; }

        public Person Person { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}