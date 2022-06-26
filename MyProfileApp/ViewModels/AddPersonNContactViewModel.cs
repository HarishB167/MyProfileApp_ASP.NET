using MyProfileApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProfileApp.ViewModels
{
    public class AddPersonNContactViewModel
    {
        public int PersonId { get; set; }

        [Required]
        public Person Person { get; set; }

        [Required]
        public Contact Contact { get; set; }
    }
}