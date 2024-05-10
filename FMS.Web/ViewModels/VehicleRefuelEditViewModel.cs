using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public class VehicleRefuelEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Fuel Voucher Number")]
        [UIHint("DisplayForEmphasized")]  
        public string VoucherNumber { get; set; }
        [Display(Name = "Voucher Receipt #")]      
        public string VoucherReceiptNumber { get; set; }
        [Display(Name = "Is Voucher Acquitted")]
        public bool? IsVoucherAcquitted { get; set; }
        [Display(Name = "Docket Number")]
        public string DocketNumber { get; set; }
        [Required]
        [Display(Name = "Bowser Number")]
        public string BowserNumber { get; set; }
        [Display(Name = "Vehicle Rego #")]
       
        public int? VehicleId { get; set; }
        [Required]
        [Display(Name = "Refuel Date")]        
        public DateTime? Date { get; set; }
        [Display(Name = "Operator")]
        public int? OperatorId { get; set; }
        [Display(Name = "Refuel Mileage")]
        [UIHint("NumericNullableInt32TextBox")]
        public int? Mileage { get; set; }
        [Display(Name = "Unit Cost (Kina)")]
        [Required]
        [UIHint("NumericNullableDecimalTextBox")]
        public decimal? UnitCost { get; set; }
        [Display(Name = "Litres")]
        [UIHint("NumericNullableDecimalTextBox")]
        public decimal? Liters { get; set; }
        [Display(Name = "Total Cost (Kina)")]
        [UIHint("NumericNullableDecimalTextBox")]
        public decimal? TotalCost { get; set; }
        [Display(Name = "Fuel Type")]
        public int? FuelTypeId { get; set; }
        [Required]
        [Display(Name = "Center")]       
        public int? CenterId { get; set; }
        [Required]
        [Display(Name = "Fuel Distributor")]
        public int? FuelDistributorId { get; set; }
        [Display(Name = "Is Bowser Fuel?")]
        public bool? IsBowserFuel { get; set; }        
        [Display(Name = "Fuel Usage Category")]        
        public int? FuelUsageCategoryId { get; set; }
        [Required]
        [UIHint("FuelUsageCategoryEditor")]
        public ListOfValuesDisplayViewModel FuelUsageCategory { get; set; }
        [UIHint("FuelTypeEditor")]
        public ListOfValuesDisplayViewModel FuelType { get; set; }
        [UIHint("VehicleByCenterSecurityEditor")]
        //[Required(ErrorMessage = "Vehicle registration number is required.")]
        public ListOfValuesDisplayViewModel VehicleByCenterSecurity { get; set; }
        [UIHint("DriverNonePrimitiveAddNewEditor")]
        public ListOfValuesDisplayViewModel Driver { get; set; }
        [Display(Name = "Vehicle Rego #")]
        public string RegistrationNumber { get; set; }


        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByDisplay { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDateDisplay { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime? LastUpdatedDate { get; set; }

        public VehicleDisplayInfoViewModel VehicleDisplayInfoViewModel { get; set; }        
        public VehicleRefuelEditViewModel()
        {
            this.VehicleDisplayInfoViewModel = new VehicleDisplayInfoViewModel();
        }


    }
}
