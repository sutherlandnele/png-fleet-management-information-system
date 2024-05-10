namespace FMS.Model
{
    using System;



    public class DepotRefuel
    {
        public int Id { get; set; }

        public string BowserNumber { get; set; }

        public DateTime? Date { get; set; }

        public decimal? PurchaseVolume { get; set; }

        public decimal? PreviousVolume { get; set; }

        public decimal? CurrentVolume { get; set; }

        public int? CenterId { get; set; }

        public virtual Center Center { get; set; }

        public virtual DepotTank DepotTank { get; set; }
    }
}
