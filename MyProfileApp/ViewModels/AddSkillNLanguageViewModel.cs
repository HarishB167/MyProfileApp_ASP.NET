using MyProfileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileApp.ViewModels
{
    public class AddSkillNLanguageViewModel
    {
        public int PersonId { get; set; }

        public Skill Skill { get; set; }
        public Language Language { get; set; }
    }
}