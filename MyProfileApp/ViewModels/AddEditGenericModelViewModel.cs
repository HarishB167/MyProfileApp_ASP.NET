using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProfileApp.ViewModels
{
    public class AddEditGenericModelViewModel<T>
    {
        public T Model { get; set; }

        public IEnumerable<T> ExistingModels { get; set; }
    }
}