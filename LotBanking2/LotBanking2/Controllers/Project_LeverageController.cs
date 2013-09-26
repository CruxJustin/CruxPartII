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
    public class Project_LeverageController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Project_Leverage/

        public ActionResult Index()
        {
            var project_leverage = db.project_leverage.Include(p => p.project);
            return View(project_leverage.ToList());
        }

        //
        // GET: /Project_Leverage/Details/5

        public ActionResult Details(int id = 0)
        {
            project_leverage project_leverage = db.project_leverage.Find(id);
            if (project_leverage == null)
            {
                return HttpNotFound();
            }
            return View(project_leverage);
        }

        //
        // GET: /Project_Leverage/Create

        public ActionResult Create()
        {
            ViewBag.projectid = new SelectList(db.projects, "id", "name");
            return View();
        }

        //
        // POST: /Project_Leverage/Create

        [HttpPost]
        public ActionResult Create(project_leverage project_leverage)
        {
            if (ModelState.IsValid)
            {
                db.project_leverage.Add(project_leverage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectid = new SelectList(db.projects, "id", "name", project_leverage.projectid);
            return View(project_leverage);
        }

        //
        // GET: /Project_Leverage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            project_leverage project_leverage = db.project_leverage.Find(id);
            if (project_leverage == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", project_leverage.projectid);
            return View(project_leverage);
        }

        //
        // POST: /Project_Leverage/Edit/5

        [HttpPost]
        public ActionResult Edit(project_leverage project_leverage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project_leverage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectid = new SelectList(db.projects, "id", "name", project_leverage.projectid);
            return View(project_leverage);
        }

        //
        // GET: /Project_Leverage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            project_leverage project_leverage = db.project_leverage.Find(id);
            if (project_leverage == null)
            {
                return HttpNotFound();
            }
            return View(project_leverage);
        }

        //
        // POST: /Project_Leverage/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            project_leverage project_leverage = db.project_leverage.Find(id);
            db.project_leverage.Remove(project_leverage);
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