using NewspaperMVCProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewspaperMVCProject.UI.Areas.Admin.Data.VMs
{
    public class AddPostVM
    {
        public AddPostVM()
        {
            AppUsers = new List<AppUser>();
            Categories = new List<Category>();
        }
        public List<AppUser> AppUsers { get; set; }
        public List<Category> Categories { get; set; }
    }
}