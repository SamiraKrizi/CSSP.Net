namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fffd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.csspClaims", "claimUploadDate", c => c.DateTime());
            AddColumn("dbo.csspClaims", "claimUploadedBy", c => c.String());
            AlterColumn("dbo.csspClaims", "ClaimDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.csspClaims", "ClaimDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.csspClaims", "claimUploadedBy");
            DropColumn("dbo.csspClaims", "claimUploadDate");
        }
    }
}
