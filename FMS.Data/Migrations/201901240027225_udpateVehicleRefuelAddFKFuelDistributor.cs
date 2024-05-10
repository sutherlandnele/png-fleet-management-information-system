namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udpateVehicleRefuelAddFKFuelDistributor : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MstVehicleRefuel", "FuelDistributorId");
            AddForeignKey("dbo.MstVehicleRefuel", "FuelDistributorId", "dbo.MstContactDetail", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MstVehicleRefuel", "FuelDistributorId", "dbo.MstContactDetail");
            DropIndex("dbo.MstVehicleRefuel", new[] { "FuelDistributorId" });
        }
    }
}
