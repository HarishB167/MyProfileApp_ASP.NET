using MyProfileApp.Models;
using MyProfileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfileApp.Controllers
{
    public class EducationController : Controller
    {
        private ApplicationDbContext _context;

        public EducationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Education/AddEditEducation/{perId}")]
        public ActionResult AddEditEducation(int perId)
        {
            return View(new AddEditGenericModelViewModel<Education>
            {
                Model = new Education { PersonId = perId },
                ExistingModels = _context.Educations.Where(e => e.PersonId == perId).ToList()
            });
        }

        [Route("Education/AddEditEducation/{perId}/{educationId}", Name = "EditEducation")]
        public ActionResult AddEditEducation(int perId, int educationId)
        {
            return View(new AddEditGenericModelViewModel<Education>
            {
                Model = _context.Educations.Single(e => e.Id == educationId),
                ExistingModels = _context.Educations.Where(e => e.PersonId == perId).ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEducation(AddEditGenericModelViewModel<Education> viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEditEducation", viewModel);
            }
            if (viewModel.Model.Id == 0)
            {
                _context.Educations.Add(viewModel.Model);
            }
            else
            {
                var educationInDb = _context.Educations.Single(p => p.Id == viewModel.Model.Id);
                educationInDb.Qualification = viewModel.Model.Qualification;
                educationInDb.Institute = viewModel.Model.Institute;
                educationInDb.Score = viewModel.Model.Score;
            }
            _context.SaveChanges();
            return RedirectToAction("AddEditInfo", "Profile", new { id = viewModel.Model.PersonId });
        }

        public ActionResult Delete(int id)
        {
            var educationInDb = _context.Educations.SingleOrDefault(e => e.Id == id);
            if (educationInDb == null)
                return HttpNotFound();

            _context.Educations.Remove(educationInDb);
            _context.SaveChanges();
            return RedirectToAction("AddEditEducation", "Education", new { id = educationInDb.PersonId });
        }
    }
}