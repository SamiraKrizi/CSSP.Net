namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "csspClaims_ID", c => c.Int());
            CreateIndex("dbo.Ratings", "csspClaims_ID");
            AddForeignKey("dbo.Ratings", "csspClaims_ID", "dbo.csspClaims", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "csspClaims_ID", "dbo.csspClaims");
            DropIndex("dbo.Ratings", new[] { "csspClaims_ID" });
            DropColumn("dbo.Ratings", "csspClaims_ID");
        }
    }
}
