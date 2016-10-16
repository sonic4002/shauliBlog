using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShauliBlog.DAL;
using ShauliBlog.Models;
using ShauliBlog.ViewModels;

namespace ShauliBlog.Controllers
{
    public class PostModelsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: PostModels
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult View(int id , [Bind] CommentModel cm)
        {
            //CommentModel cm = null;
            cm.CommentAuthor = Request["comment.CommentAuthor"];
            //cm.Subject = Request["comment.Subject"];
            cm.CommentAuthorWebSite = Request["comment.CommentAuthorWebSite"];
            cm.CommentText = Request["comment.CommentText"];
            cm.CommentDate = DateTime.Now;
            cm.PostModelID = id;
            
            var viewModel = new PostsCommentsData();
            viewModel.post = db.Posts.Find(id);
            cm.Subject = viewModel.post.Subject;
            db.Comments.Add(cm);
            db.SaveChanges();
            viewModel.Comments = from c in db.Comments where c.PostModelID == id select c;

            return View(viewModel);
        }

        //GET
        public ActionResult View(int id)
        {
            var viewModel = new PostsCommentsData();
            viewModel.post = db.Posts.Find(id);
            viewModel.Comments = from c in db.Comments where c.PostModelID == id select c;
            
            return View(viewModel);
        }

        // GET: PostModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModel postModel = db.Posts.Find(id);
            IQueryable<CommentModel> rtn = from c in db.Comments where c.PostModelID == postModel.ID select c;
            var comments = from c in db.Comments where c.PostModelID == postModel.ID select c;
            postModel.Comments = comments.ToList();
            if (postModel == null)
            {
                return HttpNotFound();
            }
            return View(postModel);
        }

        // GET: PostModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Subject,Author,AuthWebSite,PostDate,PostText,ImgLink,VidLink")] PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                postModel.PostDate = DateTime.Now;
                string [] arr = postModel.VidLink.Split('=');
                postModel.VidLink = arr[1];
                db.Posts.Add(postModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postModel);
        }

        // GET: PostModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModel postModel = db.Posts.Find(id);
            if (postModel == null)
            {
                return HttpNotFound();
            }
            return View(postModel);
        }

        // POST: PostModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Subject,Author,AuthWebSite,PostDate,PostText,ImgLink,VidLink")] PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postModel);
        }

        // GET: PostModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModel postModel = db.Posts.Find(id);
            if (postModel == null)
            {
                return HttpNotFound();
            }
            return View(postModel);
        }

        // POST: PostModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostModel postModel = db.Posts.Find(id);
            db.Posts.Remove(postModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
