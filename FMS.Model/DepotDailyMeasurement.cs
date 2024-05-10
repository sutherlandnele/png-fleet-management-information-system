namespace FMS.Model
{
    using System;

    public  class DepotDailyMeasurement
    {
        public int Id { get; set; }


        public string DeportTankId { get; set; }

        public int? CenterId { get; set; }

        public DateTime? Date { get; set; }

        public decimal? StartVolume { get; set; }

        public decimal? EndVolume { get; set; }

        public virtual Center Center { get; set; }

        public virtual DepotTank DepotTank { get; set; }
    }
}
