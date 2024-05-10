namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColMaxVehServiceCount02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MstCenter", "MaxVehicleServiceCapacityPerMonth", c => c.Int());
            DropColumn("dbo.MstCenter", "MaxVehicleServiceCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MstCenter", "MaxVehicleServiceCount", c => c.Int());
            DropColumn("dbo.MstCenter", "MaxVehicleServiceCapacityPerMonth");
        }
    }
}
