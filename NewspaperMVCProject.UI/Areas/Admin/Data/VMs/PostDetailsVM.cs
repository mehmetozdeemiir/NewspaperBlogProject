using NewspaperMVCProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewspaperMVCProject.UI.Areas.Admin.Data.VMs
{
    public class PostDetailsVM
    {
        public PostDetailsVM()
        {
            AppUsers = new List<AppUser>();
            Comments = new List<Comment>();
            AppUser = new AppUser();
            Post = new Post();
        }

        public List<AppUser> AppUsers { get; set; }
        public List<Comment> Comments { get; set; }
        public AppUser AppUser { get; set; }
        public Post Post { get; set; }


        public int CommentCount { get; set; }
       
    }
}