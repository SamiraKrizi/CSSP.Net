namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.csspClaims", "Details_ID", "dbo.Details");
            DropForeignKey("dbo.csspClaims", "Documents_ID", "dbo.Documents");
            DropForeignKey("dbo.csspClaims", "OtherParty_ID", "dbo.OtherParties");
            DropIndex("dbo.csspClaims", new[] { "Details_ID" });
            DropIndex("dbo.csspClaims", new[] { "Documents_ID" });
            DropIndex("dbo.csspClaims", new[] { "OtherParty_ID" });
            AddColumn("dbo.csspClaims", "Location", c => c.String());
            AddColumn("dbo.csspClaims", "AccidentDate", c => c.String());
            AddColumn("dbo.csspClaims", "BodilyInjury", c => c.String());
            AddColumn("dbo.csspClaims", "Description", c => c.String());
            AddColumn("dbo.csspClaims", "VehicleRegistration", c => c.String());
            AddColumn("dbo.csspClaims", "DriverName", c => c.String());
            AddColumn("dbo.csspClaims", "PolicyHolderName", c => c.String());
            AddColumn("dbo.csspClaims", "RegistrationCountry", c => c.String());
            AddColumn("dbo.csspClaims", "File", c => c.Binary());
            DropColumn("dbo.csspClaims", "Details_ID");
            DropColumn("dbo.csspClaims", "Documents_ID");
            DropColumn("dbo.csspClaims", "OtherParty_ID");
            DropTable("dbo.Details");
            DropTable("dbo.Documents");
            DropTable("dbo.OtherParties");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OtherParties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleRegistration = c.String(),
                        DriverName = c.String(),
                        PolicyHolderName = c.String(),
                        RegistrationCountry = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Size = c.Int(nullable: false),
                        File = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        AccidentDate = c.String(),
                        BodilyInjury = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.csspClaims", "OtherParty_ID", c => c.Int());
            AddColumn("dbo.csspClaims", "Documents_ID", c => c.Int());
            AddColumn("dbo.csspClaims", "Details_ID", c => c.Int());
            DropColumn("dbo.csspClaims", "File");
            DropColumn("dbo.csspClaims", "RegistrationCountry");
            DropColumn("dbo.csspClaims", "PolicyHolderName");
            DropColumn("dbo.csspClaims", "DriverName");
            DropColumn("dbo.csspClaims", "VehicleRegistration");
            DropColumn("dbo.csspClaims", "Description");
            DropColumn("dbo.csspClaims", "BodilyInjury");
            DropColumn("dbo.csspClaims", "AccidentDate");
            DropColumn("dbo.csspClaims", "Location");
            CreateIndex("dbo.csspClaims", "OtherParty_ID");
            CreateIndex("dbo.csspClaims", "Documents_ID");
            CreateIndex("dbo.csspClaims", "Details_ID");
            AddForeignKey("dbo.csspClaims", "OtherParty_ID", "dbo.OtherParties", "ID");
            AddForeignKey("dbo.csspClaims", "Documents_ID", "dbo.Documents", "ID");
            AddForeignKey("dbo.csspClaims", "Details_ID", "dbo.Details", "ID");
        }
    }
}
