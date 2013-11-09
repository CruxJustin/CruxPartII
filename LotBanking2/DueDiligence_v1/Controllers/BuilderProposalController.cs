using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DueDiligence_v1.Models;

namespace DueDiligence_v1.Controllers
{
    public class BuilderProposalController : Controller
    {
       // private DueDiligenceUIContext db = new DueDiligenceUIContext();

        private const string TempPath = @"D:\Temp";

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (HttpPostedFileBase file in files)
            {
                string filePath = Path.Combine(TempPath, file.FileName);

                System.IO.File.WriteAllBytes(filePath, ReadData(file.InputStream));
            }

            return Json("All files have been successfully stored.");
        }

        private byte[] ReadData(Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];

            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }
        /*
        // GET: /BuilderProposal/Details/5

        public ActionResult Details(int id = 0)
        {
            BuilderProposal builderproposal = db.Proposals.Find(id);
            if (builderproposal == null)
            {
                return HttpNotFound();
            }
            return View(builderproposal);
        }

        //
        // GET: /BuilderProposal/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BuilderProposal/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuilderProposal builderproposal)
        {
            if (ModelState.IsValid)
            {
                db.Proposals.Add(builderproposal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(builderproposal);
        }

        //
        // GET: /BuilderProposal/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BuilderProposal builderproposal = db.Proposals.Find(id);
            if (builderproposal == null)
            {
                return HttpNotFound();
            }
            return View(builderproposal);
        }

        //
        // POST: /BuilderProposal/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BuilderProposal builderproposal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(builderproposal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(builderproposal);
        }

        //
        // GET: /BuilderProposal/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BuilderProposal builderproposal = db.Proposals.Find(id);
            if (builderproposal == null)
            {
                return HttpNotFound();
            }
            return View(builderproposal);
        }

        //
        // POST: /BuilderProposal/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuilderProposal builderproposal = db.Proposals.Find(id);
            db.Proposals.Remove(builderproposal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult SearchIndex(string proposalBuilder, string searchString)
        {
            var BuilderLst = new List<string>();

            var BuilderQry = from b in db.Proposals
                             orderby b.Builder
                             select b.Builder;

            BuilderLst.AddRange(BuilderQry.Distinct());

            ViewBag.proposalBuilder = new SelectList(BuilderLst);

            var proposals = from m in db.Proposals
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                proposals = proposals.Where(s => s.ProjectName.Contains(searchString));
            }

            if (string.IsNullOrEmpty(proposalBuilder))
                return View(proposals);

            else
            {
                return View(proposals.Where(x => x.Builder == proposalBuilder));
            }
        }*/
    }
}