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
    public class Diligence_TitleController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Diligence_Title/

        public ActionResult Index()
        {
            var diligence_title = db.diligence_title.Include(d => d.project);
            return View(diligence_title.ToList());
        }

        //
        // GET: /Diligence_Title/Details/5

        public ActionResult Details(int id = 0)
        {
            diligence_title diligence_title = db.diligence_title.Find(id);
            if (diligence_title == null)
            {
                return HttpNotFound();
            }
            return View(diligence_title);
        }

        //
        // GET: /Diligence_Title/Create

        public ActionResult Create()
        {
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Diligence_Title/Create

        [HttpPost]
        public ActionResult Create(diligence_title diligence_title)
        {
            if (ModelState.IsValid)
            {
                db.diligence_title.Add(diligence_title);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_title.projectid);
            return View(diligence_title);
        }

        //
        // GET: /Diligence_Title/Edit/5

        public ActionResult Edit(int id = 0)
        {
            diligence_title diligence_title = db.diligence_title.Find(id);
            if (diligence_title == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_title.projectid);
            return View(diligence_title);
        }

        //
        // POST: /Diligence_Title/Edit/5

        [HttpPost]
        public ActionResult Edit(diligence_title diligence_title)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diligence_title).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_title.projectid);
            return View(diligence_title);
        }

        //
        // GET: /Diligence_Title/Delete/5

        public ActionResult Delete(int id = 0)
        {
            diligence_title diligence_title = db.diligence_title.Find(id);
            if (diligence_title == null)
            {
                return HttpNotFound();
            }
            return View(diligence_title);
        }

        //
        // POST: /Diligence_Title/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            diligence_title diligence_title = db.diligence_title.Find(id);
            db.diligence_title.Remove(diligence_title);
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