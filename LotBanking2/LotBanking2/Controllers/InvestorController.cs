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
    public class InvestorController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Investor/

        public ActionResult Index()
        {
            var investors = db.investors.Include(i => i.investor_types);
            return View(investors.ToList());
        }

        //
        // GET: /Investor/Details/5

        public ActionResult Details(int id = 0)
        {
            investor investor = db.investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            return View(investor);
        }

        //
        // GET: /Investor/Create

        public ActionResult Create()
        {
            ViewBag.investortypeid = new SelectList(db.investor_types, "id", "id");
            return View();
        }

        //
        // POST: /Investor/Create

        [HttpPost]
        public ActionResult Create(investor investor)
        {
            if (ModelState.IsValid)
            {
                db.investors.Add(investor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.investortypeid = new SelectList(db.investor_types, "id", "id", investor.investortypeid);
            return View(investor);
        }

        //
        // GET: /Investor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            investor investor = db.investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            ViewBag.investortypeid = new SelectList(db.investor_types, "id", "id", investor.investortypeid);
            return View(investor);
        }

        //
        // POST: /Investor/Edit/5

        [HttpPost]
        public ActionResult Edit(investor investor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.investortypeid = new SelectList(db.investor_types, "id", "id", investor.investortypeid);
            return View(investor);
        }

        //
        // GET: /Investor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            investor investor = db.investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            return View(investor);
        }

        //
        // POST: /Investor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            investor investor = db.investors.Find(id);
            db.investors.Remove(investor);
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