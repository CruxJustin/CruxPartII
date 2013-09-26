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
    public class Diligence_HOAController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Diligence_HOA/

        public ActionResult Index()
        {
            var diligence_hoa = db.diligence_hoa.Include(d => d.project);
            return View(diligence_hoa.ToList());
        }

        //
        // GET: /Diligence_HOA/Details/5

        public ActionResult Details(int id = 0)
        {
            diligence_hoa diligence_hoa = db.diligence_hoa.Find(id);
            if (diligence_hoa == null)
            {
                return HttpNotFound();
            }
            return View(diligence_hoa);
        }

        //
        // GET: /Diligence_HOA/Create

        public ActionResult Create()
        {
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Diligence_HOA/Create

        [HttpPost]
        public ActionResult Create(diligence_hoa diligence_hoa)
        {
            if (ModelState.IsValid)
            {
                db.diligence_hoa.Add(diligence_hoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_hoa.projectid);
            return View(diligence_hoa);
        }

        //
        // GET: /Diligence_HOA/Edit/5

        public ActionResult Edit(int id = 0)
        {
            diligence_hoa diligence_hoa = db.diligence_hoa.Find(id);
            if (diligence_hoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_hoa.projectid);
            return View(diligence_hoa);
        }

        //
        // POST: /Diligence_HOA/Edit/5

        [HttpPost]
        public ActionResult Edit(diligence_hoa diligence_hoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diligence_hoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_hoa.projectid);
            return View(diligence_hoa);
        }

        //
        // GET: /Diligence_HOA/Delete/5

        public ActionResult Delete(int id = 0)
        {
            diligence_hoa diligence_hoa = db.diligence_hoa.Find(id);
            if (diligence_hoa == null)
            {
                return HttpNotFound();
            }
            return View(diligence_hoa);
        }

        //
        // POST: /Diligence_HOA/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            diligence_hoa diligence_hoa = db.diligence_hoa.Find(id);
            db.diligence_hoa.Remove(diligence_hoa);
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