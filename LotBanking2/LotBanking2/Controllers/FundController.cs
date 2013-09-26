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
    public class FundController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Fund/

        public ActionResult Index()
        {
            var funds = db.funds.Include(f => f.company_types);
            return View(funds.ToList());
        }

        //
        // GET: /Fund/Details/5

        public ActionResult Details(int id = 0)
        {
            fund fund = db.funds.Find(id);
            if (fund == null)
            {
                return HttpNotFound();
            }
            return View(fund);
        }

        //
        // GET: /Fund/Create

        public ActionResult Create()
        {
            ViewBag.companytypeid = new SelectList(db.company_types, "id", "id");
            return View();
        }

        //
        // POST: /Fund/Create

        [HttpPost]
        public ActionResult Create(fund fund)
        {
            if (ModelState.IsValid)
            {
                db.funds.Add(fund);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.companytypeid = new SelectList(db.company_types, "id", "id", fund.companytypeid);
            return View(fund);
        }

        //
        // GET: /Fund/Edit/5

        public ActionResult Edit(int id = 0)
        {
            fund fund = db.funds.Find(id);
            if (fund == null)
            {
                return HttpNotFound();
            }
            ViewBag.companytypeid = new SelectList(db.company_types, "id", "id", fund.companytypeid);
            return View(fund);
        }

        //
        // POST: /Fund/Edit/5

        [HttpPost]
        public ActionResult Edit(fund fund)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fund).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.companytypeid = new SelectList(db.company_types, "id", "id", fund.companytypeid);
            return View(fund);
        }

        //
        // GET: /Fund/Delete/5

        public ActionResult Delete(int id = 0)
        {
            fund fund = db.funds.Find(id);
            if (fund == null)
            {
                return HttpNotFound();
            }
            return View(fund);
        }

        //
        // POST: /Fund/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            fund fund = db.funds.Find(id);
            db.funds.Remove(fund);
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