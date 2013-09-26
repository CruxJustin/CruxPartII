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
    public class Purchase_AgreementController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Purchase_Agreement/

        public ActionResult Index()
        {
            var purchase_agreement = db.purchase_agreement.Include(p => p.builder).Include(p => p.fund).Include(p => p.project);
            return View(purchase_agreement.ToList());
        }

        //
        // GET: /Purchase_Agreement/Details/5

        public ActionResult Details(int id = 0)
        {
            purchase_agreement purchase_agreement = db.purchase_agreement.Find(id);
            if (purchase_agreement == null)
            {
                return HttpNotFound();
            }
            return View(purchase_agreement);
        }

        //
        // GET: /Purchase_Agreement/Create

        public ActionResult Create()
        {
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername");
            ViewBag.fundid = new SelectList(db.funds, "id", "name");
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Purchase_Agreement/Create

        [HttpPost]
        public ActionResult Create(purchase_agreement purchase_agreement)
        {
            if (ModelState.IsValid)
            {
                db.purchase_agreement.Add(purchase_agreement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.builderid = new SelectList(db.builders, "id", "buildername", purchase_agreement.builderid);
            ViewBag.fundid = new SelectList(db.funds, "id", "name", purchase_agreement.fundid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", purchase_agreement.projectid);
            return View(purchase_agreement);
        }

        //
        // GET: /Purchase_Agreement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            purchase_agreement purchase_agreement = db.purchase_agreement.Find(id);
            if (purchase_agreement == null)
            {
                return HttpNotFound();
            }
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername", purchase_agreement.builderid);
            ViewBag.fundid = new SelectList(db.funds, "id", "name", purchase_agreement.fundid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", purchase_agreement.projectid);
            return View(purchase_agreement);
        }

        //
        // POST: /Purchase_Agreement/Edit/5

        [HttpPost]
        public ActionResult Edit(purchase_agreement purchase_agreement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase_agreement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername", purchase_agreement.builderid);
            ViewBag.fundid = new SelectList(db.funds, "id", "name", purchase_agreement.fundid);
            ViewBag.projectid = new SelectList(db.projects, "id", "name", purchase_agreement.projectid);
            return View(purchase_agreement);
        }

        //
        // GET: /Purchase_Agreement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            purchase_agreement purchase_agreement = db.purchase_agreement.Find(id);
            if (purchase_agreement == null)
            {
                return HttpNotFound();
            }
            return View(purchase_agreement);
        }

        //
        // POST: /Purchase_Agreement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            purchase_agreement purchase_agreement = db.purchase_agreement.Find(id);
            db.purchase_agreement.Remove(purchase_agreement);
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