namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fgd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.csspClaims", "userID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.csspClaims", "userID", c => c.String());
        }
    }
}
