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
    public class emailController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /email/

        public ActionResult Index()
        {
            var emails = db.emails.Include(e => e.contact);
            return View(emails.ToList());
        }

        //
        // GET: /email/Details/5

        public ActionResult Details(int id = 0)
        {
            email email = db.emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        //
        // GET: /email/Create

        public ActionResult Create()
        {
            ViewBag.contactid = new SelectList(db.contacts, "id", "company");
            return View();
        }

        //
        // POST: /email/Create

        [HttpPost]
        public ActionResult Create(email email)
        {
            if (ModelState.IsValid)
            {
                db.emails.Add(email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactid = new SelectList(db.contacts, "id", "company", email.contactid);
            return View(email);
        }

        //
        // GET: /email/Edit/5

        public ActionResult Edit(int id = 0)
        {
            email email = db.emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", email.contactid);
            return View(email);
        }

        //
        // POST: /email/Edit/5

        [HttpPost]
        public ActionResult Edit(email email)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", email.contactid);
            return View(email);
        }

        //
        // GET: /email/Delete/5

        public ActionResult Delete(int id = 0)
        {
            email email = db.emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        //
        // POST: /email/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            email email = db.emails.Find(id);
            db.emails.Remove(email);
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