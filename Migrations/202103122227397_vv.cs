namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vv : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.csspClaims", "ClaimDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.csspClaims", "ClaimDate", c => c.DateTime());
        }
    }
}
