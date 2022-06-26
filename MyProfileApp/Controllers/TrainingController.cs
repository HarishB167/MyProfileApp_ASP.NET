using MyProfileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfileApp.Controllers
{
    public class TrainingController : Controller
    {
        private ApplicationDbContext _context;

        public TrainingController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Training/AddTraining/{perId}")]
        public ActionResult AddTraining(int perId)
        {
            return View(new Training { PersonId = perId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTraining(Training training)
        {
            if (!ModelState.IsValid)
            {
                return View("AddTraining", training);
            }
            if (training.Id == 0)
            {
                _context.Trainings.Add(training);
            }
            else
            {
                var experienceInDb = _context.Trainings.Single(p => p.Id == training.Id);
                experienceInDb.Title = training.Title;
                experienceInDb.Subtitle = training.Subtitle;
                experienceInDb.Description = training.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("AddEditInfo", "Profile", new { id = training.PersonId });
        }
    }
}