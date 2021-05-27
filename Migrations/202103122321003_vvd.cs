namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vvd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.csspClaims", "FileLocation");
            DropColumn("dbo.csspClaims", "FilePlant");
            DropColumn("dbo.csspClaims", "FileTerm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.csspClaims", "FileTerm", c => c.String());
            AddColumn("dbo.csspClaims", "FilePlant", c => c.String());
            AddColumn("dbo.csspClaims", "FileLocation", c => c.String());
        }
    }
}
