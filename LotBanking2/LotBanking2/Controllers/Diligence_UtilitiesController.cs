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
    public class Diligence_UtilitiesController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Diligence_Utilities/

        public ActionResult Index()
        {
            var diligence_utilities = db.diligence_utilities.Include(d => d.project).Include(d => d.utility_providers);
            return View(diligence_utilities.ToList());
        }

        //
        // GET: /Diligence_Utilities/Details/5

        public ActionResult Details(int id = 0)
        {
            diligence_utilities diligence_utilities = db.diligence_utilities.Find(id);
            if (diligence_utilities == null)
            {
                return HttpNotFound();
            }
            return View(diligence_utilities);
        }

        //
        // GET: /Diligence_Utilities/Create

        public ActionResult Create()
        {
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            ViewBag.providerid = new SelectList(db.utility_providers, "id", "provider");
            return View();
        }

        //
        // POST: /Diligence_Utilities/Create

        [HttpPost]
        public ActionResult Create(diligence_utilities diligence_utilities)
        {
            if (ModelState.IsValid)
            {
                db.diligence_utilities.Add(diligence_utilities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_utilities.projectid);
            ViewBag.providerid = new SelectList(db.utility_providers, "id", "provider", diligence_utilities.providerid);
            return View(diligence_utilities);
        }

        //
        // GET: /Diligence_Utilities/Edit/5

        public ActionResult Edit(int id = 0)
        {
            diligence_utilities diligence_utilities = db.diligence_utilities.Find(id);
            if (diligence_utilities == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_utilities.projectid);
            ViewBag.providerid = new SelectList(db.utility_providers, "id", "provider", diligence_utilities.providerid);
            return View(diligence_utilities);
        }

        //
        // POST: /Diligence_Utilities/Edit/5

        [HttpPost]
        public ActionResult Edit(diligence_utilities diligence_utilities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diligence_utilities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_utilities.projectid);
            ViewBag.providerid = new SelectList(db.utility_providers, "id", "provider", diligence_utilities.providerid);
            return View(diligence_utilities);
        }

        //
        // GET: /Diligence_Utilities/Delete/5

        public ActionResult Delete(int id = 0)
        {
            diligence_utilities diligence_utilities = db.diligence_utilities.Find(id);
            if (diligence_utilities == null)
            {
                return HttpNotFound();
            }
            return View(diligence_utilities);
        }

        //
        // POST: /Diligence_Utilities/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            diligence_utilities diligence_utilities = db.diligence_utilities.Find(id);
            db.diligence_utilities.Remove(diligence_utilities);
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