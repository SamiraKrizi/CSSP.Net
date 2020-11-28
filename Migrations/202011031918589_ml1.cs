namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ml1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.csspClaims", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.csspClaims", "UserID");
        }
    }
}
