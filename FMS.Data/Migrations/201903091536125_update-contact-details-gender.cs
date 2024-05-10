namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecontactdetailsgender : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MstContactDetail", "Gender");
            AddForeignKey("dbo.MstContactDetail", "Gender", "dbo.MstSystemParameters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MstContactDetail", "Gender", "dbo.MstSystemParameters");
            DropIndex("dbo.MstContactDetail", new[] { "Gender" });
        }
    }
}
