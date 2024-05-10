namespace FMS.Model
{
    using System;



    public  class VehicleAllocation
    {
        public int Id { get; set; }

        public int? VehicleId { get; set; }

        public int? OperatorId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
