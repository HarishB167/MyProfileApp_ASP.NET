﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProfileApp.Models
{
    public class Language
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Person Person { get; set; }
        [Required]
        public int PersonId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}