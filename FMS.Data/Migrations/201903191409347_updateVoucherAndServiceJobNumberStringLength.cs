namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateVoucherAndServiceJobNumberStringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MstService", "ServiceJobNumber", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.MstVehicleRefuel", "VoucherNumber", c => c.String(maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MstVehicleRefuel", "VoucherNumber", c => c.String(maxLength: 12, unicode: false));
            AlterColumn("dbo.MstService", "ServiceJobNumber", c => c.String(maxLength: 12, unicode: false));
        }
    }
}
