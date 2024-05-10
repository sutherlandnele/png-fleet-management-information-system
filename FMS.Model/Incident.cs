namespace FMS.Model
{
    using System;
    using System.Collections.Generic;

 
    public  class Incident
    {


        public int Id { get; set; }

        public int? VehicleId { get; set; }

        public DateTime? DateAndTime { get; set; }

        public int? IncidentTypeId { get; set; }


        public string Description { get; set; }

    
        public string Location { get; set; }

        public int? OperatorId { get; set; }

        public int? CenterId { get; set; }

        public int? Millege { get; set; }

        public bool? RequiredService { get; set; }

        public bool? ServiceDone { get; set; }

        public bool? HasReport { get; set; }

        public byte[] IncidentFile { get; set; }

        public string IncidentFileNumber { get; set; }

        public int? IncidentStatusId { get; set; }

        public string IncidentFileName { get; set; }

        public DateTime? DateofAccident { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }

        public virtual SystemParameter SystemParameter { get; set; }

        public virtual SystemParameter SystemParameter1 { get; set; }

        public virtual SystemParameter SystemParameter2 { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual List<IncidentFileUpload> IncidentFileUploads { get; set; }

        public virtual List<Service> Services { get; set; }
    }
}
