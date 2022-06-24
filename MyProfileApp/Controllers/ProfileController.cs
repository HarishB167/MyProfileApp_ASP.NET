using MyProfileApp.Models;
using MyProfileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfileApp.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context;

        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Profile
        public ActionResult Index()
        {
            var persons = _context.Persons.ToList();
            return View(persons);
        }

        public ActionResult View(int id)
        {
            var person = _context.Persons.SingleOrDefault(c => c.Id == id);
            if (person == null)
                return HttpNotFound();

            var profileView = new ViewProfileViewModel()
            {
                Person = person,
                Projects = _context.Projects.Where(p => p.PersonId == id).ToList(),
                Educations = _context.Educations.Where(e => e.PersonId == id).ToList(),
                Experiences = _context.Experiences.Where(e => e.PersonId == id).ToList(),
                Trainings = _context.Trainings.Where(t => t.PersonId == id).ToList(),
                Contact = _context.Contacts.SingleOrDefault(c => c.PersonId == id),
                Skills = _context.Skills.Where(s => s.PersonId == id).ToList(),
                Languages = _context.Languages.Where(l => l.PersonId == id).ToList()
            };
            return View(profileView);
        }

        public ActionResult New()
        {
            var saveModel = new SaveProfileViewModel
            {
                Person = new Person()
            };
            return View("ProfileForm", saveModel);
        }

        public ActionResult Edit(int id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);
            if (person == null)
                return HttpNotFound();
            var saveModel = new SaveProfileViewModel()
            {
                Person = person,
                Project = _context.Projects.Single(p => p.Person.Id == id),
                Education = _context.Educations.Single(p => p.Person.Id == id),
                Experience = _context.Experiences.Single(p => p.Person.Id == id),
                Training = _context.Trainings.Single(p => p.Person.Id == id),
                Contact = _context.Contacts.Single(p => p.Person.Id == id),
                Skill = _context.Skills.Single(p => p.Person.Id == id),
                Language = _context.Languages.Single(p => p.Person.Id == id)
            };
            return View("ProfileForm", saveModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SaveProfileViewModel saveProfileView)
        {
            if (!ModelState.IsValid)
            {
                return View("ProfileForm", saveProfileView);
            }
            if (saveProfileView.Person.Id == 0)
            {
                var person = _context.Persons.Add(saveProfileView.Person);
                _context.SaveChanges();
                saveProfileView.Project.Person = person;
                saveProfileView.Education.Person = person;
                saveProfileView.Experience.Person = person;
                saveProfileView.Training.Person = person;
                saveProfileView.Contact.Person = person;
                saveProfileView.Skill.Person = person;
                saveProfileView.Language.Person = person;
                _context.Projects.Add(saveProfileView.Project);
                _context.Educations.Add(saveProfileView.Education);
                _context.Experiences.Add(saveProfileView.Experience);
                _context.Trainings.Add(saveProfileView.Training);
                _context.Contacts.Add(saveProfileView.Contact);
                _context.Skills.Add(saveProfileView.Skill);
                _context.Languages.Add(saveProfileView.Language);
            }
            else
            {

                var personInDb = _context.Persons.Single(p => p.Id == saveProfileView.Person.Id);
                personInDb.Name = saveProfileView.Person.Name;
                personInDb.ProfileStatement = saveProfileView.Person.ProfileStatement;
                var projectInDb = _context.Projects.Single(p => p.Id == saveProfileView.Project.Id);
                projectInDb.Title = saveProfileView.Project.Title;
                projectInDb.Subtitle = saveProfileView.Project.Subtitle;
                projectInDb.Description = saveProfileView.Project.Description;
                var educationInDb = _context.Educations.Single(e => e.Id == saveProfileView.Education.Id);
                educationInDb.Qualification = saveProfileView.Education.Qualification;
                educationInDb.Institute = saveProfileView.Education.Institute;
                educationInDb.Score = saveProfileView.Education.Score;
                var experienceInDb = _context.Experiences.Single(e => e.Id == saveProfileView.Experience.Id);
                experienceInDb.Title = saveProfileView.Experience.Title;
                experienceInDb.Subtitle = saveProfileView.Experience.Subtitle;
                experienceInDb.Start = saveProfileView.Experience.Start;
                experienceInDb.End = saveProfileView.Experience.End;
                experienceInDb.Responsibilities = saveProfileView.Experience.Responsibilities;
                var trainingInDb = _context.Trainings.Single(t => t.Id == saveProfileView.Training.Id);
                trainingInDb.Title = saveProfileView.Training.Title;
                trainingInDb.Subtitle = saveProfileView.Training.Subtitle;
                trainingInDb.Description = saveProfileView.Training.Description;

                var contactInDb = _context.Contacts.Single(c => c.Id == saveProfileView.Contact.Id);
                contactInDb.Phone = saveProfileView.Contact.Phone;
                contactInDb.Address = saveProfileView.Contact.Address;
                contactInDb.ProfileLink = saveProfileView.Contact.ProfileLink;

                var skillInDb = _context.Skills.Single(s => s.Id == saveProfileView.Skill.Id);
                skillInDb.Name = saveProfileView.Skill.Name;

                var languageInDb = _context.Languages.Single(l => l.Id == saveProfileView.Language.Id);
                languageInDb.Name = saveProfileView.Language.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Profile");
        }
    }
}