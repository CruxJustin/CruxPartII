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
    public class FundManager_ContactsController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /FundManager_Contacts/

        public ActionResult Index()
        {
            var fundmanager_contacts = db.fundmanager_contacts.Include(f => f.contact).Include(f => f.fund);
            return View(fundmanager_contacts.ToList());
        }

        //
        // GET: /FundManager_Contacts/Details/5

        public ActionResult Details(int id = 0)
        {
            fundmanager_contacts fundmanager_contacts = db.fundmanager_contacts.Find(id);
            if (fundmanager_contacts == null)
            {
                return HttpNotFound();
            }
            return View(fundmanager_contacts);
        }

        //
        // GET: /FundManager_Contacts/Create

        public ActionResult Create()
        {
            ViewBag.contactid = new SelectList(db.contacts, "id", "company");
            ViewBag.fmanagerid = new SelectList(db.funds, "id", "name");
            return View();
        }

        //
        // POST: /FundManager_Contacts/Create

        [HttpPost]
        public ActionResult Create(fundmanager_contacts fundmanager_contacts)
        {
            if (ModelState.IsValid)
            {
                db.fundmanager_contacts.Add(fundmanager_contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactid = new SelectList(db.contacts, "id", "company", fundmanager_contacts.contactid);
            ViewBag.fmanagerid = new SelectList(db.funds, "id", "name", fundmanager_contacts.fmanagerid);
            return View(fundmanager_contacts);
        }

        //
        // GET: /FundManager_Contacts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            fundmanager_contacts fundmanager_contacts = db.fundmanager_contacts.Find(id);
            if (fundmanager_contacts == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", fundmanager_contacts.contactid);
            ViewBag.fmanagerid = new SelectList(db.funds, "id", "name", fundmanager_contacts.fmanagerid);
            return View(fundmanager_contacts);
        }

        //
        // POST: /FundManager_Contacts/Edit/5

        [HttpPost]
        public ActionResult Edit(fundmanager_contacts fundmanager_contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fundmanager_contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", fundmanager_contacts.contactid);
            ViewBag.fmanagerid = new SelectList(db.funds, "id", "name", fundmanager_contacts.fmanagerid);
            return View(fundmanager_contacts);
        }

        //
        // GET: /FundManager_Contacts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            fundmanager_contacts fundmanager_contacts = db.fundmanager_contacts.Find(id);
            if (fundmanager_contacts == null)
            {
                return HttpNotFound();
            }
            return View(fundmanager_contacts);
        }

        //
        // POST: /FundManager_Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            fundmanager_contacts fundmanager_contacts = db.fundmanager_contacts.Find(id);
            db.fundmanager_contacts.Remove(fundmanager_contacts);
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