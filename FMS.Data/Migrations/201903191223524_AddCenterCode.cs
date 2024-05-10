namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCenterCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MstCenter", "CenterCode", c => c.String(nullable: false, maxLength: 2, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MstCenter", "CenterCode");
        }
    }
}
