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
    public class Diligence_FinancialController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Diligence_Financial/

        public ActionResult Index()
        {
            var diligence_financial = db.diligence_financial.Include(d => d.project);
            return View(diligence_financial.ToList());
        }

        //
        // GET: /Diligence_Financial/Details/5

        public ActionResult Details(int id = 0)
        {
            diligence_financial diligence_financial = db.diligence_financial.Find(id);
            if (diligence_financial == null)
            {
                return HttpNotFound();
            }
            return View(diligence_financial);
        }

        //
        // GET: /Diligence_Financial/Create

        public ActionResult Create()
        {
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Diligence_Financial/Create

        [HttpPost]
        public ActionResult Create(diligence_financial diligence_financial)
        {
            if (ModelState.IsValid)
            {
                db.diligence_financial.Add(diligence_financial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_financial.projectid);
            return View(diligence_financial);
        }

        //
        // GET: /Diligence_Financial/Edit/5

        public ActionResult Edit(int id = 0)
        {
            diligence_financial diligence_financial = db.diligence_financial.Find(id);
            if (diligence_financial == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_financial.projectid);
            return View(diligence_financial);
        }

        //
        // POST: /Diligence_Financial/Edit/5

        [HttpPost]
        public ActionResult Edit(diligence_financial diligence_financial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diligence_financial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", diligence_financial.projectid);
            return View(diligence_financial);
        }

        //
        // GET: /Diligence_Financial/Delete/5

        public ActionResult Delete(int id = 0)
        {
            diligence_financial diligence_financial = db.diligence_financial.Find(id);
            if (diligence_financial == null)
            {
                return HttpNotFound();
            }
            return View(diligence_financial);
        }

        //
        // POST: /Diligence_Financial/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            diligence_financial diligence_financial = db.diligence_financial.Find(id);
            db.diligence_financial.Remove(diligence_financial);
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