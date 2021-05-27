namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fffdv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.csspClaims", "FileLocation", c => c.String());
            AddColumn("dbo.csspClaims", "FilePlant", c => c.String());
            AddColumn("dbo.csspClaims", "FileTerm", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.csspClaims", "FileTerm");
            DropColumn("dbo.csspClaims", "FilePlant");
            DropColumn("dbo.csspClaims", "FileLocation");
        }
    }
}
