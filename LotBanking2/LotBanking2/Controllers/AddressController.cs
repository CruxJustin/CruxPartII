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
    public class AddressController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Address/

        public ActionResult Index()
        {
            var addresses = db.addresses.Include(a => a.contact);
            return View(addresses.ToList());
        }

        //
        // GET: /Address/Details/5

        public ActionResult Details(int id = 0)
        {
            address address = db.addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            ViewBag.contactid = new SelectList(db.contacts, "id", "company");
            return View();
        }

        //
        // POST: /Address/Create

        [HttpPost]
        public ActionResult Create(address address)
        {
            if (ModelState.IsValid)
            {
                db.addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contactid = new SelectList(db.contacts, "id", "company", address.contactid);
            return View(address);
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(int id = 0)
        {
            address address = db.addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", address.contactid);
            return View(address);
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        public ActionResult Edit(address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contactid = new SelectList(db.contacts, "id", "company", address.contactid);
            return View(address);
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(int id = 0)
        {
            address address = db.addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            address address = db.addresses.Find(id);
            db.addresses.Remove(address);
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