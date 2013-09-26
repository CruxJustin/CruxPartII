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
    public class Report_TypesController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Report_Types/

        public ActionResult Index()
        {
            var report_types = db.report_types.Include(r => r.type);
            return View(report_types.ToList());
        }

        //
        // GET: /Report_Types/Details/5

        public ActionResult Details(int id = 0)
        {
            report_types report_types = db.report_types.Find(id);
            if (report_types == null)
            {
                return HttpNotFound();
            }
            return View(report_types);
        }

        //
        // GET: /Report_Types/Create

        public ActionResult Create()
        {
            ViewBag.typeid = new SelectList(db.types, "id", "type1");
            return View();
        }

        //
        // POST: /Report_Types/Create

        [HttpPost]
        public ActionResult Create(report_types report_types)
        {
            if (ModelState.IsValid)
            {
                db.report_types.Add(report_types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.typeid = new SelectList(db.types, "id", "type1", report_types.typeid);
            return View(report_types);
        }

        //
        // GET: /Report_Types/Edit/5

        public ActionResult Edit(int id = 0)
        {
            report_types report_types = db.report_types.Find(id);
            if (report_types == null)
            {
                return HttpNotFound();
            }
            ViewBag.typeid = new SelectList(db.types, "id", "type1", report_types.typeid);
            return View(report_types);
        }

        //
        // POST: /Report_Types/Edit/5

        [HttpPost]
        public ActionResult Edit(report_types report_types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report_types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.typeid = new SelectList(db.types, "id", "type1", report_types.typeid);
            return View(report_types);
        }

        //
        // GET: /Report_Types/Delete/5

        public ActionResult Delete(int id = 0)
        {
            report_types report_types = db.report_types.Find(id);
            if (report_types == null)
            {
                return HttpNotFound();
            }
            return View(report_types);
        }

        //
        // POST: /Report_Types/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            report_types report_types = db.report_types.Find(id);
            db.report_types.Remove(report_types);
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