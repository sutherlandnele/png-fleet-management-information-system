namespace FMS.Model
{
    using System;
    using System.Collections.Generic;

    public class Vehicle
    {
        #region Fields
        public int Id { get; set; }

        public string AssetNumber { get; set; }

        public DateTime? AcquisitionDate { get; set; }

        public decimal? AcquisitionCost { get; set; }

        public int? BusinessGroupId { get; set; }

        public int? AcquisitionTypeId { get; set; }
        public int? Supplier { get; set; }  
        public string PurchasingReferance { get; set; }
        public int? VehicleTypeId { get; set; }
        public string VehicleColor { get; set; }
        public int? MadeId { get; set; }
        public int? ModelId { get; set; }
        public int? FuelTypeId { get; set; }
        public int? TransmissionId { get; set; }   
        public string RegistrationNumber { get; set; }
        public DateTime? RegistrationDate { get; set; } 
        public string RegistryClass { get; set; } 
        public string EngineNumber { get; set; }   
        public string ChassisNumber { get; set; }
        public decimal? StartingMileage { get; set; }
        public int? CurrentMileage { get; set; }
        public decimal? InsuranceAmmount { get; set; } 
        public string Description { get; set; }
        public string Comments { get; set; }

        public int? InsuranceTypeId { get; set; } 

        public DateTime? RegistrationExpiry { get; set; }

        public DateTime? SafetyStickyExpiry { get; set; }

        public DateTime? ThirdPartyInsuranceExpiry { get; set; }

        public DateTime? WarrantyExpiry { get; set; }

        public int? StatusId { get; set; }

        public int? ConditionId { get; set; }

        public int? NextServiceId { get; set; }

        public int? LastServiceId { get; set; }

     
        public int? NextServiceTypeId { get; set; }

        public decimal? NextServiceMileage { get; set; }

        public decimal? LastServiceMileage { get; set; }

        public DateTime? LastServiceDate { get; set; }

        public int? CenterId { get; set; }

        public bool? BOS_Recommendation { get; set; }

        public bool? IsAllocated { get; set; }

        public int? FuelUsageCategoryId { get; set; }

        public decimal? CostofRegistration { get; set; }

        public decimal? CostofThirdPartyInsurance { get; set; }

        public DateTime? LeasedExpirydate { get; set; }

        public int? FinancialStatusId { get; set; }

        public int? UsageStatusId { get; set; }

        public int? BOSNumber { get; set; }

        public string BosReport { get; set; }


        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }


        #endregion

        #region Dependent Related Objects
        public virtual BusinessGroup BusinessGroup { get; set; }

        public virtual Center Center { get; set; }

         public virtual ContactDetail ContactDetail { get; set; } 

        public virtual Model Model { get; set; }

        public virtual SystemParameter AcquisitionType { get; set; }
        public virtual SystemParameter InsuranceType { get; set; }

        public virtual SystemParameter FinancialStatus { get; set; }

        public virtual SystemParameter FuelUsageCategory { get; set; }

        public virtual SystemParameter Make { get; set; }

        public virtual SystemParameter FuelType { get; set; }

        public virtual SystemParameter Transmission { get; set; }

        public virtual SystemParameter Status { get; set; }

        public virtual SystemParameter Condition { get; set; }

        public virtual SystemParameter NextService { get; set; }

        public virtual SystemParameter LastService { get; set; }

        public virtual SystemParameter NextServiceType { get; set; }

        public virtual SystemParameter UsageStatus { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        #endregion

        #region Reference Related Objects
        public virtual List<Compliance> Compliances { get; set; }
        public virtual List<ScheduleService> ScheduleServices { get; set; }

        public virtual List<Service> Services { get; set; }

        public virtual List<FuelVoucher> FuelVouchers { get; set; }


        public virtual List<Incident> Incidents { get; set; }

      
        public virtual List<VehicleAllocation> VehicleAllocations { get; set; }


        public virtual List<VehicleDisposal> VehicleDisposals { get; set; }


        public virtual List<VehicleRefuel> VehicleRefuels { get; set; }


        public virtual List<VehicleTransfer> VehicleTransfers { get; set; }
        #endregion
    }
}
