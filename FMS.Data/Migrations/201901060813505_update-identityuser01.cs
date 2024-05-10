namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateidentityuser01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "LastLoginTime", c => c.DateTime());
            AddColumn("dbo.User", "RegistrationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "RegistrationDate");
            DropColumn("dbo.User", "LastLoginTime");
        }
    }
}
