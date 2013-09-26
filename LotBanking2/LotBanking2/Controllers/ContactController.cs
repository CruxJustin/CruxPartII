using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LotBanking2.Models;
using LotBanking2.viewmodels;

namespace LotBanking2.Controllers
{
    public class ContactController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View(db.contacts.ToList());
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id = 0)
        {
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            ViewBag.isEdit = false;
            var BC = new builderConnect();
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(builderConnect BC)
        {
            ViewBag.isEdit = false;
           
            if (ModelState.IsValid)
            {
                BC.contactinfo(db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(BC);
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            
            ViewBag.isEdit = true;
            builderConnect BC = new builderConnect();
            BC.findContact(db, id);
            if (BC.contact == null)
            {
                return HttpNotFound();
            }
            return View(BC);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(builderConnect BC)
        {
            ViewBag.isEdit = true;
            if (ModelState.IsValid)
            {
                BC.updateContact(db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(BC);
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            contact contact = db.contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            contact contact = db.contacts.Find(id);
            db.contacts.Remove(contact);
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