namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFileUploadColumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MstVehicle", "BosReport", c => c.Binary(maxLength: 8000));
            AlterColumn("dbo.MstVehicleDisposal", "CODReport", c => c.Binary(maxLength: 8000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MstVehicleDisposal", "CODReport", c => c.Binary(storeType: "image"));
            AlterColumn("dbo.MstVehicle", "BosReport", c => c.Binary(storeType: "image"));
        }
    }
}
