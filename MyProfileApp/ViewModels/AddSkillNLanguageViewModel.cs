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

        public string Skill { get; set; }
        public int SkillId { get; set; }

        public string Language { get; set; }
        public int LanguageId { get; set; }
    }
}