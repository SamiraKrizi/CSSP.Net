namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kedd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminReplies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Claim_ID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.csspClaims", t => t.Claim_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Claim_ID)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminReplies", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdminReplies", "Claim_ID", "dbo.csspClaims");
            DropIndex("dbo.AdminReplies", new[] { "User_Id" });
            DropIndex("dbo.AdminReplies", new[] { "Claim_ID" });
            DropTable("dbo.AdminReplies");
        }
    }
}
