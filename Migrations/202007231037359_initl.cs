namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initl : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Documents", "FilePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "FilePath", c => c.String());
        }
    }
}
