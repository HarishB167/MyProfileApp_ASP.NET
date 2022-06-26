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
            Mapper.CreateMap<ProjectDto, Project>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Education, EducationDto>();
            Mapper.CreateMap<EducationDto, Education>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Experience, ExperienceDto>();
            Mapper.CreateMap<ExperienceDto, Experience>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Training, TrainingDto>();
            Mapper.CreateMap<TrainingDto, Training>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}