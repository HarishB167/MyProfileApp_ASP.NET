using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProfileApp.Dtos
{
    public class TrainingDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Subtitle { get; set; }

        [Required]
        public string Description { get; set; }
    }
}