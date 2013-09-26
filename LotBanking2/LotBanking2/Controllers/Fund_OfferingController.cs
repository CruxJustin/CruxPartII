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
    public class Fund_OfferingController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Fund_Offering/

        public ActionResult Index()
        {
            var fund_offering = db.fund_offering.Include(f => f.fund);
            return View(fund_offering.ToList());
        }

        //
        // GET: /Fund_Offering/Details/5

        public ActionResult Details(int id = 0)
        {
            fund_offering fund_offering = db.fund_offering.Find(id);
            if (fund_offering == null)
            {
                return HttpNotFound();
            }
            return View(fund_offering);
        }

        //
        // GET: /Fund_Offering/Create

        public ActionResult Create()
        {
            ViewBag.fundid = new SelectList(db.funds, "id", "name");
            return View();
        }

        //
        // POST: /Fund_Offering/Create

        [HttpPost]
        public ActionResult Create(fund_offering fund_offering)
        {
            if (ModelState.IsValid)
            {
                db.fund_offering.Add(fund_offering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_offering.fundid);
            return View(fund_offering);
        }

        //
        // GET: /Fund_Offering/Edit/5

        public ActionResult Edit(int id = 0)
        {
            fund_offering fund_offering = db.fund_offering.Find(id);
            if (fund_offering == null)
            {
                return HttpNotFound();
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_offering.fundid);
            return View(fund_offering);
        }

        //
        // POST: /Fund_Offering/Edit/5

        [HttpPost]
        public ActionResult Edit(fund_offering fund_offering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fund_offering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_offering.fundid);
            return View(fund_offering);
        }

        //
        // GET: /Fund_Offering/Delete/5

        public ActionResult Delete(int id = 0)
        {
            fund_offering fund_offering = db.fund_offering.Find(id);
            if (fund_offering == null)
            {
                return HttpNotFound();
            }
            return View(fund_offering);
        }

        //
        // POST: /Fund_Offering/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            fund_offering fund_offering = db.fund_offering.Find(id);
            db.fund_offering.Remove(fund_offering);
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