using MyProfileApp.Models;
using MyProfileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfileApp.Controllers
{
    public class SkillNLanguageController : Controller
    {
        private ApplicationDbContext _context;

        public SkillNLanguageController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("SkillNLanguage/AddSkillNLanguage/{perId}")]
        public ActionResult AddSkillNLanguage(int perId)
        {
            return View(new AddSkillNLanguageViewModel
            {
                PersonId = perId,
                Skill = new Skill(),
                Language = new Language()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSkillNLanguage(AddSkillNLanguageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSkillNLanguageb", viewModel);
            }
            if (!string.IsNullOrWhiteSpace(viewModel.Skill.Name))
            {
                if (viewModel.Skill.Id == 0)
                    _context.Skills.Add(new Skill { Name = viewModel.Skill.Name, PersonId = viewModel.PersonId });
                else
                    _context.Skills.Single(s => s.Id == viewModel.Skill.Id).Name = viewModel.Skill.Name;
            }
            if (!string.IsNullOrWhiteSpace(viewModel.Language.Name))
            {
                if (viewModel.Language.Id == 0)
                    _context.Languages.Add(new Language { Name = viewModel.Language.Name, PersonId = viewModel.PersonId });
                else
                    _context.Languages.Single(s => s.Id == viewModel.Language.Id).Name = viewModel.Language.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("AddInfo", "Profile", new { id = viewModel.PersonId });
        }
    }
}