using MyProfileApp.Models;
using MyProfileApp.ViewModels;
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

        [Route("Training/AddEditTraining/{perId}")]
        public ActionResult AddEditTraining(int perId)
        {
            return View(new AddEditGenericModelViewModel<Training>
            {
                Model = new Training { PersonId = perId },
                ExistingModels = _context.Trainings.Where(e => e.PersonId == perId).ToList()
            });
        }

        [Route("Training/AddEditTraining/{perId}/{trainingId}", Name = "EditTraining")]
        public ActionResult AddEditTraining(int perId, int trainingId)
        {
            return View(new AddEditGenericModelViewModel<Training>
            {
                Model = _context.Trainings.Single(e => e.Id == trainingId),
                ExistingModels = _context.Trainings.Where(e => e.PersonId == perId).ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTraining(AddEditGenericModelViewModel<Training> viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEditTraining", viewModel);
            }
            if (viewModel.Model.Id == 0)
            {
                _context.Trainings.Add(viewModel.Model);
            }
            else
            {
                var trainingInDb = _context.Trainings.Single(p => p.Id == viewModel.Model.Id);
                trainingInDb.Title = viewModel.Model.Title;
                trainingInDb.Subtitle = viewModel.Model.Subtitle;
                trainingInDb.Description = viewModel.Model.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("AddEditInfo", "Profile", new { id = viewModel.Model.PersonId });
        }

        public ActionResult Delete(int id)
        {
            var trainingInDb = _context.Trainings.SingleOrDefault(t => t.Id == id);
            if (trainingInDb == null)
                return HttpNotFound();

            _context.Trainings.Remove(trainingInDb);
            _context.SaveChanges();
            return RedirectToAction("AddEditTraining", "Training", new { id = trainingInDb.PersonId });
        }
    }
}