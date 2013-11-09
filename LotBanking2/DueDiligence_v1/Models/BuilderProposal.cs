using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DueDiligence_v1.Models
{
    public class BuilderProposal
    {
        
        public int ID { get; set; }
        
        [Required]
        public string Builder { get; set; }

        [Required]
        public string ProjectNumber { get; set; }

        [Required]
        public string Legal { get; set; }

        [Required]
        public string ProjectName { get; set; }
        
        [Required]
        public string MPC { get; set; }

        //Project Overview
        [Required]
        public int NumOfLots { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Acquisitions { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double RollPrice { get; set; }

        [Required]
        public double OptionDeposit { get; set; }

        [Required]
        public double Improvements { get; set; }

        [Required]
        public double LoanToCost { get; set; }

        //Comments
        public string Comment { get; set; }


    }

    public class DueDiligenceUIContext : DbContext
    {

        public DbSet<BuilderProposal> Proposals { get; set; }

    }
}