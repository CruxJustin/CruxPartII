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
    
    public partial class investor_types
    {
        public investor_types()
        {
            this.investors = new HashSet<investor>();
        }
    
        public int id { get; set; }
        public int typeid { get; set; }
    
        public virtual type type { get; set; }
        public virtual ICollection<investor> investors { get; set; }
    }
}
