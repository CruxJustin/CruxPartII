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
    
    public partial class email
    {
        public int id { get; set; }
        public int contactid { get; set; }
        public string type { get; set; }
        public string email1 { get; set; }
        public System.DateTime date_created { get; set; }
        public System.DateTime date_modified { get; set; }
    
        public virtual contact contact { get; set; }
    }
}
