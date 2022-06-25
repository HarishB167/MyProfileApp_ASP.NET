using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProfileApp.Dtos
{
    public class ExperienceDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Subtitle { get; set; }

        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }

        [Required]
        public string Responsibilities { get; set; }
    }
}