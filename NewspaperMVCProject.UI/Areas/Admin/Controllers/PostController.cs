using NewspaperMVCProject.DataAccesLayer.Repositories.Concrete.EfRepositories;
using NewspaperMVCProject.EntityLayer.Entities.Concrete;
using NewspaperMVCProject.EntityLayer.Enums;
using NewspaperMVCProject.UI.Areas.Admin.Data.DTOs;
using NewspaperMVCProject.UI.Areas.Admin.Data.VMs;
using NewspaperMVCProject.Utility.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewspaperMVCProject.UI.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        EfPostRepository _postRepo;
        EfCategoryRepository _categoryRepo;
        EfAppUserRepository _appUserRepo;
        EfCommentRepository _commentRepo;

        public PostController()
        {
            _postRepo = new EfPostRepository();
            _categoryRepo = new EfCategoryRepository();
            _appUserRepo = new EfAppUserRepository();
            _commentRepo = new EfCommentRepository();
        }
        public ActionResult Create()
        {
            AddPostVM data = new AddPostVM()
            {
                Categories = _categoryRepo.GetActive(),
                AppUsers = _appUserRepo.GetDefault(x => x.Role != Role.Member)
            };
            return View(data);
        }
        [HttpPost]
        public ActionResult Create(Post data, HttpPostedFileBase Image)
        {
            List<string> UploadImagePaths = new List<string>();
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadImagePaths[0];

            if (data.ImagePath == "1" || data.ImagePath == "2" || data.ImagePath == "3")
            {
                data.ImagePath = ImageUploader.DefaultProfileImagePath;
                data.ImagePath = ImageUploader.DefaultXSmallProfileImagePath;
                data.ImagePath = ImageUploader.DefaultCruptedProfileImagePath;
            }
            else
            {
                data.ImagePath = UploadImagePaths[1];
                data.ImagePath = UploadImagePaths[2];
            }

            _postRepo.Add(data);
            return Redirect("/Admin/Post/List");
        }

        public ActionResult Update(int id)
        {
            Post post = _postRepo.GetById(id);
            UpdatePostVM data = new UpdatePostVM();
            data.PostDTO.Id = post.Id;
            data.PostDTO.Header = post.Header;
            data.PostDTO.Content = post.Content;
            data.PostDTO.ImagePath = post.ImagePath;
            data.Categories = _categoryRepo.GetActive();
            data.AppUsers = _appUserRepo.GetDefault(x => x.Role != Role.Member);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(PostDTO data, HttpPostedFileBase Image)
        {
            List<string> UploadImagePaths = new List<string>();
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadImagePaths[0];

            Post post = _postRepo.GetById(data.Id);

            if (data.ImagePath == "1" || data.ImagePath == "2" || data.ImagePath == "3")
            {
                if (post.ImagePath == null || post.ImagePath == ImageUploader.DefaultProfileImagePath)
                {
                    post.ImagePath = ImageUploader.DefaultProfileImagePath;
                    post.ImagePath = ImageUploader.DefaultXSmallProfileImagePath;
                    post.ImagePath = ImageUploader.DefaultCruptedProfileImagePath;
                }
            }
            else
            {
                post.ImagePath = UploadImagePaths[0];
                post.ImagePath = UploadImagePaths[1];
                post.ImagePath = UploadImagePaths[2];
            }

            post.Header = data.Header;
            post.Content = data.Content;
            post.CategoryId = data.CategoryId;
            post.AppUserId = data.AppUserId;
            post.Status = Status.Active;
            post.UpdateDate = DateTime.Now;
            _postRepo.Update(post);
            return Redirect("/Admin/Post/List");
        }
        public ActionResult Delete(int id)
        {
            _postRepo.Remove(id);
            return Redirect("/Admin/Post/List");
        }
        public ActionResult List()
        {
            return View(_postRepo.GetActive());
        }

        public ActionResult Details(int id)
        {
            PostDetailsVM data = new PostDetailsVM();
            data.Post = _postRepo.GetById(id);
            data.AppUser = _appUserRepo.GetById(data.Post.AppUserId);

            data.Comments = _commentRepo.GetDefault(x => x.PostId == id && x.Status != Status.Passive);

            data.CommentCount = _commentRepo.GetDefault(x => x.PostId == id && x.Status != Status.Passive).Count;
          
            return View(data);
        }
        public ActionResult ViewPost(int id)
        {
            Post post = _postRepo.GetById(id);
            UpdatePostVM data = new UpdatePostVM();
            data.PostDTO.Id = post.Id;
            data.PostDTO.Header = post.Header;
            data.PostDTO.Content = post.Content;
            data.PostDTO.ImagePath = post.ImagePath;
            return View(data);
        }
    }
}