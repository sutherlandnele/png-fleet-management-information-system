namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColMaxVehServiceCount03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MstService", "ServiceJobNumber", c => c.String(maxLength: 9, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MstService", "ServiceJobNumber");
        }
    }
}
