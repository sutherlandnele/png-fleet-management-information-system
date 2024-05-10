using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace FMS.Web.ViewModels
{
    public class VehicleRefuelDisplayViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Fuel Voucher #")]
        [UIHint("DisplayForEmphasized")]
        public string VoucherNumber { get; set; }
        [Display(Name = "Voucher Receipt #")]
        public string VoucherReceiptNumber { get; set; }
        [Display(Name = "Is Voucher Acquitted")]
        public bool? IsVoucherAcquitted { get; set; }
        [Display(Name = "Docket Number")]
        public string DocketNumber { get; set; }
        [Display(Name ="Bowser Number")]
        public string BowserNumber { get; set; }
        [Display(Name = "Vehicle Rego #")]
        public string VehicleRegistrationNumber { get; set; }
        [Display(Name = "Refuel Date")]
        public string Date { get; set; }
        [Display(Name = "Driver")]
        public string Operator { get; set; }
        [Display(Name = "Refuel Mileage")]
        public string Mileage { get; set; }
        [Display(Name = "Unit Cost (Kina)")]
        public string UnitCost { get; set; }
        [Display(Name = "Litres")]
        public string Litres { get; set; }
        [Display(Name = "Total Cost (Kina)")]
        public string TotalCost { get; set; }
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }
        [Display(Name = "Center")]
        public string Center { get; set; }
        [Display(Name = "Fuel Distributor")]
        public string FuelDistributor { get; set; }
        [Display(Name = "Is Bowser Fuel?")]
        public bool? IsBowserFuel { get; set; }
        [Display(Name = "Fuel Usage Category")]
        public string FuelUsageCategory { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime? LastUpdatedDate { get; set; }

        public VehicleDisplayInfoViewModel VehicleDisplayInfoViewModel { get; set; }
        public VehicleRefuelDisplayViewModel()
        {
            this.VehicleDisplayInfoViewModel = new VehicleDisplayInfoViewModel();
        }
    }
}
