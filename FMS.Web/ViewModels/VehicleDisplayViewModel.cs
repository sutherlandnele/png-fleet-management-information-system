using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public class VehicleDisplayViewModel
    {
       
        #region Fields
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Region")]
        public string Region { get; set; } //calculate using CenterNumber
        [Display(Name = "Business Unit")]
        public string BusinessUnit { get; set; } //calculate using GroupNumber
        [Display(Name = "Business Group")]
        public string BusinessGroup { get; set; }
        [Display(Name = "Center")]
        public string Center { get; set; }
        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }
        [Display(Name = "Make")]
        public string Make { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Current Mileage")]
        public int? CurrentMileage { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Vehicle Condition")]
        public string Condition { get; set; }       
        public string BOS_Recommendation { get; set; }
        [Display(Name = "BOS Number")]
        public int? BOSNumber { get; set; }
        [Display(Name = "BOS Report")]
        public string BosReport { get; set; }
        [Display(Name = "Asset Number")]
        public string AssetNumber { get; set; }
        [Display(Name = "Acquisition Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string AcquisitionDate { get; set; }
        [Display(Name = "Acquisition Cost")]
        public decimal? AcquisitionCost { get; set; }
        [Display(Name = "Acquisition Type")]
        public string AcquisitionType { get; set; }
        [Display(Name = "Supplier")]
        public string Supplier { get; set; }
        [Display(Name = "Purchase Reference")]
        public string PurchasingReferance { get; set; }
        [Display(Name = "Vehicle Color")]
        public string VehicleColor { get; set; }
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }
        [Display(Name = "Transmission")]
        public string Transmission { get; set; }
        [Display(Name = "Registration Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string RegistrationDate { get; set; }
        [Display(Name = "Registry Class")]
        public string RegistryClass { get; set; }
        [Display(Name = "Engine Number")]
        public string EngineNumber { get; set; }
        [Display(Name = "Chassis Number")]
        public string ChassisNumber { get; set; }
        [Display(Name = "Starting Mileage")]
        public decimal? StartingMileage { get; set; }
        [Display(Name = "Insurance Amount")]
        public decimal? InsuranceAmmount { get; set; }
        [Display(Name = "Insurance Type")]
        public string InsuranceType { get; set; } //need to fix Vehicle model class to include Insurance Type object member and also fix configuration
        [Display(Name = "Registration Expiry")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string RegistrationExpiry { get; set; }
        [Display(Name = "Safety Sticker Expiry")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string SafetyStickyExpiry { get; set; }
        [Display(Name = "Third Party Insurance Expiry")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? ThirdPartyInsuranceExpiry { get; set; }
        [Display(Name = "Warrenty Expiry")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? WarrantyExpiry { get; set; }
        [Display(Name = "Next Service")]
        public string NextService { get; set; }
        [Display(Name = "Last Service")]
        public string LastService { get; set; }
        [Display(Name = "Current Allocation")]
        public string CurrentAllocation { get; set; }
        [Display(Name = "Next Service Type")]
        public string NextServiceType { get; set; }
        [Display(Name = "Next Service Mileage")]
        public decimal? NextServiceMileage { get; set; }
        [Display(Name = "Last Service Mileage")]
        public decimal? LastServiceMileage { get; set; }
        [Display(Name = "Last Service Date")]
        public string LastServiceDate { get; set; }
        [Display(Name = "Is Allocated")]
        public bool? IsAllocated { get; set; }
        [Display(Name = "Fuel Usage Category")]
        public string FuelUsageCategory { get; set; }
        [Display(Name = "Cost of Registration")]
        public decimal? CostofRegistration { get; set; }
        [Display(Name = "Cost of Third Party Insurance")]
        public decimal? CostofThirdPartyInsurance { get; set; }
        [Display(Name = "Lease Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? LeasedExpirydate { get; set; }
        [Display(Name = "Vehicle Financial Status")]
        public string FinancialStatus { get; set; }
        [Display(Name = "Vehicle Usage Status")]
        public string UsageStatus { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Comments")]
        public string Comments { get; set; }
        [Display(Name = "Driver or Custodian")]
        public string DriverCustodian { get; set; } //calculate from allocation ??
        [Display(Name = "Total Fuel Consumption Cost To Date")]
        public decimal? TotalFuelConsumptionCostToDate { get; set; } //use linq to calculate using fuel information
        [Display(Name = "Total Service Cost To Date")]
        public decimal? TotalServiceCostToDate { get; set; } //use linq to calculate using service information
        [Display(Name = "Disposal Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string DisposalDate { get; set; } //use linq to calculate using disposal information
        [Display(Name = "Disposal Value")]
        public string DisposalValue { get; set; } //use linq to calculate using disposal information
        [Display(Name = "Disposal Reference")]
        public string DisposalReference { get; set; } //use linq to calculate using disposal information
        [Display(Name = "COD Report")]
        public string CODReport { get; set; } //map to CODReport column in Disposal. Need to update class field to array of bytes (byte[]) and update sql db column type to image

        [Display(Name = "Vehicle Life (Years)")]
        public string VehicleLife { get; set; }
        public int? StatusId { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime? LastUpdatedDate { get; set; }



        #endregion




    }
}