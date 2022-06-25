using AutoMapper;
using MyProfileApp.Dtos;
using MyProfileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyProfileApp.Controllers.Api
{
    public class ProfileController : ApiController
    {
        private ApplicationDbContext _context;

        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetProfiles()
        {
            return Ok(_context.Persons.ToList().Select(p => mapToProfileDto(p)));
        }

        private ProfileDto mapToProfileDto(Person person)
        {
            var profileDto = new ProfileDto();
            profileDto.Id = person.Id;
            profileDto.Name = person.Name;
            profileDto.ProfileStatement = person.ProfileStatement;

            var contact = _context.Contacts.Single(c => c.PersonId == person.Id);
            profileDto.Address = contact.Address;
            profileDto.Phone = contact.Phone;
            profileDto.ProfileLink = contact.ProfileLink;

            profileDto.Projects = _context.Projects
                .Where(p => p.PersonId == person.Id)
                .ToList().Select(Mapper.Map<Project, ProjectDto>);

            profileDto.Educations = _context.Educations
                .Where(p => p.PersonId == person.Id)
                .ToList().Select(Mapper.Map<Education, EducationDto>);

            profileDto.Experiences = _context.Experiences
                .Where(p => p.PersonId == person.Id)
                .ToList().Select(Mapper.Map<Experience, ExperienceDto>);

            profileDto.Trainings = _context.Trainings
                .Where(p => p.PersonId == person.Id)
                .ToList().Select(Mapper.Map<Training, TrainingDto>);

            profileDto.Skills = _context.Skills
                .Where(p => p.PersonId == person.Id)
                .ToList().Select(s => s.Name);

            profileDto.Languages = _context.Languages
                .Where(p => p.PersonId == person.Id)
                .ToList().Select(l => l.Name);

            return profileDto;
        }
    }

}
