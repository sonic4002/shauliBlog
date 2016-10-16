using ShauliBlog.DAL;
using ShauliBlog.Models;
using ShauliBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shauli2.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext db = new BlogContext();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index( [Bind] CommentModel cm)
        {
            //CommentModel cm = null;
            cm.CommentAuthor = Request["comment.CommentAuthor"];
            //cm.Subject = Request["comment.Subject"];
            cm.CommentAuthorWebSite = Request["comment.CommentAuthorWebSite"];
            cm.CommentText = Request["comment.CommentText"];
            cm.CommentDate = DateTime.Now;
            //cm.PostModelID = id;
            //db.Comments.Add(cm);
            //db.SaveChanges();

            var viewModel = new PostsCommentsData();
            viewModel.posts = (from c in db.Posts orderby c.PostDate descending select c).Take(1);
            foreach (var item in viewModel.posts)
            {
                viewModel.Comments = from c in db.Comments
                                     where c.PostModelID == item.ID
                                     select c;
                cm.PostModelID = item.ID;
                cm.Subject = item.Subject;
            }
            db.Comments.Add(cm);
            db.SaveChanges();
            return View(viewModel);
        }


        public ActionResult Index()
        {
            var viewModel = new PostsCommentsData();
            viewModel.posts = (from c in db.Posts orderby c.PostDate descending select c).Take(1) ;
            foreach (var item in viewModel.posts)
            {
                viewModel.Comments = from c in db.Comments
                                     where c.PostModelID == item.ID
                                     select c;
            }
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}