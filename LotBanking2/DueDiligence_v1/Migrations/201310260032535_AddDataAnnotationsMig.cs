namespace DueDiligence_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BuilderProposals", "Builder", c => c.String(nullable: false));
            AlterColumn("dbo.BuilderProposals", "ProjectNumber", c => c.String(nullable: false));
            AlterColumn("dbo.BuilderProposals", "Legal", c => c.String(nullable: false));
            AlterColumn("dbo.BuilderProposals", "ProjectName", c => c.String(nullable: false));
            AlterColumn("dbo.BuilderProposals", "MPC", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BuilderProposals", "MPC", c => c.String());
            AlterColumn("dbo.BuilderProposals", "ProjectName", c => c.String());
            AlterColumn("dbo.BuilderProposals", "Legal", c => c.String());
            AlterColumn("dbo.BuilderProposals", "ProjectNumber", c => c.String());
            AlterColumn("dbo.BuilderProposals", "Builder", c => c.String());
        }
    }
}
