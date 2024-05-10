namespace FMS.Model
{
    using System;

    public class Service
    {
        public int Id { get; set; }

        public int? VehicleId { get; set; }

        public int? ScheduleServiceId { get; set; }

        public int? CenterId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? ServiceTypeId { get; set; }

        public int? ScheduleServiceTypeId { get; set; }

        public string ServiceJobNumber { get; set; }

        public string Description { get; set; }

        public int? ProviderId { get; set; }

        public decimal? Cost { get; set; }

        public bool? IsAmountPaid { get; set; }

        public int? CurrentMileage { get; set; }

        public int? IncidentId { get; set; }

        public bool? IsIncidentService { get; set; }

        public int? ServiceMechanic { get; set; }

   
        public string PoReference { get; set; }

        public int? BusinessGroupId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        public virtual BusinessGroup BusinessGroup { get; set; }

        public virtual Center Center { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }

        public virtual ContactDetail ContactDetail1 { get; set; }

        public virtual Incident Incident { get; set; }

        public virtual SystemParameter SystemParameter { get; set; }

        public virtual SystemParameter SystemParameter1 { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
