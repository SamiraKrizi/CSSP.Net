namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdminReplies", "Claim_ID", "dbo.csspClaims");
            DropIndex("dbo.AdminReplies", new[] { "Claim_ID" });
            AddColumn("dbo.csspClaims", "AdminReply_ID", c => c.Int());
            CreateIndex("dbo.csspClaims", "AdminReply_ID");
            AddForeignKey("dbo.csspClaims", "AdminReply_ID", "dbo.AdminReplies", "ID");
            DropColumn("dbo.AdminReplies", "Claim_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdminReplies", "Claim_ID", c => c.Int());
            DropForeignKey("dbo.csspClaims", "AdminReply_ID", "dbo.AdminReplies");
            DropIndex("dbo.csspClaims", new[] { "AdminReply_ID" });
            DropColumn("dbo.csspClaims", "AdminReply_ID");
            CreateIndex("dbo.AdminReplies", "Claim_ID");
            AddForeignKey("dbo.AdminReplies", "Claim_ID", "dbo.csspClaims", "ID");
        }
    }
}
