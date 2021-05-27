namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.csspClaims", "Reply", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.csspClaims", "Reply");
        }
    }
}
