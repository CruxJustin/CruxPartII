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
    
    public partial class investor
    {
        public investor()
        {
            this.entities = new HashSet<entity>();
            this.funds_committed = new HashSet<funds_committed>();
            this.funds_received = new HashSet<funds_received>();
            this.investor_contacts = new HashSet<investor_contacts>();
        }
    
        public int id { get; set; }
        public int investortypeid { get; set; }
        public string name { get; set; }
        public System.DateTime date_created { get; set; }
        public System.DateTime date_modified { get; set; }
    
        public virtual ICollection<entity> entities { get; set; }
        public virtual ICollection<funds_committed> funds_committed { get; set; }
        public virtual ICollection<funds_received> funds_received { get; set; }
        public virtual ICollection<investor_contacts> investor_contacts { get; set; }
        public virtual investor_types investor_types { get; set; }
    }
}
