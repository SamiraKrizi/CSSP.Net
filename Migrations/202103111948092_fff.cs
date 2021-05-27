namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.csspClaims", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.csspClaims", "User_Id");
            AddForeignKey("dbo.csspClaims", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.csspClaims", "UsersID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.csspClaims", "UsersID", c => c.Int(nullable: false));
            DropForeignKey("dbo.csspClaims", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.csspClaims", new[] { "User_Id" });
            DropColumn("dbo.csspClaims", "User_Id");
        }
    }
}
