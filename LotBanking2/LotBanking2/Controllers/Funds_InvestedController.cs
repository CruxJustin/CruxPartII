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
    public class Funds_InvestedController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Funds_Invested/

        public ActionResult Index()
        {
            var funds_invested = db.funds_invested.Include(f => f.fund).Include(f => f.project);
            return View(funds_invested.ToList());
        }

        //
        // GET: /Funds_Invested/Details/5

        public ActionResult Details(int id = 0)
        {
            funds_invested funds_invested = db.funds_invested.Find(id);
            if (funds_invested == null)
            {
                return HttpNotFound();
            }
            return View(funds_invested);
        }

        //
        // GET: /Funds_Invested/Create

        public ActionResult Create()
        {
            ViewBag.fundid = new SelectList(db.funds, "id", "name");
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Funds_Invested/Create

        [HttpPost]
        public ActionResult Create(funds_invested funds_invested)
        {
            if (ModelState.IsValid)
            {
                db.funds_invested.Add(funds_invested);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fundid = new SelectList(db.funds, "id", "name", funds_invested.fundid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", funds_invested.projectid);
            return View(funds_invested);
        }

        //
        // GET: /Funds_Invested/Edit/5

        public ActionResult Edit(int id = 0)
        {
            funds_invested funds_invested = db.funds_invested.Find(id);
            if (funds_invested == null)
            {
                return HttpNotFound();
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", funds_invested.fundid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", funds_invested.projectid);
            return View(funds_invested);
        }

        //
        // POST: /Funds_Invested/Edit/5

        [HttpPost]
        public ActionResult Edit(funds_invested funds_invested)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funds_invested).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", funds_invested.fundid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", funds_invested.projectid);
            return View(funds_invested);
        }

        //
        // GET: /Funds_Invested/Delete/5

        public ActionResult Delete(int id = 0)
        {
            funds_invested funds_invested = db.funds_invested.Find(id);
            if (funds_invested == null)
            {
                return HttpNotFound();
            }
            return View(funds_invested);
        }

        //
        // POST: /Funds_Invested/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            funds_invested funds_invested = db.funds_invested.Find(id);
            db.funds_invested.Remove(funds_invested);
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