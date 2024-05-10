namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColMaxVehServiceCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MstCenter", "MaxVehicleServiceCount", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MstCenter", "MaxVehicleServiceCount");
        }
    }
}
