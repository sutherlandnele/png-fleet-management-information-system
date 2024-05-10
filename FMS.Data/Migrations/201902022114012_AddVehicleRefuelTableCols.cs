namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleRefuelTableCols : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MstVehicleRefuel", "VoucherNumber", c => c.String(maxLength: 12, unicode: false));
            AddColumn("dbo.MstVehicleRefuel", "VoucherReceiptNumber", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstVehicleRefuel", "IsVoucherAcquitted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MstVehicleRefuel", "IsVoucherAcquitted");
            DropColumn("dbo.MstVehicleRefuel", "VoucherReceiptNumber");
            DropColumn("dbo.MstVehicleRefuel", "VoucherNumber");
        }
    }
}
