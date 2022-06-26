using MyProfileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileApp.ViewModels
{
    public class AddEditSkillNLanguageViewModel
    {
        public int PersonId { get; set; }

        public string Skill { get; set; }
        public int SkillId { get; set; }

        public string Language { get; set; }
        public int LanguageId { get; set; }

        public IEnumerable<Skill> ExistingSkills { get; set; }
        public IEnumerable<Language> ExistingLanguages { get; set; }
    }
}