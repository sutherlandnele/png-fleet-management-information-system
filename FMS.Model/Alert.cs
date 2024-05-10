namespace FMS.Model
{

    public class Alert
    {
        public int Id { get; set; }

        public int? AlertTypeId { get; set; }

        public int? ContactId { get; set; }

        public virtual  ContactDetail MstContactDetail { get; set; }

        public virtual SystemParameter MstSystemParameter { get; set; }
    }
}
