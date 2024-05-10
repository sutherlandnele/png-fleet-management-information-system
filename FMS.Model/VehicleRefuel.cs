namespace FMS.Model
{
    using System;


    public  class VehicleRefuel
    {
        public int Id { get; set; }

        public string DocketNumber { get; set; }

        public string VoucherNumber { get; set; }

        public string VoucherReceiptNumber { get; set; }
  
        public bool? IsVoucherAcquitted { get; set; }

        public string BowserNumber { get; set; }

        public int? VehicleId { get; set; }

        public DateTime? Date { get; set; }

        public int? OperatorId { get; set; }

        public int? Mileage { get; set; }

        public decimal? UnitCost { get; set; }

        public decimal? Liters { get; set; }

        public decimal? TotalCost { get; set; }
        public int? FuelTypeId { get; set; }
        public int? CenterId { get; set; }
        public int? FuelDistributorId { get; set; }
        public bool? IsBowserFuel { get; set; }
        public int? FuelUsageCategoryId { get; set; }
        public string RegistrationNumber { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        public virtual Center Center { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }

        public virtual ContactDetail ContactDetail1 { get; set; }

        public virtual DepotTank DepotTank { get; set; }

        public virtual SystemParameter SystemParameter { get; set; }

        public virtual SystemParameter SystemParameter1 { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
