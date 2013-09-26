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
    public class MPCController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /MPC/

        public ActionResult Index()
        {
            var master_planned_communities = db.master_planned_communities.Include(m => m.builder);
            return View(master_planned_communities.ToList());
        }

        //
        // GET: /MPC/Details/5

        public ActionResult Details(int id = 0)
        {
            master_planned_communities master_planned_communities = db.master_planned_communities.Find(id);
            if (master_planned_communities == null)
            {
                return HttpNotFound();
            }
            return View(master_planned_communities);
        }

        //
        // GET: /MPC/Create

        public ActionResult Create()
        {
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername");
            return View();
        }

        //
        // POST: /MPC/Create

        [HttpPost]
        public ActionResult Create(master_planned_communities master_planned_communities)
        {
            if (ModelState.IsValid)
            {
                db.master_planned_communities.Add(master_planned_communities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.builderid = new SelectList(db.builders, "id", "buildername", master_planned_communities.builderid);
            return View(master_planned_communities);
        }

        //
        // GET: /MPC/Edit/5

        public ActionResult Edit(int id = 0)
        {
            master_planned_communities master_planned_communities = db.master_planned_communities.Find(id);
            if (master_planned_communities == null)
            {
                return HttpNotFound();
            }
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername", master_planned_communities.builderid);
            return View(master_planned_communities);
        }

        //
        // POST: /MPC/Edit/5

        [HttpPost]
        public ActionResult Edit(master_planned_communities master_planned_communities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(master_planned_communities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.builderid = new SelectList(db.builders, "id", "buildername", master_planned_communities.builderid);
            return View(master_planned_communities);
        }

        //
        // GET: /MPC/Delete/5

        public ActionResult Delete(int id = 0)
        {
            master_planned_communities master_planned_communities = db.master_planned_communities.Find(id);
            if (master_planned_communities == null)
            {
                return HttpNotFound();
            }
            return View(master_planned_communities);
        }

        //
        // POST: /MPC/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            master_planned_communities master_planned_communities = db.master_planned_communities.Find(id);
            db.master_planned_communities.Remove(master_planned_communities);
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