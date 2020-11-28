namespace CbcSelfServicePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "FileName", c => c.String());
            AddColumn("dbo.Documents", "FileSize", c => c.String());
            AddColumn("dbo.Documents", "FileType", c => c.String());
            AddColumn("dbo.Documents", "LastModifiedTime", c => c.Long(nullable: false));
            AddColumn("dbo.Documents", "LastModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Documents", "FileAsBase64", c => c.String());
            AddColumn("dbo.Documents", "FileAsByteArray", c => c.Binary());
            DropColumn("dbo.Documents", "Type");
            DropColumn("dbo.Documents", "Size");
            DropColumn("dbo.Documents", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "File", c => c.Binary());
            AddColumn("dbo.Documents", "Size", c => c.Int(nullable: false));
            AddColumn("dbo.Documents", "Type", c => c.String());
            DropColumn("dbo.Documents", "FileAsByteArray");
            DropColumn("dbo.Documents", "FileAsBase64");
            DropColumn("dbo.Documents", "LastModifiedDate");
            DropColumn("dbo.Documents", "LastModifiedTime");
            DropColumn("dbo.Documents", "FileType");
            DropColumn("dbo.Documents", "FileSize");
            DropColumn("dbo.Documents", "FileName");
        }
    }
}
