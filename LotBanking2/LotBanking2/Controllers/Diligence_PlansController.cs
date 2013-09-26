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
    public class Diligence_PlansController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Diligence_Plans/

        public ActionResult Index()
        {
            var diligence_plans = db.diligence_plans.Include(d => d.plan_types).Include(d => d.project);
            return View(diligence_plans.ToList());
        }

        //
        // GET: /Diligence_Plans/Details/5

        public ActionResult Details(int id = 0)
        {
            diligence_plans diligence_plans = db.diligence_plans.Find(id);
            if (diligence_plans == null)
            {
                return HttpNotFound();
            }
            return View(diligence_plans);
        }

        //
        // GET: /Diligence_Plans/Create

        public ActionResult Create()
        {
            ViewBag.plantypeid = new SelectList(db.plan_types, "id", "id");
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Diligence_Plans/Create

        [HttpPost]
        public ActionResult Create(diligence_plans diligence_plans)
        {
            if (ModelState.IsValid)
            {
                db.diligence_plans.Add(diligence_plans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.plantypeid = new SelectList(db.plan_types, "id", "id", diligence_plans.plantypeid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_plans.projectid);
            return View(diligence_plans);
        }

        //
        // GET: /Diligence_Plans/Edit/5

        public ActionResult Edit(int id = 0)
        {
            diligence_plans diligence_plans = db.diligence_plans.Find(id);
            if (diligence_plans == null)
            {
                return HttpNotFound();
            }
            ViewBag.plantypeid = new SelectList(db.plan_types, "id", "id", diligence_plans.plantypeid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_plans.projectid);
            return View(diligence_plans);
        }

        //
        // POST: /Diligence_Plans/Edit/5

        [HttpPost]
        public ActionResult Edit(diligence_plans diligence_plans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diligence_plans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.plantypeid = new SelectList(db.plan_types, "id", "id", diligence_plans.plantypeid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_plans.projectid);
            return View(diligence_plans);
        }

        //
        // GET: /Diligence_Plans/Delete/5

        public ActionResult Delete(int id = 0)
        {
            diligence_plans diligence_plans = db.diligence_plans.Find(id);
            if (diligence_plans == null)
            {
                return HttpNotFound();
            }
            return View(diligence_plans);
        }

        //
        // POST: /Diligence_Plans/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            diligence_plans diligence_plans = db.diligence_plans.Find(id);
            db.diligence_plans.Remove(diligence_plans);
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