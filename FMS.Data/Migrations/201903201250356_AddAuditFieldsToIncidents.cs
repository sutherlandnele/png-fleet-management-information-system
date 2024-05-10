namespace FMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditFieldsToIncidents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MstIncident", "CreatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstIncident", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.MstIncident", "LastUpdatedBy", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.MstIncident", "LastUpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MstIncident", "LastUpdatedDate");
            DropColumn("dbo.MstIncident", "LastUpdatedBy");
            DropColumn("dbo.MstIncident", "CreatedDate");
            DropColumn("dbo.MstIncident", "CreatedBy");
        }
    }
}
