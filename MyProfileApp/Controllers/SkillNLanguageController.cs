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

        [Route("SkillNLanguage/AddEditSkillNLanguage/{perId}")]
        public ActionResult AddEditSkillNLanguage(int perId)
        {
            return View("AddEditSkillNLanguage", new AddEditSkillNLanguageViewModel
            {
                PersonId = perId,
                ExistingSkills = _context.Skills.Where(s => s.PersonId == perId).ToList(),
                ExistingLanguages= _context.Languages.Where(l => l.PersonId == perId).ToList()
            });
        }

        [Route("SkillNLanguage/EditSkill/{perId}/{skillId}", Name = "EditSkill")]
        public ActionResult EditSkill(int perId, int skillId)
        {
            return View("AddEditSkillNLanguage", new AddEditSkillNLanguageViewModel
            {
                PersonId = perId,
                SkillId = skillId,
                Skill = _context.Skills.Single(s => s.Id == skillId).Name,
                ExistingSkills = _context.Skills.Where(s => s.PersonId == perId).ToList(),
                ExistingLanguages = _context.Languages.Where(l => l.PersonId == perId).ToList()
            });
        }

        [Route("SkillNLanguage/EditLanguage/{perId}/{languageId}", Name = "EditLanguage")]
        public ActionResult EditLanguage(int perId, int languageId)
        {
            return View("AddEditSkillNLanguage", new AddEditSkillNLanguageViewModel
            {
                PersonId = perId,
                LanguageId = languageId,
                Language = _context.Languages.Single(l => l.Id == languageId).Name,
                ExistingSkills = _context.Skills.Where(s => s.PersonId == perId).ToList(),
                ExistingLanguages = _context.Languages.Where(l => l.PersonId == perId).ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSkillNLanguage(AddEditSkillNLanguageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEditSkillNLanguage", viewModel);
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

        public ActionResult DeleteSkill(int id)
        {
            var skillInDb = _context.Skills.SingleOrDefault(s => s.Id == id);
            if (skillInDb == null)
                return HttpNotFound();

            _context.Skills.Remove(skillInDb);
            _context.SaveChanges();
            return RedirectToAction("AddEditSkillNLanguage", "SkillNLanguage", new { id = skillInDb.PersonId });
        }

        public ActionResult DeleteLanguage(int id)
        {
            var languageInDb = _context.Languages.SingleOrDefault(l => l.Id == id);
            if (languageInDb == null)
                return HttpNotFound();

            _context.Languages.Remove(languageInDb);
            _context.SaveChanges();
            return RedirectToAction("AddEditSkillNLanguage", "SkillNLanguage", new { id = languageInDb.PersonId });
        }
    }
}