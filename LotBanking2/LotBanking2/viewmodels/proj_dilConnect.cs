using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LotBanking2.Models;

namespace LotBanking2.viewmodels
{
    public class proj_dilConnect
    {
        public project project { get; set; }
        public diligence_ent diligence_ent { get; set; }
        public diligence_financial diligence_financial { get; set; }
        public diligence_hoa diligence_hoa { get; set; }
        public diligence_location diligence_location { get; set; }
        public diligence_plans diligence_plans { get; set; }
        public diligence_reports diligence_reports { get; set; }
        public diligence_title diligence_title { get; set; }
        public diligence_utilities diligence_utilities { get; set; }
        

        /* Method to create a new project */
        public void projectInfo(LotBankEntities db)
        {
            this.project.date_created = DateTime.Now;
            this.project.date_modified = DateTime.Now;
            db.projects.Add(this.project);
            

            this.project.dil_ent = new diligence_ent();
           
            this.project.dil_ent.date_created = DateTime.Now;
            this.project.dil_ent.date_modified = DateTime.Now;

            /*this.project.dil_financial = new diligence_financial();
            this.project.dil_financial.date_created = DateTime.Now;
            this.project.dil_financial.date_modified = DateTime.Now;

            this.project.dil_hoa = new diligence_hoa();
            this.project.dil_hoa.date_created = DateTime.Now;
            this.project.dil_hoa.date_modified = DateTime.Now;

            this.project.dil_location.date_created = DateTime.Now;
            this.project.dil_location.date_modified = DateTime.Now;

            this.project.dil_plans.date_created = DateTime.Now;
            this.project.dil_plans.date_modified = DateTime.Now;

            this.project.dil_reports.date_created = DateTime.Now;
            this.project.dil_reports.date_modified = DateTime.Now;

            this.project.dil_title.date_created = DateTime.Now;
            this.project.dil_title.date_modified = DateTime.Now;

            this.project.dil_utilities.date_created = DateTime.Now;
            this.project.dil_utilities.date_modified = DateTime.Now;
            */

            
            db.diligence_ent.Add(this.project.dil_ent);
           /* db.diligence_financial.Add(this.project.dil_financial);
            db.diligence_hoa.Add(this.project.dil_hoa);
            db.diligence_location.Add(this.project.dil_location);
            db.diligence_plans.Add(this.project.dil_plans);
            db.diligence_reports.Add(this.project.dil_reports);
            db.diligence_title.Add(this.project.dil_title);
            db.diligence_utilities.Add(this.project.dil_utilities);*/
        }

        public void findProj(LotBankEntities db, int id)
        {
            this.project = db.projects.Find(id);
            this.project.get(db);
        }

        public void updateProject(LotBankEntities db)
        {
            var project = db.projects.Find(this.project.id);
            //var dil_ent = db.diligence_ent.Find(this.project.dil_ent.id);
            this.project.update(db);
            db.SaveChanges();
        }

    }
}
