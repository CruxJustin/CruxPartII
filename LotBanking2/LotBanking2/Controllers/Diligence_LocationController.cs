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
    public class Diligence_LocationController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Diligence_Location/

        public ActionResult Index()
        {
            var diligence_location = db.diligence_location.Include(d => d.project);
            return View(diligence_location.ToList());
        }

        //
        // GET: /Diligence_Location/Details/5

        public ActionResult Details(int id = 0)
        {
            diligence_location diligence_location = db.diligence_location.Find(id);
            if (diligence_location == null)
            {
                return HttpNotFound();
            }
            return View(diligence_location);
        }

        //
        // GET: /Diligence_Location/Create

        public ActionResult Create()
        {
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Diligence_Location/Create

        [HttpPost]
        public ActionResult Create(diligence_location diligence_location)
        {
            if (ModelState.IsValid)
            {
                db.diligence_location.Add(diligence_location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_location.projectid);
            return View(diligence_location);
        }

        //
        // GET: /Diligence_Location/Edit/5

        public ActionResult Edit(int id = 0)
        {
            diligence_location diligence_location = db.diligence_location.Find(id);
            if (diligence_location == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_location.projectid);
            return View(diligence_location);
        }

        //
        // POST: /Diligence_Location/Edit/5

        [HttpPost]
        public ActionResult Edit(diligence_location diligence_location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diligence_location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_location.projectid);
            return View(diligence_location);
        }

        //
        // GET: /Diligence_Location/Delete/5

        public ActionResult Delete(int id = 0)
        {
            diligence_location diligence_location = db.diligence_location.Find(id);
            if (diligence_location == null)
            {
                return HttpNotFound();
            }
            return View(diligence_location);
        }

        //
        // POST: /Diligence_Location/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            diligence_location diligence_location = db.diligence_location.Find(id);
            db.diligence_location.Remove(diligence_location);
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