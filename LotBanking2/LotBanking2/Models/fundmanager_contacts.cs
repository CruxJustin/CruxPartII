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
    
    public partial class fundmanager_contacts
    {
        public int id { get; set; }
        public int fmanagerid { get; set; }
        public int contactid { get; set; }
        public string description { get; set; }
    
        public virtual contact contact { get; set; }
        public virtual fund fund { get; set; }
    }
}
