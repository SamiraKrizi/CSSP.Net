namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mmc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "csspClaims_ID", "dbo.csspClaims");
            DropIndex("dbo.Ratings", new[] { "csspClaims_ID" });
            DropColumn("dbo.Ratings", "csspClaims_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "csspClaims_ID", c => c.Int());
            CreateIndex("dbo.Ratings", "csspClaims_ID");
            AddForeignKey("dbo.Ratings", "csspClaims_ID", "dbo.csspClaims", "ID");
        }
    }
}
