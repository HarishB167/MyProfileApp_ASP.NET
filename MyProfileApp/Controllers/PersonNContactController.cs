using MyProfileApp.Models;
using MyProfileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfileApp.Controllers
{
    public class PersonNContactController : Controller
    {
        private ApplicationDbContext _context;

        public PersonNContactController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult AddPersonNContact()
        {
            return View("PersonNContactForm", new AddPersonNContactViewModel
            {
                Person = new Person(),
                Contact = new Contact()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePersonNContact(AddPersonNContactViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddPersonNContact", viewModel);
            }
            Person person = null;
            if (viewModel.Person.Id == 0)
                person = _context.Persons.Add(new Person { Name = viewModel.Person.Name, ProfileStatement = viewModel.Person.ProfileStatement });
            else
            {
                person = _context.Persons.Single(p => p.Id == viewModel.Person.Id);
                person.Name = viewModel.Person.Name;
                person.ProfileStatement = viewModel.Person.ProfileStatement;
            }
            _context.SaveChanges();

            var personId = viewModel.PersonId == 0 ? person.Id : viewModel.PersonId;
            if (viewModel.Contact.Id == 0)
            {
                var contact = new Contact
                {
                    Address = viewModel.Contact.Address,
                    Phone = viewModel.Contact.Phone,
                    Email = viewModel.Contact.Email,
                    ProfileLink = viewModel.Contact.ProfileLink,
                    PersonId = personId
                };
                _context.Contacts.Add(contact);
            }
            else
            {
                var contactInDb = _context.Contacts.Single(c => c.Id == viewModel.Contact.Id);
                contactInDb.Address = viewModel.Contact.Address;
                contactInDb.Phone = viewModel.Contact.Phone;
                contactInDb.Email = viewModel.Contact.Email;
                contactInDb.ProfileLink = viewModel.Contact.ProfileLink;
            }
            _context.SaveChanges();
            return RedirectToAction("AddEditInfo", "Profile", new { id = personId });
        }

        public ActionResult Edit(int id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);

            if (person == null)
                return HttpNotFound();

            return View("PersonNContactForm", new AddPersonNContactViewModel
            {
                PersonId = id,
                Person = person,
                Contact = _context.Contacts.Single(c => c.PersonId == id)
            });
        }
    }
}