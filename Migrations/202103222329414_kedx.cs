namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kedx : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdminReplies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AdminReplies", new[] { "User_Id" });
            DropColumn("dbo.AdminReplies", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdminReplies", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AdminReplies", "User_Id");
            AddForeignKey("dbo.AdminReplies", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
