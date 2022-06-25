using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProfileApp.Dtos
{
    public class EducationDto
    {
        [Required]
        public string Qualification { get; set; }

        [Required]
        public string Institute { get; set; }

        [Required]
        public string Score { get; set; }
    }
}