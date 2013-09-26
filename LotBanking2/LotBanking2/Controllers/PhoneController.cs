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
    public class PhoneController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Phone/

        public ActionResult Index()
        {
            var phones = db.phones.Include(p => p.contact);
            return View(phones.ToList());
        }

        //
        // GET: /Phone/Details/5

        public ActionResult Details(int id = 0)
        {
            phone phone = db.phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        //
        // GET: /Phone/Create

        public ActionResult Create()
        {
            ViewBag.contactid = new SelectList(db.contacts, "id", "company");
            return View();
        }

        //
        // POST: /Phone/Create

        [HttpPost]
        public ActionResult Create(phone phone)
        {
            if (ModelState.IsValid)
            {
                db.phones.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactid = new SelectList(db.contacts, "id", "company", phone.contactid);
            return View(phone);
        }

        //
        // GET: /Phone/Edit/5

        public ActionResult Edit(int id = 0)
        {
            phone phone = db.phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", phone.contactid);
            return View(phone);
        }

        //
        // POST: /Phone/Edit/5

        [HttpPost]
        public ActionResult Edit(phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", phone.contactid);
            return View(phone);
        }

        //
        // GET: /Phone/Delete/5

        public ActionResult Delete(int id = 0)
        {
            phone phone = db.phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        //
        // POST: /Phone/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            phone phone = db.phones.Find(id);
            db.phones.Remove(phone);
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