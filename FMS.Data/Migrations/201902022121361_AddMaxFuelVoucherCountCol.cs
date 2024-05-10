namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaxFuelVoucherCountCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MstCenter", "MaxVehicleFuelVoucherCapacityPerMonth", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MstCenter", "MaxVehicleFuelVoucherCapacityPerMonth");
        }
    }
}
