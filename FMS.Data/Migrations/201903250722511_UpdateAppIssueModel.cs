namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAppIssueModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppIssue", "CreatedBy", c => c.String());
            AddColumn("dbo.AppIssue", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.AppIssue", "HasBeenResolved", c => c.Boolean());
            AlterColumn("dbo.AppIssue", "Description", c => c.String(maxLength: 2000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppIssue", "Description", c => c.String());
            DropColumn("dbo.AppIssue", "HasBeenResolved");
            DropColumn("dbo.AppIssue", "CreatedDate");
            DropColumn("dbo.AppIssue", "CreatedBy");
        }
    }
}
