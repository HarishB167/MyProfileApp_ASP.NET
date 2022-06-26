using MyProfileApp.Models;
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

        [Route("Education/AddEducation/{perId}")]
        public ActionResult AddEducation(int perId)
        {
            return View(new Education { PersonId = perId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation", education);
            }
            if (education.Id == 0)
            {
                _context.Educations.Add(education);
            }
            else
            {
                var educationInDb = _context.Educations.Single(p => p.Id == education.Id);
                educationInDb.Qualification = education.Qualification;
                educationInDb.Institute = education.Institute;
                educationInDb.Score = education.Score;
            }
            _context.SaveChanges();
            return RedirectToAction("AddEditInfo", "Profile", new { id = education.PersonId });
        }
    }
}