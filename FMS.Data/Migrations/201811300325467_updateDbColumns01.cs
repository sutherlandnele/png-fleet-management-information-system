namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDbColumns01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MstVehicle", "BosReport", c => c.Binary(storeType: "image"));
            AlterColumn("dbo.MstVehicleDisposal", "CODReport", c => c.Binary(storeType: "image"));
            CreateIndex("dbo.MstVehicle", "AcquisitionTypeId");
            CreateIndex("dbo.MstVehicle", "InsuranceTypeId");
            AddForeignKey("dbo.MstVehicle", "AcquisitionTypeId", "dbo.MstSystemParameters", "Id");
            AddForeignKey("dbo.MstVehicle", "InsuranceTypeId", "dbo.MstSystemParameters", "Id");
            DropColumn("dbo.MstVehicle", "CurrentAllocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MstVehicle", "CurrentAllocationId", c => c.Int());
            DropForeignKey("dbo.MstVehicle", "InsuranceTypeId", "dbo.MstSystemParameters");
            DropForeignKey("dbo.MstVehicle", "AcquisitionTypeId", "dbo.MstSystemParameters");
            DropIndex("dbo.MstVehicle", new[] { "InsuranceTypeId" });
            DropIndex("dbo.MstVehicle", new[] { "AcquisitionTypeId" });
            AlterColumn("dbo.MstVehicleDisposal", "CODReport", c => c.String(unicode: false));
            AlterColumn("dbo.MstVehicle", "BosReport", c => c.String(unicode: false));
        }
    }
}
