using MyProfileApp.Models;
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

        [Route("Experience/AddExperience/{perId}")]
        public ActionResult AddExperience(int perId)
        {
            return View(new Experience { PersonId = perId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View("AddExperience", experience);
            }
            if (experience.Id == 0)
            {
                _context.Experiences.Add(experience);
            }
            else
            {
                var experienceInDb = _context.Experiences.Single(p => p.Id == experience.Id);
                experienceInDb.Title = experience.Title;
                experienceInDb.Subtitle= experience.Subtitle;
                experienceInDb.Start = experience.Start;
                experienceInDb.End = experience.End;
                experienceInDb.Responsibilities = experience.Responsibilities;
            }
            _context.SaveChanges();
            return RedirectToAction("AddInfo", "Profile", new { id = experience.PersonId });
        }
    }
}