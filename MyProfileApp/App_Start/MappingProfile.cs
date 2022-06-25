using AutoMapper;
using MyProfileApp.Dtos;
using MyProfileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Project, ProjectDto>();
            Mapper.CreateMap<ProjectDto, Project>();

            Mapper.CreateMap<Education, EducationDto>();
            Mapper.CreateMap<EducationDto, Education>();

            Mapper.CreateMap<Experience, ExperienceDto>();
            Mapper.CreateMap<ExperienceDto, Experience>();

            Mapper.CreateMap<Training, TrainingDto>();
            Mapper.CreateMap<TrainingDto, Training>();
        }
    }
}