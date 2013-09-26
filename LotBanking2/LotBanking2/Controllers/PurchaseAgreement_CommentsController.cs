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
    public class PurchaseAgreement_CommentsController : Controller
    {
        private LotBankEntities db = new LotBankEntities();

        //
        // GET: /PurchaseAgreement_Comments/

        public ActionResult Index()
        {
            var purchaseagreement_comments = db.purchaseagreement_comments.Include(p => p.comment).Include(p => p.purchase_agreement);
            return View(purchaseagreement_comments.ToList());
        }

        //
        // GET: /PurchaseAgreement_Comments/Details/5

        public ActionResult Details(int id = 0)
        {
            purchaseagreement_comments purchaseagreement_comments = db.purchaseagreement_comments.Find(id);
            if (purchaseagreement_comments == null)
            {
                return HttpNotFound();
            }
            return View(purchaseagreement_comments);
        }

        //
        // GET: /PurchaseAgreement_Comments/Create

        public ActionResult Create()
        {
            ViewBag.commentid = new SelectList(db.comments, "id", "username");
            ViewBag.agreementid = new SelectList(db.purchase_agreement, "id", "sellingentity");
            return View();
        }

        //
        // POST: /PurchaseAgreement_Comments/Create

        [HttpPost]
        public ActionResult Create(purchaseagreement_comments purchaseagreement_comments)
        {
            if (ModelState.IsValid)
            {
                db.purchaseagreement_comments.Add(purchaseagreement_comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.commentid = new SelectList(db.comments, "id", "username", purchaseagreement_comments.commentid);
            ViewBag.agreementid = new SelectList(db.purchase_agreement, "id", "sellingentity", purchaseagreement_comments.agreementid);
            return View(purchaseagreement_comments);
        }

        //
        // GET: /PurchaseAgreement_Comments/Edit/5

        public ActionResult Edit(int id = 0)
        {
            purchaseagreement_comments purchaseagreement_comments = db.purchaseagreement_comments.Find(id);
            if (purchaseagreement_comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.commentid = new SelectList(db.comments, "id", "username", purchaseagreement_comments.commentid);
            ViewBag.agreementid = new SelectList(db.purchase_agreement, "id", "sellingentity", purchaseagreement_comments.agreementid);
            return View(purchaseagreement_comments);
        }

        //
        // POST: /PurchaseAgreement_Comments/Edit/5

        [HttpPost]
        public ActionResult Edit(purchaseagreement_comments purchaseagreement_comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseagreement_comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.commentid = new SelectList(db.comments, "id", "username", purchaseagreement_comments.commentid);
            ViewBag.agreementid = new SelectList(db.purchase_agreement, "id", "sellingentity", purchaseagreement_comments.agreementid);
            return View(purchaseagreement_comments);
        }

        //
        // GET: /PurchaseAgreement_Comments/Delete/5

        public ActionResult Delete(int id = 0)
        {
            purchaseagreement_comments purchaseagreement_comments = db.purchaseagreement_comments.Find(id);
            if (purchaseagreement_comments == null)
            {
                return HttpNotFound();
            }
            return View(purchaseagreement_comments);
        }

        //
        // POST: /PurchaseAgreement_Comments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            purchaseagreement_comments purchaseagreement_comments = db.purchaseagreement_comments.Find(id);
            db.purchaseagreement_comments.Remove(purchaseagreement_comments);
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