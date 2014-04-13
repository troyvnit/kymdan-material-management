namespace KMM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterialProposals", "Approved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaterialProposals", "Approved");
        }
    }
}
