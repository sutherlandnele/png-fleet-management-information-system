namespace FMS.Model
{
    using System;



    public class ScheduleService
    {
        public int Id { get; set; }

        public int? VehicleId { get; set; }

        public DateTime? ServiceAlertDate { get; set; }

        public int? ServiceAlertMileage { get; set; }

        public int? ScheduleServiceTypeId { get; set; }

        public int? CurrentMileage { get; set; }

        public bool? HasServiceBeenDone { get; set; }

        public virtual SystemParameter SystemParameter { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
