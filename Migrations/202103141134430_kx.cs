namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kx : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.csspClaims", name: "UserID", newName: "User_Id");
            RenameIndex(table: "dbo.csspClaims", name: "IX_UserID", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.csspClaims", name: "IX_User_Id", newName: "IX_UserID");
            RenameColumn(table: "dbo.csspClaims", name: "User_Id", newName: "UserID");
        }
    }
}
