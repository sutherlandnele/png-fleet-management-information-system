namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MstCompliance", "CreatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstCompliance", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.MstCompliance", "LastUpdatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstCompliance", "LastUpdatedDate", c => c.DateTime());
            AddColumn("dbo.MstVehicle", "CreatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstVehicle", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.MstVehicle", "LastUpdatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstVehicle", "LastUpdatedDate", c => c.DateTime());
            AddColumn("dbo.MstService", "CreatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstService", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.MstService", "LastUpdatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstService", "LastUpdatedDate", c => c.DateTime());
            AddColumn("dbo.MstVehicleRefuel", "CreatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstVehicleRefuel", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.MstVehicleRefuel", "LastUpdatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstVehicleRefuel", "LastUpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MstVehicleRefuel", "LastUpdatedDate");
            DropColumn("dbo.MstVehicleRefuel", "LastUpdatedBy");
            DropColumn("dbo.MstVehicleRefuel", "CreatedDate");
            DropColumn("dbo.MstVehicleRefuel", "CreatedBy");
            DropColumn("dbo.MstService", "LastUpdatedDate");
            DropColumn("dbo.MstService", "LastUpdatedBy");
            DropColumn("dbo.MstService", "CreatedDate");
            DropColumn("dbo.MstService", "CreatedBy");
            DropColumn("dbo.MstVehicle", "LastUpdatedDate");
            DropColumn("dbo.MstVehicle", "LastUpdatedBy");
            DropColumn("dbo.MstVehicle", "CreatedDate");
            DropColumn("dbo.MstVehicle", "CreatedBy");
            DropColumn("dbo.MstCompliance", "LastUpdatedDate");
            DropColumn("dbo.MstCompliance", "LastUpdatedBy");
            DropColumn("dbo.MstCompliance", "CreatedDate");
            DropColumn("dbo.MstCompliance", "CreatedBy");
        }
    }
}
