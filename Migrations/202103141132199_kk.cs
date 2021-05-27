namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kk : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.csspClaims", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.csspClaims", name: "IX_User_Id", newName: "IX_UserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.csspClaims", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.csspClaims", name: "UserID", newName: "User_Id");
        }
    }
}
