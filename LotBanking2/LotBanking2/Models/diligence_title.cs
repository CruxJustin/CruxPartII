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
    
    public partial class diligence_title
    {
        public int id { get; set; }
        public int projectid { get; set; }
        public string survey_type { get; set; }
        public Nullable<System.DateTime> survey_date { get; set; }
        public string survey_preparer { get; set; }
        public string policy_issuer { get; set; }
        public string status { get; set; }
        public string escrow_officer { get; set; }
        public string underwriter { get; set; }
        public string other { get; set; }
        public System.DateTime date_created { get; set; }
        public System.DateTime date_modified { get; set; }
    
        public virtual project project { get; set; }
    }
}
