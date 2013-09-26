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
    public class Funds_CommittedController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Funds_Committed/

        public ActionResult Index()
        {
            var funds_committed = db.funds_committed.Include(f => f.fund).Include(f => f.investor);
            return View(funds_committed.ToList());
        }

        //
        // GET: /Funds_Committed/Details/5

        public ActionResult Details(int id = 0)
        {
            funds_committed funds_committed = db.funds_committed.Find(id);
            if (funds_committed == null)
            {
                return HttpNotFound();
            }
            return View(funds_committed);
        }

        //
        // GET: /Funds_Committed/Create

        public ActionResult Create()
        {
            ViewBag.fundid = new SelectList(db.funds, "id", "name");
            ViewBag.investorid = new SelectList(db.investors, "id", "name");
            return View();
        }

        //
        // POST: /Funds_Committed/Create

        [HttpPost]
        public ActionResult Create(funds_committed funds_committed)
        {
            if (ModelState.IsValid)
            {
                db.funds_committed.Add(funds_committed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fundid = new SelectList(db.funds, "id", "name", funds_committed.fundid);
            ViewBag.investorid = new SelectList(db.investors, "id", "name", funds_committed.investorid);
            return View(funds_committed);
        }

        //
        // GET: /Funds_Committed/Edit/5

        public ActionResult Edit(int id = 0)
        {
            funds_committed funds_committed = db.funds_committed.Find(id);
            if (funds_committed == null)
            {
                return HttpNotFound();
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", funds_committed.fundid);
            ViewBag.investorid = new SelectList(db.investors, "id", "name", funds_committed.investorid);
            return View(funds_committed);
        }

        //
        // POST: /Funds_Committed/Edit/5

        [HttpPost]
        public ActionResult Edit(funds_committed funds_committed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funds_committed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", funds_committed.fundid);
            ViewBag.investorid = new SelectList(db.investors, "id", "name", funds_committed.investorid);
            return View(funds_committed);
        }

        //
        // GET: /Funds_Committed/Delete/5

        public ActionResult Delete(int id = 0)
        {
            funds_committed funds_committed = db.funds_committed.Find(id);
            if (funds_committed == null)
            {
                return HttpNotFound();
            }
            return View(funds_committed);
        }

        //
        // POST: /Funds_Committed/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            funds_committed funds_committed = db.funds_committed.Find(id);
            db.funds_committed.Remove(funds_committed);
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