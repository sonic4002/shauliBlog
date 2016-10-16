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
    public class FansModelsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: FansModels
        public ActionResult Index()
        {
            return View(db.Fans.ToList());
        }

        // GET: FansModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FansModel fansModel = db.Fans.Find(id);
            if (fansModel == null)
            {
                return HttpNotFound();
            }
            return View(fansModel);
        }

        // GET: FansModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FansModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Fname,Lname,Gender,Bdate,seniority")] FansModel fansModel)
        {
            if (ModelState.IsValid)
            {
                db.Fans.Add(fansModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fansModel);
        }

        // GET: FansModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FansModel fansModel = db.Fans.Find(id);
            if (fansModel == null)
            {
                return HttpNotFound();
            }
            return View(fansModel);
        }

        // POST: FansModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Fname,Lname,Gender,Bdate,seniority")] FansModel fansModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fansModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fansModel);
        }

        // GET: FansModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FansModel fansModel = db.Fans.Find(id);
            if (fansModel == null)
            {
                return HttpNotFound();
            }
            return View(fansModel);
        }

        // POST: FansModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FansModel fansModel = db.Fans.Find(id);
            db.Fans.Remove(fansModel);
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
