namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.csspClaims", "UsersID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.csspClaims", "UsersID", c => c.Int(nullable: false));
        }
    }
}
