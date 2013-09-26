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
    public class Fund_LeverageController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Fund_Leverage/

        public ActionResult Index()
        {
            var fund_leverage = db.fund_leverage.Include(f => f.fund);
            return View(fund_leverage.ToList());
        }

        //
        // GET: /Fund_Leverage/Details/5

        public ActionResult Details(int id = 0)
        {
            fund_leverage fund_leverage = db.fund_leverage.Find(id);
            if (fund_leverage == null)
            {
                return HttpNotFound();
            }
            return View(fund_leverage);
        }

        //
        // GET: /Fund_Leverage/Create

        public ActionResult Create()
        {
            ViewBag.fundid = new SelectList(db.funds, "id", "name");
            return View();
        }

        //
        // POST: /Fund_Leverage/Create

        [HttpPost]
        public ActionResult Create(fund_leverage fund_leverage)
        {
            if (ModelState.IsValid)
            {
                db.fund_leverage.Add(fund_leverage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_leverage.fundid);
            return View(fund_leverage);
        }

        //
        // GET: /Fund_Leverage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            fund_leverage fund_leverage = db.fund_leverage.Find(id);
            if (fund_leverage == null)
            {
                return HttpNotFound();
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_leverage.fundid);
            return View(fund_leverage);
        }

        //
        // POST: /Fund_Leverage/Edit/5

        [HttpPost]
        public ActionResult Edit(fund_leverage fund_leverage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fund_leverage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_leverage.fundid);
            return View(fund_leverage);
        }

        //
        // GET: /Fund_Leverage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            fund_leverage fund_leverage = db.fund_leverage.Find(id);
            if (fund_leverage == null)
            {
                return HttpNotFound();
            }
            return View(fund_leverage);
        }

        //
        // POST: /Fund_Leverage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            fund_leverage fund_leverage = db.fund_leverage.Find(id);
            db.fund_leverage.Remove(fund_leverage);
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