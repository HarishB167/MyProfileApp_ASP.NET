using MyProfileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileApp.ViewModels
{
    public class SavePersonContactViewModel
    {
        public Person Person { get; set; }
        
        public Contact Contact { get; set; }
    }
}