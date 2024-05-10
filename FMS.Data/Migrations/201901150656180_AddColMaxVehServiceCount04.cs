namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColMaxVehServiceCount04 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MstService", "ServiceJobNumber", c => c.String(maxLength: 12, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MstService", "ServiceJobNumber", c => c.String(maxLength: 9, unicode: false));
        }
    }
}
