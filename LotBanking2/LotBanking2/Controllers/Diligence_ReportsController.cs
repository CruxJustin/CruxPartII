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
    public class Diligence_ReportsController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Diligence_Reports/

        public ActionResult Index()
        {
            var diligence_reports = db.diligence_reports.Include(d => d.project).Include(d => d.report_types);
            return View(diligence_reports.ToList());
        }

        //
        // GET: /Diligence_Reports/Details/5

        public ActionResult Details(int id = 0)
        {
            diligence_reports diligence_reports = db.diligence_reports.Find(id);
            if (diligence_reports == null)
            {
                return HttpNotFound();
            }
            return View(diligence_reports);
        }

        //
        // GET: /Diligence_Reports/Create

        public ActionResult Create()
        {
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            ViewBag.reporttypeid = new SelectList(db.report_types, "id", "id");
            return View();
        }

        //
        // POST: /Diligence_Reports/Create

        [HttpPost]
        public ActionResult Create(diligence_reports diligence_reports)
        {
            if (ModelState.IsValid)
            {
                db.diligence_reports.Add(diligence_reports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_reports.projectid);
            ViewBag.reporttypeid = new SelectList(db.report_types, "id", "id", diligence_reports.reporttypeid);
            return View(diligence_reports);
        }

        //
        // GET: /Diligence_Reports/Edit/5

        public ActionResult Edit(int id = 0)
        {
            diligence_reports diligence_reports = db.diligence_reports.Find(id);
            if (diligence_reports == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_reports.projectid);
            ViewBag.reporttypeid = new SelectList(db.report_types, "id", "id", diligence_reports.reporttypeid);
            return View(diligence_reports);
        }

        //
        // POST: /Diligence_Reports/Edit/5

        [HttpPost]
        public ActionResult Edit(diligence_reports diligence_reports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diligence_reports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_reports.projectid);
            ViewBag.reporttypeid = new SelectList(db.report_types, "id", "id", diligence_reports.reporttypeid);
            return View(diligence_reports);
        }

        //
        // GET: /Diligence_Reports/Delete/5

        public ActionResult Delete(int id = 0)
        {
            diligence_reports diligence_reports = db.diligence_reports.Find(id);
            if (diligence_reports == null)
            {
                return HttpNotFound();
            }
            return View(diligence_reports);
        }

        //
        // POST: /Diligence_Reports/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            diligence_reports diligence_reports = db.diligence_reports.Find(id);
            db.diligence_reports.Remove(diligence_reports);
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