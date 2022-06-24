using MyProfileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileApp.ViewModels
{
    public class SaveProfileViewModel
    {
        public Person Person { get; set; }

        public Project Project { get; set; }

        public Education Education { get; set; }

        public Experience Experience { get; set; }

        public Training Training { get; set; }
        
        public Contact Contact { get; set; }

        public Skill Skill { get; set; }

        public Language Language { get; set; }
    }
}