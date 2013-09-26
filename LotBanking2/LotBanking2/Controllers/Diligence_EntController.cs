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
    public class Diligence_EntController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Diligence_Ent/

        public ActionResult Index()
        {
            var diligence_ent = db.diligence_ent.Include(d => d.project);
            return View(diligence_ent.ToList());
        }

        //
        // GET: /Diligence_Ent/Details/5

        public ActionResult Details(int id = 0)
        {
            diligence_ent diligence_ent = db.diligence_ent.Find(id);
            if (diligence_ent == null)
            {
                return HttpNotFound();
            }
            return View(diligence_ent);
        }

        //
        // GET: /Diligence_Ent/Create

        public ActionResult Create()
        {
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Diligence_Ent/Create

        [HttpPost]
        public ActionResult Create(diligence_ent diligence_ent)
        {
            if (ModelState.IsValid)
            {
                db.diligence_ent.Add(diligence_ent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_ent.projectid);
            return View(diligence_ent);
        }

        //
        // GET: /Diligence_Ent/Edit/5

        public ActionResult Edit(int id = 0)
        {
            diligence_ent diligence_ent = db.diligence_ent.Find(id);
            if (diligence_ent == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_ent.projectid);
            return View(diligence_ent);
        }

        //
        // POST: /Diligence_Ent/Edit/5

        [HttpPost]
        public ActionResult Edit(diligence_ent diligence_ent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diligence_ent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_ent.projectid);
            return View(diligence_ent);
        }

        //
        // GET: /Diligence_Ent/Delete/5

        public ActionResult Delete(int id = 0)
        {
            diligence_ent diligence_ent = db.diligence_ent.Find(id);
            if (diligence_ent == null)
            {
                return HttpNotFound();
            }
            return View(diligence_ent);
        }

        //
        // POST: /Diligence_Ent/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            diligence_ent diligence_ent = db.diligence_ent.Find(id);
            db.diligence_ent.Remove(diligence_ent);
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