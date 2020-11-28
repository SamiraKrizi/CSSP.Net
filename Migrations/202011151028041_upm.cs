namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.csspClaims", "DetailsId", "dbo.Details");
            DropForeignKey("dbo.csspClaims", "DocumentsId", "dbo.Documents");
            DropForeignKey("dbo.csspClaims", "OtherPartyId", "dbo.OtherParties");
            DropIndex("dbo.csspClaims", new[] { "DetailsId" });
            DropIndex("dbo.csspClaims", new[] { "OtherPartyId" });
            DropIndex("dbo.csspClaims", new[] { "DocumentsId" });
            RenameColumn(table: "dbo.csspClaims", name: "DetailsId", newName: "Details_ID");
            RenameColumn(table: "dbo.csspClaims", name: "DocumentsId", newName: "Documents_ID");
            RenameColumn(table: "dbo.csspClaims", name: "OtherPartyId", newName: "OtherParty_ID");
            AlterColumn("dbo.csspClaims", "Details_ID", c => c.Int());
            AlterColumn("dbo.csspClaims", "OtherParty_ID", c => c.Int());
            AlterColumn("dbo.csspClaims", "Documents_ID", c => c.Int());
            CreateIndex("dbo.csspClaims", "Details_ID");
            CreateIndex("dbo.csspClaims", "Documents_ID");
            CreateIndex("dbo.csspClaims", "OtherParty_ID");
            AddForeignKey("dbo.csspClaims", "Details_ID", "dbo.Details", "ID");
            AddForeignKey("dbo.csspClaims", "Documents_ID", "dbo.Documents", "ID");
            AddForeignKey("dbo.csspClaims", "OtherParty_ID", "dbo.OtherParties", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.csspClaims", "OtherParty_ID", "dbo.OtherParties");
            DropForeignKey("dbo.csspClaims", "Documents_ID", "dbo.Documents");
            DropForeignKey("dbo.csspClaims", "Details_ID", "dbo.Details");
            DropIndex("dbo.csspClaims", new[] { "OtherParty_ID" });
            DropIndex("dbo.csspClaims", new[] { "Documents_ID" });
            DropIndex("dbo.csspClaims", new[] { "Details_ID" });
            AlterColumn("dbo.csspClaims", "Documents_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.csspClaims", "OtherParty_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.csspClaims", "Details_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.csspClaims", name: "OtherParty_ID", newName: "OtherPartyId");
            RenameColumn(table: "dbo.csspClaims", name: "Documents_ID", newName: "DocumentsId");
            RenameColumn(table: "dbo.csspClaims", name: "Details_ID", newName: "DetailsId");
            CreateIndex("dbo.csspClaims", "DocumentsId");
            CreateIndex("dbo.csspClaims", "OtherPartyId");
            CreateIndex("dbo.csspClaims", "DetailsId");
            AddForeignKey("dbo.csspClaims", "OtherPartyId", "dbo.OtherParties", "ID", cascadeDelete: true);
            AddForeignKey("dbo.csspClaims", "DocumentsId", "dbo.Documents", "ID", cascadeDelete: true);
            AddForeignKey("dbo.csspClaims", "DetailsId", "dbo.Details", "ID", cascadeDelete: true);
        }
    }
}
