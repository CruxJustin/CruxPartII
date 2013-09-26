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
    public class ProjectController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Project/

        public ActionResult Index()
        {
            var projects = db.projects.Include(p => p.builder);
            return View(projects.ToList());
        }

        //
        // GET: /Project/Details/5

        public ActionResult Details(int id = 0)
        {
            project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            ViewBag.isEdit = false;
            var PD = new proj_dilConnect();
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername");
            ViewBag.mpcid = new SelectList(db.master_planned_communities, "id","name");
            return View(PD);
        }

        //
        // POST: /Project/Create

        [HttpPost]
        public ActionResult Create(proj_dilConnect PD)
        {
            ViewBag.isEdit = false;

            if (ModelState.IsValid)
            {
                PD.projectInfo(db);
                //db.projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.builderid = new SelectList(db.builders, "id", "buildername", PD.builderid);
            return View(PD);
        }

        //
        // GET: /Project/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.isEdit = true;
            proj_dilConnect PD = new proj_dilConnect();
            PD.findProj(db, id);
            if (PD.project == null)
            {
                return HttpNotFound();
            }
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername", PD.project.builderid);
            ViewBag.mpcid = new SelectList(db.master_planned_communities, "id", "name", PD.project.mpcid);
            return View(PD);
        }

        //
        // POST: /Project/Edit/5

        [HttpPost]
        public ActionResult Edit(proj_dilConnect PD)
        {
            ViewBag.isEdit = true;

            if (ModelState.IsValid)
            {
                //db.Entry(project).State = EntityState.Modified;
                PD.updateProject(db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.builderid = new SelectList(db.builders, "id", "buildername", PD.project.builderid);
            return View(PD);
        }

        //
        // GET: /Project/Delete/5

        public ActionResult Delete(int id = 0)
        {
            project project = db.projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // POST: /Project/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            project project = db.projects.Find(id);
            db.projects.Remove(project);
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