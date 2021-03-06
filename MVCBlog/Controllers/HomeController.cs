﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVCBlog.Models;
using MVCBlog.Models.DataModels;
using MVCBlog.Models.ViewModels;
using PagedList;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            var blogViewModels = new BlogViewModels();
            blogViewModels.Comments = db.Comments.Include((c => c.Author)).OrderByDescending(c => c.Date).Take(5).ToList();
            blogViewModels.Categories = db.Categories.ToList();
            blogViewModels.Tags = db.Tags.OrderByDescending(t => t.Posts.Count).Take(9).ToList();

            var postList = db.Posts.OrderByDescending(c => c.Date).ToList();
            var pageNumber = page ?? 1;
            var onePageOfPosts = postList.ToPagedList(pageNumber, 2); 
            ViewBag.onePageOfPosts = onePageOfPosts;

            return View(blogViewModels);
        }

        public FileContentResult Photo(string userId)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == userId);

            return new FileContentResult(user.ProfilePicture, "image/jpeg");
        }

    }
}