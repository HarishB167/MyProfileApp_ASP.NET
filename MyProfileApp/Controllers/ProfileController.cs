﻿using MyProfileApp.Models;
using MyProfileApp.ViewModels;
using System;
using System.Collections.Generic;
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

    }
}