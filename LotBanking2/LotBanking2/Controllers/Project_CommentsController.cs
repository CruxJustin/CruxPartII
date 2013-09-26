using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LotBanking2.Models;

namespace LotBanking2.Controllers
{
    public class Project_CommentsController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Project_Comments/

        public ActionResult Index()
        {
            var project_comments = db.project_comments.Include(p => p.comment).Include(p => p.project);
            return View(project_comments.ToList());
        }

        //
        // GET: /Project_Comments/Details/5

        public ActionResult Details(int id = 0)
        {
            project_comments project_comments = db.project_comments.Find(id);
            if (project_comments == null)
            {
                return HttpNotFound();
            }
            return View(project_comments);
        }

        //
        // GET: /Project_Comments/Create

        public ActionResult Create()
        {
            ViewBag.commentid = new SelectList(db.comments, "id", "username");
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Project_Comments/Create

        [HttpPost]
        public ActionResult Create(project_comments project_comments)
        {
            if (ModelState.IsValid)
            {
                db.project_comments.Add(project_comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.commentid = new SelectList(db.comments, "id", "username", project_comments.commentid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", project_comments.projectid);
            return View(project_comments);
        }

        //
        // GET: /Project_Comments/Edit/5

        public ActionResult Edit(int id = 0)
        {
            project_comments project_comments = db.project_comments.Find(id);
            if (project_comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.commentid = new SelectList(db.comments, "id", "username", project_comments.commentid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", project_comments.projectid);
            return View(project_comments);
        }

        //
        // POST: /Project_Comments/Edit/5

        [HttpPost]
        public ActionResult Edit(project_comments project_comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project_comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.commentid = new SelectList(db.comments, "id", "username", project_comments.commentid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", project_comments.projectid);
            return View(project_comments);
        }

        //
        // GET: /Project_Comments/Delete/5

        public ActionResult Delete(int id = 0)
        {
            project_comments project_comments = db.project_comments.Find(id);
            if (project_comments == null)
            {
                return HttpNotFound();
            }
            return View(project_comments);
        }

        //
        // POST: /Project_Comments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            project_comments project_comments = db.project_comments.Find(id);
            db.project_comments.Remove(project_comments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}