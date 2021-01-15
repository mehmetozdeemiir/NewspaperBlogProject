using NewspaperMVCProject.EntityLayer.Entities.Concrete;
using NewspaperMVCProject.UI.Areas.Admin.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewspaperMVCProject.UI.Areas.Admin.Data.VMs
{
    public class UpdatePostVM
    {
        public UpdatePostVM()
        {
            AppUsers = new List<AppUser>();
            Categories = new List<Category>();
            PostDTO = new PostDTO();
        }

        public List<AppUser> AppUsers { get; set; }
        public List<Category> Categories { get; set; }
        public PostDTO PostDTO { get; set; }
    }

}
