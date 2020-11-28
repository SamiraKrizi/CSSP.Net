namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mcd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "Type", c => c.String());
            AddColumn("dbo.Documents", "Size", c => c.Int(nullable: false));
            AddColumn("dbo.Documents", "File", c => c.Binary());
            DropColumn("dbo.Documents", "FileName");
            DropColumn("dbo.Documents", "FileSize");
            DropColumn("dbo.Documents", "FileType");
            DropColumn("dbo.Documents", "LastModifiedTime");
            DropColumn("dbo.Documents", "LastModifiedDate");
            DropColumn("dbo.Documents", "FileAsBase64");
            DropColumn("dbo.Documents", "FileAsByteArray");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "FileAsByteArray", c => c.Binary());
            AddColumn("dbo.Documents", "FileAsBase64", c => c.String());
            AddColumn("dbo.Documents", "LastModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Documents", "LastModifiedTime", c => c.Long(nullable: false));
            AddColumn("dbo.Documents", "FileType", c => c.String());
            AddColumn("dbo.Documents", "FileSize", c => c.String());
            AddColumn("dbo.Documents", "FileName", c => c.String());
            DropColumn("dbo.Documents", "File");
            DropColumn("dbo.Documents", "Size");
            DropColumn("dbo.Documents", "Type");
        }
    }
}
