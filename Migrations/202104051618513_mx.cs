namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mx : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.csspClaims", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.csspClaims", new[] { "User_Id" });
            DropColumn("dbo.csspClaims", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.csspClaims", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.csspClaims", "User_Id");
            AddForeignKey("dbo.csspClaims", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
