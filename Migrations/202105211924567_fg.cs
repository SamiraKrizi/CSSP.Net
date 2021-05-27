namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.csspClaims", "userID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.csspClaims", "userID");
        }
    }
}
