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
    public class Investor_ContactsController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Investor_Contacts/

        public ActionResult Index()
        {
            var investor_contacts = db.investor_contacts.Include(i => i.contact).Include(i => i.investor);
            return View(investor_contacts.ToList());
        }

        //
        // GET: /Investor_Contacts/Details/5

        public ActionResult Details(int id = 0)
        {
            investor_contacts investor_contacts = db.investor_contacts.Find(id);
            if (investor_contacts == null)
            {
                return HttpNotFound();
            }
            return View(investor_contacts);
        }

        //
        // GET: /Investor_Contacts/Create

        public ActionResult Create()
        {
            ViewBag.contactid = new SelectList(db.contacts, "id", "company");
            ViewBag.investorid = new SelectList(db.investors, "id", "name");
            return View();
        }

        //
        // POST: /Investor_Contacts/Create

        [HttpPost]
        public ActionResult Create(investor_contacts investor_contacts)
        {
            if (ModelState.IsValid)
            {
                db.investor_contacts.Add(investor_contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactid = new SelectList(db.contacts, "id", "company", investor_contacts.contactid);
            ViewBag.investorid = new SelectList(db.investors, "id", "name", investor_contacts.investorid);
            return View(investor_contacts);
        }

        //
        // GET: /Investor_Contacts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            investor_contacts investor_contacts = db.investor_contacts.Find(id);
            if (investor_contacts == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", investor_contacts.contactid);
            ViewBag.investorid = new SelectList(db.investors, "id", "name", investor_contacts.investorid);
            return View(investor_contacts);
        }

        //
        // POST: /Investor_Contacts/Edit/5

        [HttpPost]
        public ActionResult Edit(investor_contacts investor_contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investor_contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", investor_contacts.contactid);
            ViewBag.investorid = new SelectList(db.investors, "id", "name", investor_contacts.investorid);
            return View(investor_contacts);
        }

        //
        // GET: /Investor_Contacts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            investor_contacts investor_contacts = db.investor_contacts.Find(id);
            if (investor_contacts == null)
            {
                return HttpNotFound();
            }
            return View(investor_contacts);
        }

        //
        // POST: /Investor_Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            investor_contacts investor_contacts = db.investor_contacts.Find(id);
            db.investor_contacts.Remove(investor_contacts);
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