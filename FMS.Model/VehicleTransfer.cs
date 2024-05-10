namespace FMS.Model
{
    using System;



    public class VehicleTransfer
    {
        public int Id { get; set; }

        public int? VehicleId { get; set; }

        public int? BusinessGroupId { get; set; }

        public int? CenterId { get; set; }

        public DateTime? Date { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
