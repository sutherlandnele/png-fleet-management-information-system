namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserEmailAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Email", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Email");
        }
    }
}
