using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public  class ComplianceEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ComplianceNumber { get; set; }

        [Display(Name = "Issue Date")]
        [UIHint("NullableDateEditor")]
        public DateTime? ComplianceDate { get; set; }

        [Display(Name = "Next Expiry Date")]
        [UIHint("NullableDateEditor")]
        public DateTime? NextExpiryDate { get; set; }

        [UIHint("NumericNullableDecimalTextBox")]
        [Display(Name = "Total Amount")]
        public decimal? Amount { get; set; }

        [UIHint("VehicleIdByCenterSecurityEditor")]
        [Display(Name = "Rego #")]
        [Required]
        public int? RegistrationNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? ComplianceType { get; set; }

        [UIHint("NumericNullableDecimalTextBox")]
        [Display(Name = "TPI Amount")]
        public decimal? TPIAmount { get; set; }

        [UIHint("NumericNullableDecimalTextBox")]
        [Display(Name = "Registration Amount")]
        public decimal? RegistrationAmount { get; set; }

        [UIHint("TextAreaEditor")]
        [Display(Name = "Comment")]
        public string Comment { get; set; }

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

        public string VehicleRegoDisplay { get; set; }
    }
}
