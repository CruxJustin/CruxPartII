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
    public class Fund_commentsController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /Fund_comments/

        public ActionResult Index()
        {
            var fund_comments = db.fund_comments.Include(f => f.comment).Include(f => f.fund);
            return View(fund_comments.ToList());
        }

        //
        // GET: /Fund_comments/Details/5

        public ActionResult Details(int id = 0)
        {
            fund_comments fund_comments = db.fund_comments.Find(id);
            if (fund_comments == null)
            {
                return HttpNotFound();
            }
            return View(fund_comments);
        }

        //
        // GET: /Fund_comments/Create

        public ActionResult Create()
        {
            ViewBag.commentid = new SelectList(db.comments, "id", "username");
            ViewBag.fundid = new SelectList(db.funds, "id", "name");
            return View();
        }

        //
        // POST: /Fund_comments/Create

        [HttpPost]
        public ActionResult Create(fund_comments fund_comments)
        {
            if (ModelState.IsValid)
            {
                db.fund_comments.Add(fund_comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.commentid = new SelectList(db.comments, "id", "username", fund_comments.commentid);
            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_comments.fundid);
            return View(fund_comments);
        }

        //
        // GET: /Fund_comments/Edit/5

        public ActionResult Edit(int id = 0)
        {
            fund_comments fund_comments = db.fund_comments.Find(id);
            if (fund_comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.commentid = new SelectList(db.comments, "id", "username", fund_comments.commentid);
            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_comments.fundid);
            return View(fund_comments);
        }

        //
        // POST: /Fund_comments/Edit/5

        [HttpPost]
        public ActionResult Edit(fund_comments fund_comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fund_comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.commentid = new SelectList(db.comments, "id", "username", fund_comments.commentid);
            ViewBag.fundid = new SelectList(db.funds, "id", "name", fund_comments.fundid);
            return View(fund_comments);
        }

        //
        // GET: /Fund_comments/Delete/5

        public ActionResult Delete(int id = 0)
        {
            fund_comments fund_comments = db.fund_comments.Find(id);
            if (fund_comments == null)
            {
                return HttpNotFound();
            }
            return View(fund_comments);
        }

        //
        // POST: /Fund_comments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            fund_comments fund_comments = db.fund_comments.Find(id);
            db.fund_comments.Remove(fund_comments);
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