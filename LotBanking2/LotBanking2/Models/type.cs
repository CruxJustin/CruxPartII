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
    
    public partial class type
    {
        public type()
        {
            this.company_types = new HashSet<company_types>();
            this.investor_types = new HashSet<investor_types>();
            this.plan_types = new HashSet<plan_types>();
            this.report_types = new HashSet<report_types>();
            this.trade_types = new HashSet<trade_types>();
        }
    
        public int id { get; set; }
        public string type1 { get; set; }
        public System.DateTime date_created { get; set; }
        public System.DateTime date_modified { get; set; }
    
        public virtual ICollection<company_types> company_types { get; set; }
        public virtual ICollection<investor_types> investor_types { get; set; }
        public virtual ICollection<plan_types> plan_types { get; set; }
        public virtual ICollection<report_types> report_types { get; set; }
        public virtual ICollection<trade_types> trade_types { get; set; }
    }
}
