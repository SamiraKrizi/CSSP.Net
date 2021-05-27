namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.csspClaims", "AdminReply_ID", "dbo.AdminReplies");
            DropIndex("dbo.csspClaims", new[] { "AdminReply_ID" });
            DropColumn("dbo.csspClaims", "AdminReply_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.csspClaims", "AdminReply_ID", c => c.Int());
            CreateIndex("dbo.csspClaims", "AdminReply_ID");
            AddForeignKey("dbo.csspClaims", "AdminReply_ID", "dbo.AdminReplies", "ID");
        }
    }
}
