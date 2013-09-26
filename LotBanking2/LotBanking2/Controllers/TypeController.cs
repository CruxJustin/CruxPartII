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
    public class TypeController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Type/

        public ActionResult Index()
        {
            return View(db.types.ToList());
        }

        //
        // GET: /Type/Details/5

        public ActionResult Details(int id = 0)
        {
            type type = db.types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // GET: /Type/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Type/Create

        [HttpPost]
        public ActionResult Create(type type)
        {
            if (ModelState.IsValid)
            {
                db.types.Add(type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type);
        }

        //
        // GET: /Type/Edit/5

        public ActionResult Edit(int id = 0)
        {
            type type = db.types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // POST: /Type/Edit/5

        [HttpPost]
        public ActionResult Edit(type type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type);
        }

        //
        // GET: /Type/Delete/5

        public ActionResult Delete(int id = 0)
        {
            type type = db.types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        //
        // POST: /Type/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            type type = db.types.Find(id);
            db.types.Remove(type);
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