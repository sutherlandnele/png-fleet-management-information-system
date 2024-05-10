namespace FMS.Model
{


    public class IncidentFileUpload
    {
        public int Id { get; set; }

    
        public string Name { get; set; }

    
        public string ContaintType { get; set; }

        public byte[] Data { get; set; }

        public int? IncidentId { get; set; }

        public virtual Incident Incident { get; set; }
    }
}
