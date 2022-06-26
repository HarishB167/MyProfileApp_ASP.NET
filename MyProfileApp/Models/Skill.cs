using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProfileApp.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Skill")]
        public string Name { get; set; }

        public Person Person { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}