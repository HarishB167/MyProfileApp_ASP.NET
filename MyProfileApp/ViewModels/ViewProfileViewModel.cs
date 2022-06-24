using MyProfileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileApp.ViewModels
{
    public class ViewProfileViewModel
    {
        public Person Person { get; set; }

        public List<Project> Projects { get; set; }

        public List<Education> Educations { get; set; }

        public List<Experience> Experiences { get; set; }

        public List<Training> Trainings { get; set; }
        
        public Contact Contact { get; set; }

        public List<Skill> Skills { get; set; }

        public List<Language> Languages { get; set; }
    }
}