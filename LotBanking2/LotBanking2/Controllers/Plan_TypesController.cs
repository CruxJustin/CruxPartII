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
    public class Plan_TypesController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Plan_Types/

        public ActionResult Index()
        {
            var plan_types = db.plan_types.Include(p => p.type);
            return View(plan_types.ToList());
        }

        //
        // GET: /Plan_Types/Details/5

        public ActionResult Details(int id = 0)
        {
            plan_types plan_types = db.plan_types.Find(id);
            if (plan_types == null)
            {
                return HttpNotFound();
            }
            return View(plan_types);
        }

        //
        // GET: /Plan_Types/Create

        public ActionResult Create()
        {
            ViewBag.typeid = new SelectList(db.types, "id", "type1");
            return View();
        }

        //
        // POST: /Plan_Types/Create

        [HttpPost]
        public ActionResult Create(plan_types plan_types)
        {
            if (ModelState.IsValid)
            {
                db.plan_types.Add(plan_types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.typeid = new SelectList(db.types, "id", "type1", plan_types.typeid);
            return View(plan_types);
        }

        //
        // GET: /Plan_Types/Edit/5

        public ActionResult Edit(int id = 0)
        {
            plan_types plan_types = db.plan_types.Find(id);
            if (plan_types == null)
            {
                return HttpNotFound();
            }
            ViewBag.typeid = new SelectList(db.types, "id", "type1", plan_types.typeid);
            return View(plan_types);
        }

        //
        // POST: /Plan_Types/Edit/5

        [HttpPost]
        public ActionResult Edit(plan_types plan_types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.typeid = new SelectList(db.types, "id", "type1", plan_types.typeid);
            return View(plan_types);
        }

        //
        // GET: /Plan_Types/Delete/5

        public ActionResult Delete(int id = 0)
        {
            plan_types plan_types = db.plan_types.Find(id);
            if (plan_types == null)
            {
                return HttpNotFound();
            }
            return View(plan_types);
        }

        //
        // POST: /Plan_Types/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            plan_types plan_types = db.plan_types.Find(id);
            db.plan_types.Remove(plan_types);
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