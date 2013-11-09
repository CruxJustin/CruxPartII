namespace DueDiligence_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuilderProposals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Builder = c.String(),
                        ProjectNumber = c.String(),
                        Legal = c.String(),
                        ProjectName = c.String(),
                        MPC = c.String(),
                        NumOfLots = c.Int(nullable: false),
                        Acquisitions = c.Double(nullable: false),
                        RollPrice = c.Double(nullable: false),
                        OptionDeposit = c.Double(nullable: false),
                        Improvements = c.Double(nullable: false),
                        LoanToCost = c.Double(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuilderProposals");
        }
    }
}
