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
    public class Investor_TypesController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Investor_Types/

        public ActionResult Index()
        {
            var investor_types = db.investor_types.Include(i => i.type);
            return View(investor_types.ToList());
        }

        //
        // GET: /Investor_Types/Details/5

        public ActionResult Details(int id = 0)
        {
            investor_types investor_types = db.investor_types.Find(id);
            if (investor_types == null)
            {
                return HttpNotFound();
            }
            return View(investor_types);
        }

        //
        // GET: /Investor_Types/Create

        public ActionResult Create()
        {
            ViewBag.typeid = new SelectList(db.types, "id", "type1");
            return View();
        }

        //
        // POST: /Investor_Types/Create

        [HttpPost]
        public ActionResult Create(investor_types investor_types)
        {
            if (ModelState.IsValid)
            {
                db.investor_types.Add(investor_types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.typeid = new SelectList(db.types, "id", "type1", investor_types.typeid);
            return View(investor_types);
        }

        //
        // GET: /Investor_Types/Edit/5

        public ActionResult Edit(int id = 0)
        {
            investor_types investor_types = db.investor_types.Find(id);
            if (investor_types == null)
            {
                return HttpNotFound();
            }
            ViewBag.typeid = new SelectList(db.types, "id", "type1", investor_types.typeid);
            return View(investor_types);
        }

        //
        // POST: /Investor_Types/Edit/5

        [HttpPost]
        public ActionResult Edit(investor_types investor_types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investor_types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.typeid = new SelectList(db.types, "id", "type1", investor_types.typeid);
            return View(investor_types);
        }

        //
        // GET: /Investor_Types/Delete/5

        public ActionResult Delete(int id = 0)
        {
            investor_types investor_types = db.investor_types.Find(id);
            if (investor_types == null)
            {
                return HttpNotFound();
            }
            return View(investor_types);
        }

        //
        // POST: /Investor_Types/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            investor_types investor_types = db.investor_types.Find(id);
            db.investor_types.Remove(investor_types);
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