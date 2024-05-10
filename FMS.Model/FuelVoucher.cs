namespace FMS.Model
{
    using System;

    public class FuelVoucher
    {

        public int VoucherNumber { get; set; }

        public DateTime? Date { get; set; }

        public decimal? FuelAmount { get; set; }
 
        public string FuelQuantity { get; set; }

        public bool? IsVoucher { get; set; }

        public int? RegistrationNumber { get; set; }

        public int? FueltypeId { get; set; }

        public int? FuelDistributor { get; set; }

        public string Remarks { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }

        public virtual SystemParameter SystemParameter { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
