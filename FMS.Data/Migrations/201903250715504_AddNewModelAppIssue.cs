namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewModelAppIssue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppIssue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppIssueTypeId = c.Int(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MstSystemParameters", t => t.AppIssueTypeId)
                .Index(t => t.AppIssueTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppIssue", "AppIssueTypeId", "dbo.MstSystemParameters");
            DropIndex("dbo.AppIssue", new[] { "AppIssueTypeId" });
            DropTable("dbo.AppIssue");
        }
    }
}
