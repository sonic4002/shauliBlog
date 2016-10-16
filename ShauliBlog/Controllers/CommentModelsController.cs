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

namespace ShauliBlog.Controllers
{
    public class CommentModelsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: CommentModels
        public ActionResult Index()
        {
            //var comments = db.Comments.Include(c => c.Post);
            return View(db.Comments.ToList());
        }

        // GET: CommentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModel commentModel = db.Comments.Find(id);
            if (commentModel == null)
            {
                return HttpNotFound();
            }
            return View(commentModel);
        }

        // GET: CommentModels/Create
        public ActionResult Create()
        {
            ViewBag.PostModelID = new SelectList(db.Posts, "ID", "Subject");
            return View();
        }

        // POST: CommentModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PostModelID,Subject,CommentAuthor,CommentAuthorWebSite,CommentText")] CommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                commentModel.CommentDate = DateTime.Now;
                db.Comments.Add(commentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostModelID = new SelectList(db.Posts, "ID", "Subject", commentModel.PostModelID);
            return View(commentModel);
        }

        // GET: CommentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModel commentModel = db.Comments.Find(id);
            if (commentModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostModelID = new SelectList(db.Posts, "ID", "Subject", commentModel.PostModelID);
            return View(commentModel);
        }

        // POST: CommentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PostModelID,Subject,CommentAuthor,CommentAuthorWebSite,CommentText")] CommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostModelID = new SelectList(db.Posts, "ID", "Subject", commentModel.PostModelID);
            return View(commentModel);
        }

        // GET: CommentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModel commentModel = db.Comments.Find(id);
            if (commentModel == null)
            {
                return HttpNotFound();
            }
            return View(commentModel);
        }

        // POST: CommentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentModel commentModel = db.Comments.Find(id);
            db.Comments.Remove(commentModel);
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
