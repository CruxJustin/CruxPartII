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
    public class Trade_RefsController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Trade_Refs/

        public ActionResult Index()
        {
            var traderefs = db.traderefs.Include(t => t.builder).Include(t => t.trade_types);
            return View(traderefs.ToList());
        }

        //
        // GET: /Trade_Refs/Details/5

        public ActionResult Details(int id = 0)
        {
            traderef traderef = db.traderefs.Find(id);
            if (traderef == null)
            {
                return HttpNotFound();
            }
            return View(traderef);
        }

        //
        // GET: /Trade_Refs/Create

        public ActionResult Create()
        {
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername");
            ViewBag.tradetypeid = new SelectList(db.trade_types, "id", "id");
            return View();
        }

        //
        // POST: /Trade_Refs/Create

        [HttpPost]
        public ActionResult Create(traderef traderef)
        {
            if (ModelState.IsValid)
            {
                db.traderefs.Add(traderef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.builderid = new SelectList(db.builders, "id", "buildername", traderef.builderid);
            ViewBag.tradetypeid = new SelectList(db.trade_types, "id", "id", traderef.tradetypeid);
            return View(traderef);
        }

        //
        // GET: /Trade_Refs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            traderef traderef = db.traderefs.Find(id);
            if (traderef == null)
            {
                return HttpNotFound();
            }
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername", traderef.builderid);
            ViewBag.tradetypeid = new SelectList(db.trade_types, "id", "id", traderef.tradetypeid);
            return View(traderef);
        }

        //
        // POST: /Trade_Refs/Edit/5

        [HttpPost]
        public ActionResult Edit(traderef traderef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traderef).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername", traderef.builderid);
            ViewBag.tradetypeid = new SelectList(db.trade_types, "id", "id", traderef.tradetypeid);
            return View(traderef);
        }

        //
        // GET: /Trade_Refs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            traderef traderef = db.traderefs.Find(id);
            if (traderef == null)
            {
                return HttpNotFound();
            }
            return View(traderef);
        }

        //
        // POST: /Trade_Refs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            traderef traderef = db.traderefs.Find(id);
            db.traderefs.Remove(traderef);
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