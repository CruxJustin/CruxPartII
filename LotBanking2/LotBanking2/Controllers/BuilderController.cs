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
    public class BuilderController : Controller
    {
        private LotBankEntities db = new LotBankEntities();
        
        //
        // GET: /Builder/

        public ActionResult Index()
        {
            return View(db.builders.ToList());
        }

        //
        // GET: /Builder/Details/5

        public ActionResult Details(int id = 0)
        {
            builderConnect BC = new builderConnect();
            BC.find(db, id);
            if (BC == null)
            {
                return HttpNotFound();
            }
            return View(BC);
        }

        //
        // GET: /Builder/Create

        public ActionResult Create()
        {
            ViewBag.isEdit = false;
            var BC = new builderConnect();
            return View(BC);
        }

        //
        // POST: /Builder/Create

        [HttpPost]
        public ActionResult Create(builderConnect BC)
        {
            ViewBag.isEdit = false;
            if (ModelState.IsValid)
            { 
                BC.fill(db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(BC);
        }

        //
        // GET: /Builder/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.isEdit = true;
            builderConnect BC = new builderConnect();
            BC.find(db, id);
           
            if (BC.builder == null)
            {
                return HttpNotFound();
            }
            return View(BC);
        }

        //
        // POST: /Builder/Edit/5

        [HttpPost]
        public ActionResult Edit(builderConnect BC)
        {
            ViewBag.isEdit = true;
            if (ModelState.IsValid)
            {  
                BC.update(db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(BC);
        }

        //
        // GET: /Builder/Delete/5

        public ActionResult Delete(int id = 0)
        {
            builder builder = db.builders.Find(id);
            if (builder == null)
            {
                return HttpNotFound();
            }
            return View(builder);
        }

        //
        // POST: /Builder/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            builder builder = db.builders.Find(id);
            builder_contacts builder_contacts = db.builder_contacts.Where(x => x.builderid == id).First();
            var contact = builder_contacts.contact;
            db.builders.Remove(builder);
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