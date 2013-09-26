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
    public class Fund_ManagerController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Fund_Manager/

        public ActionResult Index()
        {
            var fund_manager = db.fund_manager.Include(f => f.fund);
            return View(fund_manager.ToList());
        }

        //
        // GET: /Fund_Manager/Details/5

        public ActionResult Details(int id = 0)
        {
            fund_manager fund_manager = db.fund_manager.Find(id);
            if (fund_manager == null)
            {
                return HttpNotFound();
            }
            return View(fund_manager);
        }

        //
        // GET: /Fund_Manager/Create

        public ActionResult Create()
        {
            ViewBag.fundid = new SelectList(db.funds, "id", "name");
            return View();
        }

        //
        // POST: /Fund_Manager/Create

        [HttpPost]
        public ActionResult Create(fund_manager fund_manager)
        {
            if (ModelState.IsValid)
            {
                db.fund_manager.Add(fund_manager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_manager.fundid);
            return View(fund_manager);
        }

        //
        // GET: /Fund_Manager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            fund_manager fund_manager = db.fund_manager.Find(id);
            if (fund_manager == null)
            {
                return HttpNotFound();
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_manager.fundid);
            return View(fund_manager);
        }

        //
        // POST: /Fund_Manager/Edit/5

        [HttpPost]
        public ActionResult Edit(fund_manager fund_manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fund_manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_manager.fundid);
            return View(fund_manager);
        }

        //
        // GET: /Fund_Manager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            fund_manager fund_manager = db.fund_manager.Find(id);
            if (fund_manager == null)
            {
                return HttpNotFound();
            }
            return View(fund_manager);
        }

        //
        // POST: /Fund_Manager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            fund_manager fund_manager = db.fund_manager.Find(id);
            db.fund_manager.Remove(fund_manager);
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