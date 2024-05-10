namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFileUploadColumns02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MstVehicle", "BosReport", c => c.String(unicode: false));
            AlterColumn("dbo.MstVehicleDisposal", "CODReport", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MstVehicleDisposal", "CODReport", c => c.Binary(maxLength: 8000));
            AlterColumn("dbo.MstVehicle", "BosReport", c => c.Binary(maxLength: 8000));
        }
    }
}
