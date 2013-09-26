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
    public class Funds_ReceivedController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Funds_Received/

        public ActionResult Index()
        {
            var funds_received = db.funds_received.Include(f => f.fund).Include(f => f.investor);
            return View(funds_received.ToList());
        }

        //
        // GET: /Funds_Received/Details/5

        public ActionResult Details(int id = 0)
        {
            funds_received funds_received = db.funds_received.Find(id);
            if (funds_received == null)
            {
                return HttpNotFound();
            }
            return View(funds_received);
        }

        //
        // GET: /Funds_Received/Create

        public ActionResult Create()
        {
            ViewBag.fundid = new SelectList(db.funds, "id", "name");
            ViewBag.investorid = new SelectList(db.investors, "id", "name");
            return View();
        }

        //
        // POST: /Funds_Received/Create

        [HttpPost]
        public ActionResult Create(funds_received funds_received)
        {
            if (ModelState.IsValid)
            {
                db.funds_received.Add(funds_received);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fundid = new SelectList(db.funds, "id", "name", funds_received.fundid);
            ViewBag.investorid = new SelectList(db.investors, "id", "name", funds_received.investorid);
            return View(funds_received);
        }

        //
        // GET: /Funds_Received/Edit/5

        public ActionResult Edit(int id = 0)
        {
            funds_received funds_received = db.funds_received.Find(id);
            if (funds_received == null)
            {
                return HttpNotFound();
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", funds_received.fundid);
            ViewBag.investorid = new SelectList(db.investors, "id", "name", funds_received.investorid);
            return View(funds_received);
        }

        //
        // POST: /Funds_Received/Edit/5

        [HttpPost]
        public ActionResult Edit(funds_received funds_received)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funds_received).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", funds_received.fundid);
            ViewBag.investorid = new SelectList(db.investors, "id", "name", funds_received.investorid);
            return View(funds_received);
        }

        //
        // GET: /Funds_Received/Delete/5

        public ActionResult Delete(int id = 0)
        {
            funds_received funds_received = db.funds_received.Find(id);
            if (funds_received == null)
            {
                return HttpNotFound();
            }
            return View(funds_received);
        }

        //
        // POST: /Funds_Received/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            funds_received funds_received = db.funds_received.Find(id);
            db.funds_received.Remove(funds_received);
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