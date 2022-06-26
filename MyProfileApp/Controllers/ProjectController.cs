using MyProfileApp.Models;
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

        [Route("Project/AddProject/{perId}")]
        public ActionResult AddProject(int perId)
        {
            return View(new Project { PersonId = perId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View("AddProject", project);
            }
            if (project.Id == 0)
            {
                _context.Projects.Add(project);
            }
            else
            {
                var projectInDb = _context.Projects.Single(p => p.Id == project.Id);
                projectInDb.Title = project.Title;
                projectInDb.Subtitle = project.Subtitle;
                projectInDb.Description = project.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("AddEditInfo", "Profile", new { id = project.PersonId });
        }
    }
}