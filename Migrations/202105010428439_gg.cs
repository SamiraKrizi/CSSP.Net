namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.Ratings", "DatePost", c => c.DateTime(nullable: false));
            DropColumn("dbo.Ratings", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Ratings", "DatePost");
            DropColumn("dbo.Ratings", "CompanyID");
        }
    }
}
