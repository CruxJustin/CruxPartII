//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LotBanking2.Models
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    
    public partial class project
    {
        public project()
        {
            this.diligence_ent = new HashSet<diligence_ent>();
            this.diligence_financial = new HashSet<diligence_financial>();
            this.diligence_hoa = new HashSet<diligence_hoa>();
            this.diligence_location = new HashSet<diligence_location>();
            this.diligence_plans = new HashSet<diligence_plans>();
            this.diligence_reports = new HashSet<diligence_reports>();
            this.diligence_title = new HashSet<diligence_title>();
            this.diligence_utilities = new HashSet<diligence_utilities>();
            this.funds_invested = new HashSet<funds_invested>();
            this.project_comments = new HashSet<project_comments>();
            this.project_leverage = new HashSet<project_leverage>();
            this.project_sizes = new HashSet<project_sizes>();
            this.purchase_agreement = new HashSet<purchase_agreement>();
        }
    
        public int id { get; set; }
        public int builderid { get; set; }
        public string legal_name { get; set; }
        public Nullable<byte> subdivision_report { get; set; }
        public System.DateTime date_created { get; set; }
        public System.DateTime date_modified { get; set; }
        public string project_name { get; set; }
        public string project_number { get; set; }
        public Nullable<int> number_of_lots { get; set; }
        public Nullable<decimal> acquisition_price { get; set; }
        public Nullable<decimal> improvement_cost { get; set; }
        public Nullable<decimal> total_cost_calc { get; set; }
        public Nullable<decimal> roll_price { get; set; }
        public Nullable<decimal> option_deposit_percent { get; set; }
        public Nullable<decimal> option_deposit_calc { get; set; }
        public Nullable<decimal> loan_to_cost_percent { get; set; }
        public Nullable<decimal> loan_to_cost_calc { get; set; }
        public Nullable<decimal> required_equity_calc { get; set; }
        public int mpcid { get; set; }
        public virtual diligence_ent dil_ent { get; set; }
        public virtual diligence_financial dil_financial { get; set; }
        public virtual diligence_hoa dil_hoa { get; set; }
        public virtual diligence_location dil_location { get; set; }
        public virtual diligence_plans dil_plans { get; set; }
        public virtual diligence_reports dil_reports { get; set; }
        public virtual diligence_title dil_title { get; set; }
        public virtual diligence_utilities dil_utilities { get; set; }
       
    
        public virtual builder builder { get; set; }
        public virtual ICollection<diligence_ent> diligence_ent { get; set; }
        public virtual ICollection<diligence_financial> diligence_financial { get; set; }
        public virtual ICollection<diligence_hoa> diligence_hoa { get; set; }
        public virtual ICollection<diligence_location> diligence_location { get; set; }
        public virtual ICollection<diligence_plans> diligence_plans { get; set; }
        public virtual ICollection<diligence_reports> diligence_reports { get; set; }
        public virtual ICollection<diligence_title> diligence_title { get; set; }
        public virtual ICollection<diligence_utilities> diligence_utilities { get; set; }
        public virtual ICollection<funds_invested> funds_invested { get; set; }
        public virtual ICollection<project_comments> project_comments { get; set; }
        public virtual ICollection<project_leverage> project_leverage { get; set; }
        public virtual ICollection<project_sizes> project_sizes { get; set; }
        public virtual ICollection<purchase_agreement> purchase_agreement { get; set; }
        public virtual master_planned_communities master_planned_communities { get; set; }

        public void get(LotBankEntities db)
        {
            //this.dil_ent = db.diligence_ent.Where(x => x.projectid == this.id).FirstOrDefault();
        }
        public void update(LotBankEntities db)
        {
            var project = db.projects.Find(this.id);
            project.date_modified = DateTime.Now;
            project.acquisition_price = this.acquisition_price;
            project.funds_invested = this.funds_invested;
            project.improvement_cost = this.improvement_cost;
            project.legal_name = this.legal_name;
            project.loan_to_cost_calc = this.loan_to_cost_calc;
            project.loan_to_cost_percent = this.loan_to_cost_percent;
            project.mpcid = this.mpcid;
            project.number_of_lots = this.number_of_lots;
            project.option_deposit_calc = this.option_deposit_calc;
            project.option_deposit_percent = this.option_deposit_percent;
            project.project_comments = this.project_comments;
            project.project_leverage = this.project_leverage;
            project.project_name = this.project_name;
            project.project_number = this.project_number;
            project.project_sizes = this.project_sizes;
            project.purchase_agreement = this.purchase_agreement;
            project.required_equity_calc = this.required_equity_calc;
            project.roll_price = this.roll_price;
            project.subdivision_report = this.subdivision_report;
            project.total_cost_calc = this.total_cost_calc;
            /*project.builder = this.builder;
            project.builderid = this.builderid;
            project.dil_ent = this.dil_ent;
            project.dil_financial = this.dil_financial;
            project.dil_hoa = this.dil_hoa;
            project.dil_location = this.dil_location;
            project.dil_plans = this.dil_plans;
            project.dil_reports = this.dil_reports;
            project.dil_title = this.dil_title;
            project.dil_utilities = this.dil_utilities;*/
        }
    }
}
