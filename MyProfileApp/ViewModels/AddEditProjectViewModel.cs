using MyProfileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileApp.ViewModels
{
    public class AddEditProjectViewModel
    {
        public Project Project { get; set; }

        public IEnumerable<Project> ExistingProjects { get; set; }
    }
}