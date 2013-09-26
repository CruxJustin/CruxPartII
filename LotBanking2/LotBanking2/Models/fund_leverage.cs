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
    using System.Collections.Generic;
    
    public partial class fund_leverage
    {
        public int id { get; set; }
        public int fundid { get; set; }
        public decimal leverage_max_percentage { get; set; }
        public decimal debt { get; set; }
        public decimal interest_start { get; set; }
        public decimal loan_fee { get; set; }
        public decimal appraisal { get; set; }
        public decimal closing { get; set; }
        public decimal interest_reserve { get; set; }
        public decimal release_price { get; set; }
        public decimal total_budgeted_interest { get; set; }
        public decimal interest_to_date { get; set; }
        public decimal estimated_balance { get; set; }
        public decimal current_balance { get; set; }
        public string debt_comments { get; set; }
        public System.DateTime date_created { get; set; }
        public System.DateTime date_modified { get; set; }
    
        public virtual fund fund { get; set; }
    }
}
