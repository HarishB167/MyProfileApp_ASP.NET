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
                PersonId = perId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSkillNLanguage(AddSkillNLanguageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSkillNLanguage", viewModel);
            }
            if (!string.IsNullOrWhiteSpace(viewModel.Skill))
            {
                if (viewModel.SkillId == 0)
                    _context.Skills.Add(new Skill { Name = viewModel.Skill, PersonId = viewModel.PersonId });
                else
                    _context.Skills.Single(s => s.Id == viewModel.SkillId).Name = viewModel.Skill;
            }
            if (!string.IsNullOrWhiteSpace(viewModel.Language))
            {
                if (viewModel.LanguageId == 0)
                    _context.Languages.Add(new Language { Name = viewModel.Language, PersonId = viewModel.PersonId });
                else
                    _context.Languages.Single(s => s.Id == viewModel.LanguageId).Name = viewModel.Language;
            }
            _context.SaveChanges();
            return RedirectToAction("AddEditInfo", "Profile", new { id = viewModel.PersonId });
        }
    }
}