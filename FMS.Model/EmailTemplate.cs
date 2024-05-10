namespace FMS.Model
{
 
    using System.Collections.Generic;

    public class EmailTemplate    {
       
        public int Id { get; set; }

        public string TemplateName { get; set; }

 
        public string Subject { get; set; }

        public string Body { get; set; }

        public virtual List<Notification> Notifications { get; set; }
    }
}
