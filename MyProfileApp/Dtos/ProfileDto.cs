using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProfileApp.Dtos
{
    public class ProfileDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ProfileStatement { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string ProfileLink { get; set; }

        public IEnumerable<ProjectDto> Projects { get; set; }

        public IEnumerable<EducationDto> Educations { get; set; }

        public IEnumerable<ExperienceDto> Experiences { get; set; }

        public IEnumerable<TrainingDto> Trainings { get; set; }

        public IEnumerable<string> Skills { get; set; }

        public IEnumerable<string> Languages { get; set; }
    }
}