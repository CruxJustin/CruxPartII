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
    public class PurchaseAgreement_ContactsController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /PurchaseAgreement_Contacts/

        public ActionResult Index()
        {
            var purchaseagreement_contacts = db.purchaseagreement_contacts.Include(p => p.contact).Include(p => p.purchase_agreement);
            return View(purchaseagreement_contacts.ToList());
        }

        //
        // GET: /PurchaseAgreement_Contacts/Details/5

        public ActionResult Details(int id = 0)
        {
            purchaseagreement_contacts purchaseagreement_contacts = db.purchaseagreement_contacts.Find(id);
            if (purchaseagreement_contacts == null)
            {
                return HttpNotFound();
            }
            return View(purchaseagreement_contacts);
        }

        //
        // GET: /PurchaseAgreement_Contacts/Create

        public ActionResult Create()
        {
            ViewBag.contactid = new SelectList(db.contacts, "id", "company");
            ViewBag.agreementid = new SelectList(db.purchase_agreement, "id", "sellingentity");
            return View();
        }

        //
        // POST: /PurchaseAgreement_Contacts/Create

        [HttpPost]
        public ActionResult Create(purchaseagreement_contacts purchaseagreement_contacts)
        {
            if (ModelState.IsValid)
            {
                db.purchaseagreement_contacts.Add(purchaseagreement_contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactid = new SelectList(db.contacts, "id", "company", purchaseagreement_contacts.contactid);
            ViewBag.agreementid = new SelectList(db.purchase_agreement, "id", "sellingentity", purchaseagreement_contacts.agreementid);
            return View(purchaseagreement_contacts);
        }

        //
        // GET: /PurchaseAgreement_Contacts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            purchaseagreement_contacts purchaseagreement_contacts = db.purchaseagreement_contacts.Find(id);
            if (purchaseagreement_contacts == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", purchaseagreement_contacts.contactid);
            ViewBag.agreementid = new SelectList(db.purchase_agreement, "id", "sellingentity", purchaseagreement_contacts.agreementid);
            return View(purchaseagreement_contacts);
        }

        //
        // POST: /PurchaseAgreement_Contacts/Edit/5

        [HttpPost]
        public ActionResult Edit(purchaseagreement_contacts purchaseagreement_contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseagreement_contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", purchaseagreement_contacts.contactid);
            ViewBag.agreementid = new SelectList(db.purchase_agreement, "id", "sellingentity", purchaseagreement_contacts.agreementid);
            return View(purchaseagreement_contacts);
        }

        //
        // GET: /PurchaseAgreement_Contacts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            purchaseagreement_contacts purchaseagreement_contacts = db.purchaseagreement_contacts.Find(id);
            if (purchaseagreement_contacts == null)
            {
                return HttpNotFound();
            }
            return View(purchaseagreement_contacts);
        }

        //
        // POST: /PurchaseAgreement_Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            purchaseagreement_contacts purchaseagreement_contacts = db.purchaseagreement_contacts.Find(id);
            db.purchaseagreement_contacts.Remove(purchaseagreement_contacts);
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