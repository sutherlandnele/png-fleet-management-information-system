namespace FMS.Model
{

    public class Notification
    {
        public int Id { get; set; }

        public int? NotificationTypeId { get; set; }

        public int? WhenAppearId { get; set; }

        public int? SeverityId { get; set; }

        public int? EmailTemplateId { get; set; }

        public virtual EmailTemplate EmailTemplate { get; set; }

        public virtual SystemParameter SystemParameter { get; set; }

        public virtual SystemParameter SystemParameter1 { get; set; }

        public virtual SystemParameter SystemParameter2 { get; set; }
    }
}
