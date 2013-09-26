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
    public class Trade_TypesController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Trade_Types/

        public ActionResult Index()
        {
            var trade_types = db.trade_types.Include(t => t.type);
            return View(trade_types.ToList());
        }

        //
        // GET: /Trade_Types/Details/5

        public ActionResult Details(int id = 0)
        {
            trade_types trade_types = db.trade_types.Find(id);
            if (trade_types == null)
            {
                return HttpNotFound();
            }
            return View(trade_types);
        }

        //
        // GET: /Trade_Types/Create

        public ActionResult Create()
        {
            ViewBag.typeid = new SelectList(db.types, "id", "type1");
            return View();
        }

        //
        // POST: /Trade_Types/Create

        [HttpPost]
        public ActionResult Create(trade_types trade_types)
        {
            if (ModelState.IsValid)
            {
                db.trade_types.Add(trade_types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.typeid = new SelectList(db.types, "id", "type1", trade_types.typeid);
            return View(trade_types);
        }

        //
        // GET: /Trade_Types/Edit/5

        public ActionResult Edit(int id = 0)
        {
            trade_types trade_types = db.trade_types.Find(id);
            if (trade_types == null)
            {
                return HttpNotFound();
            }
            ViewBag.typeid = new SelectList(db.types, "id", "type1", trade_types.typeid);
            return View(trade_types);
        }

        //
        // POST: /Trade_Types/Edit/5

        [HttpPost]
        public ActionResult Edit(trade_types trade_types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trade_types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.typeid = new SelectList(db.types, "id", "type1", trade_types.typeid);
            return View(trade_types);
        }

        //
        // GET: /Trade_Types/Delete/5

        public ActionResult Delete(int id = 0)
        {
            trade_types trade_types = db.trade_types.Find(id);
            if (trade_types == null)
            {
                return HttpNotFound();
            }
            return View(trade_types);
        }

        //
        // POST: /Trade_Types/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            trade_types trade_types = db.trade_types.Find(id);
            db.trade_types.Remove(trade_types);
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