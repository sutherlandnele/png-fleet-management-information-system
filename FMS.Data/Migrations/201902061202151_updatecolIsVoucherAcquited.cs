namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecolIsVoucherAcquited : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MstVehicleRefuel", "IsVoucherAcquitted", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MstVehicleRefuel", "IsVoucherAcquitted", c => c.Boolean(nullable: false));
        }
    }
}
