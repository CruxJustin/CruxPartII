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
    public class Project_SizesController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Project_Sizes/

        public ActionResult Index()
        {
            var project_sizes = db.project_sizes.Include(p => p.project);
            return View(project_sizes.ToList());
        }

        //
        // GET: /Project_Sizes/Details/5

        public ActionResult Details(int id = 0)
        {
            project_sizes project_sizes = db.project_sizes.Find(id);
            if (project_sizes == null)
            {
                return HttpNotFound();
            }
            return View(project_sizes);
        }

        //
        // GET: /Project_Sizes/Create

        public ActionResult Create()
        {
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Project_Sizes/Create

        [HttpPost]
        public ActionResult Create(project_sizes project_sizes)
        {
            if (ModelState.IsValid)
            {
                db.project_sizes.Add(project_sizes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectid = new SelectList(db.projects, "id", "name", project_sizes.projectid);
            return View(project_sizes);
        }

        //
        // GET: /Project_Sizes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            project_sizes project_sizes = db.project_sizes.Find(id);
            if (project_sizes == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", project_sizes.projectid);
            return View(project_sizes);
        }

        //
        // POST: /Project_Sizes/Edit/5

        [HttpPost]
        public ActionResult Edit(project_sizes project_sizes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project_sizes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", project_sizes.projectid);
            return View(project_sizes);
        }

        //
        // GET: /Project_Sizes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            project_sizes project_sizes = db.project_sizes.Find(id);
            if (project_sizes == null)
            {
                return HttpNotFound();
            }
            return View(project_sizes);
        }

        //
        // POST: /Project_Sizes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            project_sizes project_sizes = db.project_sizes.Find(id);
            db.project_sizes.Remove(project_sizes);
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