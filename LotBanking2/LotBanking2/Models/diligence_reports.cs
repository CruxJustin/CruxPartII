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
    
    public partial class diligence_reports
    {
        public int id { get; set; }
        public int projectid { get; set; }
        public int reporttypeid { get; set; }
        public string notes { get; set; }
        public System.DateTime date_created { get; set; }
        public System.DateTime date_modified { get; set; }
    
        public virtual project project { get; set; }
        public virtual report_types report_types { get; set; }
    }
}
