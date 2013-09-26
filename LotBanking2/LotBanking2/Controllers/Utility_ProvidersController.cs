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
    public class Utility_ProvidersController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Utility_Providers/

        public ActionResult Index()
        {
            return View(db.utility_providers.ToList());
        }

        //
        // GET: /Utility_Providers/Details/5

        public ActionResult Details(int id = 0)
        {
            utility_providers utility_providers = db.utility_providers.Find(id);
            if (utility_providers == null)
            {
                return HttpNotFound();
            }
            return View(utility_providers);
        }

        //
        // GET: /Utility_Providers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Utility_Providers/Create

        [HttpPost]
        public ActionResult Create(utility_providers utility_providers)
        {
            if (ModelState.IsValid)
            {
                db.utility_providers.Add(utility_providers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utility_providers);
        }

        //
        // GET: /Utility_Providers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            utility_providers utility_providers = db.utility_providers.Find(id);
            if (utility_providers == null)
            {
                return HttpNotFound();
            }
            return View(utility_providers);
        }

        //
        // POST: /Utility_Providers/Edit/5

        [HttpPost]
        public ActionResult Edit(utility_providers utility_providers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utility_providers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utility_providers);
        }

        //
        // GET: /Utility_Providers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            utility_providers utility_providers = db.utility_providers.Find(id);
            if (utility_providers == null)
            {
                return HttpNotFound();
            }
            return View(utility_providers);
        }

        //
        // POST: /Utility_Providers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            utility_providers utility_providers = db.utility_providers.Find(id);
            db.utility_providers.Remove(utility_providers);
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