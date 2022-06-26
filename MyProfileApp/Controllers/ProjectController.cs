using MyProfileApp.Models;
using MyProfileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfileApp.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Project/AddEditProject/{perId}")]
        public ActionResult AddEditProject(int perId)
        {
            return View(new AddEditProjectViewModel
            {
                Project = new Project { PersonId = perId },
                ExistingProjects = _context.Projects.Where(p => p.PersonId == perId).ToList()
            });
        }

        [Route("Project/AddEditProject/{perId}/{projectId}", Name = "EditProject")]
        public ActionResult AddEditProject(int perId, int projectId)
        {
            return View(new AddEditProjectViewModel
            {
                Project = _context.Projects.Single(p => p.Id == projectId),
                ExistingProjects = _context.Projects.Where(p => p.PersonId == perId).ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProject(AddEditProjectViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEditProject", viewModel);
            }
            if (viewModel.Project.Id == 0)
            {
                _context.Projects.Add(viewModel.Project);
            }
            else
            {
                var projectInDb = _context.Projects.Single(p => p.Id == viewModel.Project.Id);
                projectInDb.Title = viewModel.Project.Title;
                projectInDb.Subtitle = viewModel.Project.Subtitle;
                projectInDb.Description = viewModel.Project.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("AddEditInfo", "Profile", new { id = viewModel.Project.PersonId });
        }

        public ActionResult Delete(int id)
        {
            var projectInDb = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (projectInDb == null)
                return HttpNotFound();

            _context.Projects.Remove(projectInDb);
            _context.SaveChanges();
            return RedirectToAction("AddEditProject", "Project", new { id = projectInDb.PersonId });
        }
    }
}