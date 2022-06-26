using MyProfileApp.Models;
using MyProfileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfileApp.Controllers
{
    public class ExperienceController : Controller
    {
        private ApplicationDbContext _context;

        public ExperienceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Experience/AddEditExperience/{perId}")]
        public ActionResult AddEditExperience(int perId)
        {
            return View(new AddEditGenericModelViewModel<Experience>
            {
                Model = new Experience { PersonId = perId },
                ExistingModels = _context.Experiences.Where(e => e.PersonId == perId).ToList()
            });
        }

        [Route("Experience/AddEditExperience/{perId}/{experienceId}", Name = "EditExperience")]
        public ActionResult AddEditExperience(int perId, int experienceId)
        {
            return View(new AddEditGenericModelViewModel<Experience>
            {
                Model = _context.Experiences.Single(e => e.Id == experienceId),
                ExistingModels = _context.Experiences.Where(e => e.PersonId == perId).ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveExperience(AddEditGenericModelViewModel<Experience> viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEditExperience", viewModel);
            }
            if (viewModel.Model.Id == 0)
            {
                _context.Experiences.Add(viewModel.Model);
            }
            else
            {
                var experienceInDb = _context.Experiences.Single(p => p.Id == viewModel.Model.Id);
                experienceInDb.Title = viewModel.Model.Title;
                experienceInDb.Subtitle= viewModel.Model.Subtitle;
                experienceInDb.Start = viewModel.Model.Start;
                experienceInDb.End = viewModel.Model.End;
                experienceInDb.Responsibilities = viewModel.Model.Responsibilities;
            }
            _context.SaveChanges();
            return RedirectToAction("AddEditInfo", "Profile", new { id = viewModel.Model.PersonId });
        }

        public ActionResult Delete(int id)
        {
            var experienceInDb = _context.Experiences.SingleOrDefault(e => e.Id == id);
            if (experienceInDb == null)
                return HttpNotFound();

            _context.Experiences.Remove(experienceInDb);
            _context.SaveChanges();
            return RedirectToAction("AddEditExperience", "Experience", new { id = experienceInDb.PersonId });
        }
    }
}