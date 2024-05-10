using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class VehicleEditViewModel
    {
        #region Fields
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Asset Number")]
        public string AssetNumber { get; set; }
        [Required]
        [Display(Name = "Acquisition Date")]
        public DateTime? AcquisitionDate { get; set; }
        [Required]
        [Display(Name = "Acquisition Cost (Kina)")]
        public decimal? AcquisitionCost { get; set; }
        [Required]
        [Display(Name = "Acquisition Type")]
        public int? AcquisitionTypeId { get; set; }
        [Required]
        [Display(Name = "Supplier")]
        public int? Supplier { get; set; }
        [Required]
        [Display(Name = "Purchasing Reference")]
        public string PurchasingReferance { get; set; }
        [Required]
        [Display(Name = "Business Group")]
        public int? BusinessGroupId { get; set; }
        [Required]
        [Display(Name = "Center")]
        public int? CenterId { get; set; }
        [Required]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }        
        [HiddenInput(DisplayValue = false)]
        public DateTime? RegistrationDate { get; set; }
        [Required]
        [Display(Name = "Vehicle Color")]
        public string VehicleColor { get; set; }
        [Required]
        [Display(Name = "Vehicle Make")]
        public int? MadeId { get; set; }
        [Required]
        [Display(Name = "Vehicle Model")]
        public int? ModelId { get; set; }
        [Required]
        [Display(Name = "Fuel Type")]
        public int? FuelTypeId { get; set; }
        [Required]
        [Display(Name = "Engine Number")]
        public string EngineNumber { get; set; }
        [Required]
        [Display(Name = "Chassis Number")]
        public string ChassisNumber { get; set; }
        [Required]
        [Display(Name = "Vehicle Type")]
        public int? VehicleTypeId { get; set; }
        [Display(Name = "Transmission Type")]
        public int? TransmissionId { get; set; }
        [Required]
        [Display(Name = "Starting Mileage (kph)")]
        public decimal? StartingMileage { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? CurrentMileage { get; set; }
        [Required]
        [Display(Name = "Vehicle Operation Status")]
        public int? StatusId { get; set; }
        [Required]
        [Display(Name = "Vehicle Condition")]
        public int? ConditionId { get; set; }
        [Required]
        [Display(Name = "Vehicle Financial Status")]
        public int? FinancialStatusId { get; set; }
        [Required]
        [Display(Name = "Vehicle Usage Status")]
        public int? UsageStatusId { get; set; }
        public bool? BOS_Recommendation { get; set; }
        [Display(Name = "BOS Number")]
        public int? BOSNumber { get; set; }
        [Display(Name = "BOS Report")]
        public string BosReport { get; set; }
        public string RegistryClass { get; set; }
        public decimal? InsuranceAmmount { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public int? InsuranceTypeId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime? RegistrationExpiry { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime? SafetyStickyExpiry { get; set; }
        public DateTime? ThirdPartyInsuranceExpiry { get; set; }
        public DateTime? WarrantyExpiry { get; set; }

        public int? NextServiceId { get; set; }
        public int? LastServiceId { get; set; }
        public int? CurrentAllocationId { get; set; }
        public int? NextServiceTypeId { get; set; }
        public decimal? NextServiceMileage { get; set; }
        public decimal? LastServiceMileage { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime? LastServiceDate { get; set; }

        public bool? IsAllocated { get; set; }
        public int? FuelUsageCategoryId { get; set; }
        public decimal? CostofRegistration { get; set; }
        public decimal? CostofThirdPartyInsurance { get; set; }
        [Display(Name = "Lease Expiry Date")]
        public DateTime? LeasedExpirydate { get; set; }

        [Display(Name = "Current Mileage (kph)")]
        public string CurrentMileageDisplay { get; set; }

        [Display(Name = "Safety Sticker Expiry Date")]
        public string SafetyStickerExpiryDisplay { get; set; }

        [Display(Name = "Registration Expiry Date")]
        public string RegistrationExpiryDisplay { get; set; }

        [Display(Name = "Date In Service")]      
        public string LastServiceDateDisplay { get; set; }

        [Display(Name = "Vehicle Life (Years)")]
        public string VehicleLife { get; set; }

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

        //Extra Model View Fields
        public int? BusinessUnitId { get; set; }
        public int? RegionId { get; set; }
        #endregion

 

    }

}