namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateidentityuseragain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "LockoutEndDateUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "LockoutEndDateUtc");
        }
    }
}
