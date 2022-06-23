using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProfileApp.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Subtitle { get; set; }

        [Required]
        public string Description { get; set; }

        public Person Person { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}