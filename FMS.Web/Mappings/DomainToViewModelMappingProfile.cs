using AutoMapper;
using FMS.Web.ViewModels;
using FMS.Model;
using FMS.Web.Identity;
using System;
using FMS.Service;
using System.Web;
using FMS.Common;

namespace FMS.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {


        public DomainToViewModelMappingProfile()
        {
            //  Map ONLY those specific fields where it is not clear for Automapper to do the mapping
            CreateMap<Vehicle, VehicleDisplayViewModel>()
                .ForMember(dest => dest.Make, map => map.MapFrom(src => src.Make.ParameterName))
                .ForMember(dest => dest.Model, map => map.MapFrom(src => src.Model.Name))
                .ForMember(dest => dest.Status, map => map.MapFrom(src => src.Status.ParameterName))
                .ForMember(dest => dest.VehicleType, map => map.MapFrom(src => src.VehicleType.Type))
                .ForMember(dest => dest.BusinessGroup, map => map.MapFrom(src => src.BusinessGroup.GroupName))
                .ForMember(dest=>dest.VehicleLife, map => map.MapFrom(src => src.AcquisitionDate != null? (DateTime.Today.Year - ((DateTime)src.AcquisitionDate).Year).ToString() : "Acquisition Date is null!" ))
                .ForMember(dest => dest.Center, map => map.MapFrom(src => src.Center.Name))
                .ForMember(dest => dest.Condition, map => map.MapFrom(src => src.Condition.ParameterName))
                .ForMember(dest => dest.Supplier, map => map.MapFrom(src => src.ContactDetail.ContactName))
                .ForMember(dest => dest.FuelType, map => map.MapFrom(src => src.FuelType.ParameterName))
                .ForMember(dest => dest.Transmission, map => map.MapFrom(src => src.Transmission.ParameterName))
                .ForMember(dest => dest.NextServiceType, map => map.MapFrom(src => src.NextServiceType.ParameterName))
                .ForMember(dest => dest.FuelUsageCategory, map => map.MapFrom(src => src.FuelUsageCategory.ParameterName))
                .ForMember(dest => dest.FinancialStatus, map => map.MapFrom(src => src.FinancialStatus.ParameterName))
                .ForMember(dest => dest.UsageStatus, map => map.MapFrom(src => src.UsageStatus.ParameterName))
                .ForMember(dest => dest.AcquisitionType, map => map.MapFrom(src => src.AcquisitionType.ParameterName))
                .ForMember(dest => dest.RegistrationDate, map => map.MapFrom(src => src.RegistrationDate != null ? ((DateTime)(src.RegistrationDate)).ToString("dd/MM/yyyy") : ""))
                .ForMember(dest => dest.RegistrationExpiry, map => map.MapFrom(src => src.RegistrationExpiry != null ? ((DateTime)(src.RegistrationExpiry)).ToString("dd/MM/yyyy") : ""))
                .ForMember(dest => dest.SafetyStickyExpiry, map => map.MapFrom(src => src.SafetyStickyExpiry != null ? ((DateTime)(src.SafetyStickyExpiry)).ToString("dd/MM/yyyy") : ""))
                .ForMember(dest => dest.LastServiceDate, map => map.MapFrom(src => src.LastServiceDate != null ? ((DateTime)(src.LastServiceDate)).ToString("dd/MM/yyyy") : ""))                
                .ForMember(dest => dest.AcquisitionDate, map => map.MapFrom(src => src.AcquisitionDate != null ? ((DateTime)(src.AcquisitionDate)).ToString("dd/MM/yyyy") : ""))
                .ForMember(dest => dest.BOS_Recommendation, map => map.MapFrom(src => src.BOS_Recommendation != null ? (src.BOS_Recommendation == true ? "Yes":"No") : ""));             


                

            CreateMap<Vehicle, VehicleBOSDisplayViewModel>()

            .ForMember(dest => dest.Status, map => map.MapFrom(src => src.Status.ParameterName))
            .ForMember(dest => dest.CurrentMileage, map => map.MapFrom(src => src.CurrentMileage.ToString()))
            .ForMember(dest => dest.VehicleType, map => map.MapFrom(src => src.VehicleType.Type))
            .ForMember(dest => dest.Center, map => map.MapFrom(src => src.Center.Name))           
            .ForMember(dest => dest.Condition, map => map.MapFrom(src => src.Condition.ParameterName))
            .ForMember(dest => dest.Age, map => map.MapFrom(src => src.AcquisitionDate != null ? (DateTime.Today.Year - ((DateTime)(src.AcquisitionDate)).Year):0))
            .ForMember(dest => dest.IsConditionBOS, map => map.MapFrom(src => src.ConditionId == (int)Parameters.VehicleConditionStatus.BeyondRepair))
            .ForMember(dest => dest.IsOperationalStatusBOS, map => map.MapFrom(src => src.ConditionId == (int)Parameters.VehicleOperationalStatus.Accident))
            .ForMember(dest => dest.IsAgeBOS, map => map.MapFrom<IsAgeBOSResolver>())
            .ForMember(dest => dest.IsMileageBOS, map => map.MapFrom<IsMileageBOSResolver>());


            CreateMap<Vehicle, VehicleEditViewModel>()
                .ForMember(dest => dest.RegistrationExpiryDisplay, map => map.MapFrom(src => src.RegistrationExpiry != null ? ((DateTime)(src.RegistrationExpiry)).ToString("dd/MM/yyyy") : ""))
                .ForMember(dest => dest.SafetyStickerExpiryDisplay, map => map.MapFrom(src => src.SafetyStickyExpiry != null ? ((DateTime)(src.SafetyStickyExpiry)).ToString("dd/MM/yyyy") : ""))
                .ForMember(dest => dest.LastServiceDateDisplay, map => map.MapFrom(src => src.LastServiceDate != null ? ((DateTime)(src.LastServiceDate)).ToString("dd/MM/yyyy") : ""))
                .ForMember(dest => dest.CreatedDateDisplay, map => map.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.CreatedByDisplay, map => map.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.VehicleLife, map => map.MapFrom(src => src.AcquisitionDate != null ? (DateTime.Today.Year - ((DateTime)src.AcquisitionDate).Year).ToString() : "Acquisition Date is null!"))
                .ForMember(dest => dest.CurrentMileageDisplay, map => map.MapFrom(src => src.CurrentMileage))
                .ForMember(dest => dest.RegionId, map => map.MapFrom(src => src.Center.RegionaNumberId))
                .ForMember(dest => dest.BusinessUnitId, map => map.MapFrom(src => src.BusinessGroup.BusinessUnitId));

            CreateMap<User, IdentityUser>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.UserId));

            CreateMap<Role, IdentityRole>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.RoleId));

            CreateMap<IdentityRole, RoleViewModel>();


            CreateMap<VehicleAllocation, VehicleAllocationViewModel>()
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.BusinessGroup, map => map.MapFrom(src => src.Vehicle.BusinessGroup.GroupName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.Center, map => map.MapFrom(src => src.Vehicle.Center.Name))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.CurrentMileage, map => map.MapFrom(src => src.Vehicle.CurrentMileage.ToString()))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleColor, map => map.MapFrom(src => src.Vehicle.VehicleColor))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleCondition, map => map.MapFrom(src => src.Vehicle.Condition.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleMake, map => map.MapFrom(src => src.Vehicle.Make.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleModel, map => map.MapFrom(src => src.Vehicle.Model.Name))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleRegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleStatus, map => map.MapFrom(src => src.Vehicle.Status.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleType, map => map.MapFrom(src => src.Vehicle.VehicleType.Type))
                 .ForPath(dest => dest.OperatorDisplayInfoViewModel.DriverDateOfBirth, map => map.MapFrom(src => src.ContactDetail.DateOfBirth))
                 .ForPath(dest => dest.OperatorDisplayInfoViewModel.DriverEmail, map => map.MapFrom(src => src.ContactDetail.Email))
                 .ForPath(dest => dest.OperatorDisplayInfoViewModel.DriverLicenceNumber, map => map.MapFrom(src => src.ContactDetail.LicenceNumber))
                 .ForPath(dest => dest.OperatorDisplayInfoViewModel.DriverMobile, map => map.MapFrom(src => src.ContactDetail.Mobile))
                 .ForPath(dest => dest.OperatorDisplayInfoViewModel.DriverName, map => map.MapFrom(src => src.ContactDetail.ContactName))
                 .ForPath(dest => dest.OperatorDisplayInfoViewModel.StaffNumber, map => map.MapFrom(src =>string.Empty)); //need to include a staff number field in contact detail table


            CreateMap<VehicleTransfer, VehicleTransferViewModel>()
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.BusinessGroup, map => map.MapFrom(src => src.Vehicle.BusinessGroup.GroupName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.Center, map => map.MapFrom(src => src.Vehicle.Center.Name))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.CurrentMileage, map => map.MapFrom(src => src.Vehicle.CurrentMileage.ToString()))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleColor, map => map.MapFrom(src => src.Vehicle.VehicleColor))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleCondition, map => map.MapFrom(src => src.Vehicle.Condition.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleMake, map => map.MapFrom(src => src.Vehicle.Make.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleModel, map => map.MapFrom(src => src.Vehicle.Model.Name))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleRegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleStatus, map => map.MapFrom(src => src.Vehicle.Status.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleType, map => map.MapFrom(src => src.Vehicle.VehicleType.Type));

            CreateMap<Model.Service, VehicleServiceEditViewModel>()
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.BusinessGroup, map => map.MapFrom(src => src.Vehicle.BusinessGroup.GroupName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.Center, map => map.MapFrom(src => src.Vehicle.Center.Name))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.CurrentMileage, map => map.MapFrom(src => src.Vehicle.CurrentMileage.ToString()))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleColor, map => map.MapFrom(src => src.Vehicle.VehicleColor))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleCondition, map => map.MapFrom(src => src.Vehicle.Condition.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleMake, map => map.MapFrom(src => src.Vehicle.Make.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleModel, map => map.MapFrom(src => src.Vehicle.Model.Name))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleRegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleStatus, map => map.MapFrom(src => src.Vehicle.Status.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleType, map => map.MapFrom(src => src.Vehicle.VehicleType.Type))
                .ForMember(dest => dest.CreatedDateDisplay, map => map.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.CreatedByDisplay, map => map.MapFrom(src => src.CreatedBy));

            CreateMap<Model.Service, VehicleServiceDisplayViewModel>()
                .ForMember(dest => dest.BusinessGroup, map => map.MapFrom(src => src.BusinessGroup.GroupName))
                .ForMember(dest => dest.Center, map => map.MapFrom(src => src.Center.Name))
                .ForMember(dest => dest.Cost, map => { map.MapFrom(src => src.Cost==null?"":((decimal)src.Cost).ToString("F")); })
                .ForMember(dest => dest.CurrentMileage, map => map.MapFrom(src => src.CurrentMileage.ToString()))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dest => dest.EndDate, map => { map.MapFrom(src => src.EndDate==null?"":((DateTime)src.EndDate).ToString("dd/MM/yyyy"));})
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Incident, map => map.MapFrom(src => src.Incident.IncidentFileNumber))
                .ForMember(dest => dest.IsAmountPaid, map => map.MapFrom(src => src.IsAmountPaid))
                .ForMember(dest => dest.IsIncidentService, map => map.MapFrom(src => src.IsIncidentService))
                .ForMember(dest => dest.PoReference, map => map.MapFrom(src => src.PoReference))
                .ForMember(dest => dest.Provider, map => map.MapFrom(src => src.ContactDetail1.ContactName))
                .ForMember(dest => dest.ScheduleService, map => map.MapFrom(src => src.ScheduleServiceId))
                .ForMember(dest => dest.ScheduleServiceType, map => map.MapFrom(src => src.SystemParameter1.ParameterName))
                .ForMember(dest => dest.ServiceJobNumber, map => map.MapFrom(src => src.ServiceJobNumber))
                .ForMember(dest => dest.ServiceMechanic, map => map.MapFrom(src => src.ContactDetail.ContactName))
                .ForMember(dest => dest.ServiceType, map => map.MapFrom(src => src.SystemParameter.ParameterName))
                .ForMember(dest => dest.StartDate, map => { map.MapFrom(src => src.StartDate == null ? "" : ((DateTime)src.StartDate).ToString("dd/MM/yyyy")); })
                .ForMember(dest => dest.VehicleRegistration, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.BusinessGroup, map => map.MapFrom(src => src.Vehicle.BusinessGroup.GroupName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.Center, map => map.MapFrom(src => src.Vehicle.Center.Name))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.CurrentMileage, map => map.MapFrom(src => src.Vehicle.CurrentMileage.ToString()))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleColor, map => map.MapFrom(src => src.Vehicle.VehicleColor))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleCondition, map => map.MapFrom(src => src.Vehicle.Condition.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleMake, map => map.MapFrom(src => src.Vehicle.Make.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleModel, map => map.MapFrom(src => src.Vehicle.Model.Name))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleRegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleStatus, map => map.MapFrom(src => src.Vehicle.Status.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleType, map => map.MapFrom(src => src.Vehicle.VehicleType.Type));



            CreateMap<ScheduleService, VehicleServiceScheduleEditViewModel>()
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.BusinessGroup, map => map.MapFrom(src => src.Vehicle.BusinessGroup.GroupName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.Center, map => map.MapFrom(src => src.Vehicle.Center.Name))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.CurrentMileage, map => map.MapFrom(src => src.Vehicle.CurrentMileage.ToString()))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleColor, map => map.MapFrom(src => src.Vehicle.VehicleColor))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleCondition, map => map.MapFrom(src => src.Vehicle.Condition.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleMake, map => map.MapFrom(src => src.Vehicle.Make.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleModel, map => map.MapFrom(src => src.Vehicle.Model.Name))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleRegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleStatus, map => map.MapFrom(src => src.Vehicle.Status.ParameterName))
                 .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleType, map => map.MapFrom(src => src.Vehicle.VehicleType.Type));



            CreateMap<ScheduleService, VehicleServiceScheduleDisplayViewModel>()
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.BusinessGroup, map => map.MapFrom(src => src.Vehicle.BusinessGroup.GroupName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.Center, map => map.MapFrom(src => src.Vehicle.Center.Name))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.CurrentMileage, map => map.MapFrom(src => src.Vehicle.CurrentMileage.ToString()))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleColor, map => map.MapFrom(src => src.Vehicle.VehicleColor))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleCondition, map => map.MapFrom(src => src.Vehicle.Condition.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleMake, map => map.MapFrom(src => src.Vehicle.Make.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleModel, map => map.MapFrom(src => src.Vehicle.Model.Name))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleRegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleStatus, map => map.MapFrom(src => src.Vehicle.Status.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleType, map => map.MapFrom(src => src.Vehicle.VehicleType.Type))
                .ForMember(dest => dest.CurrentMileage, map => map.MapFrom(src => src.CurrentMileage.ToString()))
                .ForMember(dest => dest.HasServiceBeenDone, map => map.MapFrom(src => src.HasServiceBeenDone))
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.ScheduleServiceType, map => map.MapFrom(src => src.SystemParameter.ParameterName))                
                .ForMember(dest => dest.ServiceAlertDate, map => { map.MapFrom(src => src.ServiceAlertDate == null ? "" : ((DateTime)src.ServiceAlertDate).ToString("dd/MM/yyyy")); })                
                .ForMember(dest => dest.ServiceAlertMileage, map => map.MapFrom(src => src.ServiceAlertMileage.ToString()))
                .ForMember(dest => dest.VehicleRegistration, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                .ForMember(dest => dest.ServiceExists,map=>map.MapFrom<ScheduleServiceExistsResolver>());            


            CreateMap<VehicleRefuel, VehicleRefuelDisplayViewModel>()
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.BusinessGroup, map => map.MapFrom(src => src.Vehicle.BusinessGroup.GroupName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.Center, map => map.MapFrom(src => src.Vehicle.Center.Name))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.CurrentMileage, map => map.MapFrom(src => src.Vehicle.CurrentMileage.ToString()))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleColor, map => map.MapFrom(src => src.Vehicle.VehicleColor))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleCondition, map => map.MapFrom(src => src.Vehicle.Condition.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleMake, map => map.MapFrom(src => src.Vehicle.Make.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleModel, map => map.MapFrom(src => src.Vehicle.Model.Name))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleRegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleStatus, map => map.MapFrom(src => src.Vehicle.Status.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleType, map => map.MapFrom(src => src.Vehicle.VehicleType.Type))
                .ForMember(dest => dest.BowserNumber, map => map.MapFrom(src => src.DepotTank.BowserNumber))
                .ForMember(dest => dest.Center, map => map.MapFrom(src => src.Center.Name))
                .ForMember(dest => dest.Date, map => map.MapFrom(src => ((DateTime)src.Date).ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.DocketNumber, map => map.MapFrom(src => src.DocketNumber))
                .ForMember(dest => dest.FuelDistributor, map => { map.MapFrom(src => src.ContactDetail1.ContactName); })
                .ForMember(dest => dest.FuelType, map => map.MapFrom(src => src.SystemParameter1.ParameterName.ToString()))
                .ForMember(dest => dest.FuelUsageCategory, map => map.MapFrom(src => src.SystemParameter.ParameterName))
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsBowserFuel, map => map.MapFrom(src => src.IsBowserFuel))
                .ForMember(dest => dest.Litres, map => map.MapFrom(src => src.Liters))
                .ForMember(dest => dest.Mileage, map => map.MapFrom(src => src.Mileage))
                .ForMember(dest => dest.Operator, map => map.MapFrom(src => src.ContactDetail.ContactName.ToString()))
                .ForMember(dest => dest.TotalCost, map => map.MapFrom(src => src.TotalCost.ToString()))
                .ForMember(dest => dest.UnitCost, map => map.MapFrom(src => src.UnitCost.ToString()))
                .ForMember(dest => dest.VehicleRegistrationNumber, map => map.MapFrom(src => src.RegistrationNumber));


            CreateMap<VehicleRefuel, VehicleRefuelEditViewModel>()
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.BusinessGroup, map => map.MapFrom(src => src.Vehicle.BusinessGroup.GroupName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.Center, map => map.MapFrom(src => src.Vehicle.Center.Name))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.CurrentMileage, map => map.MapFrom(src => src.Vehicle.CurrentMileage.ToString()))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleColor, map => map.MapFrom(src => src.Vehicle.VehicleColor))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleCondition, map => map.MapFrom(src => src.Vehicle.Condition.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleMake, map => map.MapFrom(src => src.Vehicle.Make.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleModel, map => map.MapFrom(src => src.Vehicle.Model.Name))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleRegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleStatus, map => map.MapFrom(src => src.Vehicle.Status.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleType, map => map.MapFrom(src => src.Vehicle.VehicleType.Type))
                .ForMember(dest => dest.FuelUsageCategory, map => map.Ignore())
                .ForMember(dest => dest.FuelType, map => map.Ignore())
                .ForMember(dest => dest.VehicleByCenterSecurity, map => map.Ignore())
                .ForMember(dest => dest.Driver, map => map.Ignore())
                .ForMember(dest => dest.CreatedDateDisplay, map => map.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.CreatedByDisplay, map => map.MapFrom(src => src.CreatedBy));


            CreateMap<DepotDailyMeasurement, DepotDailyMeasurementEditViewModel>()
                .ForMember(dest => dest.BowserNumber, map => map.MapFrom(src => src.DeportTankId))                
                .ForMember(dest => dest.CenterDisplay, map => map.MapFrom(src => src.Center.Name))              
                .ForMember(dest => dest.RegionDisplay, map => map.MapFrom(src => src.Center.Regional.Name))
                .ForMember(dest => dest.RegionId, map => map.MapFrom(src => src.Center.Regional.RegionNumber))
                .ForMember(dest => dest.EndVolumeDisplay, map => map.MapFrom(src => src.EndVolume.ToString()))
                .ForMember(dest => dest.StartVolumeDisplay, map => map.MapFrom(src => src.StartVolume.ToString()));



            CreateMap<DepotRefuel, DepotRefuelEditViewModel>()
                .ForMember(dest => dest.CurrentVolumeDisplay, map => map.MapFrom(src => src.CurrentVolume.ToString()))
                .ForMember(dest => dest.PreviousVolumeDisplay, map => map.MapFrom(src => src.PreviousVolume.ToString()))
                .ForMember(dest => dest.PurchaseVolumeDisplay, map => map.MapFrom(src => src.PurchaseVolume.ToString()))
                .ForMember(dest => dest.CenterDisplay, map => map.MapFrom(src => src.Center.Name))
                .ForMember(dest => dest.DeportTankId, map => map.MapFrom(src => src.BowserNumber))
                .ForMember(dest => dest.RegionDisplay, map => map.MapFrom(src => src.Center.Regional.Name))
                .ForMember(dest => dest.RegionId, map => map.MapFrom(src => src.Center.Regional.RegionNumber))
                .ForMember(dest => dest.MaximumCapacity, map => map.MapFrom<DepotTankMaximumCapacityResolver>());




            CreateMap<DepotTank, DepotTankEditViewModel>()
                .ForMember(dest => dest.RegionId, map => map.MapFrom(src => src.Center.Regional.RegionNumber))
                .ForMember(dest => dest.CurrentVolumeDisplay, map => map.MapFrom(src => src.CurrentVolume.ToString()))
                .ForMember(dest => dest.CenterDisplay, map => map.MapFrom(src => src.Center.Name))
                .ForMember(dest => dest.RegionDisplay, map => map.MapFrom(src => src.Center.Regional.Name))
                .ForMember(dest => dest.FuelTypeDisplay, map => map.MapFrom(src => src.SystemParameter.ParameterName))
                .ForMember(dest => dest.MaximumCapacityDisplay, map => map.MapFrom(src=>src.MaximumCapacity.ToString()));



            CreateMap<Incident, IncidentDisplayViewModel>()
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.BusinessGroup, map => map.MapFrom(src => src.Vehicle.BusinessGroup.GroupName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.Center, map => map.MapFrom(src => src.Vehicle.Center.Name))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.CurrentMileage, map => map.MapFrom(src => src.Vehicle.CurrentMileage.ToString()))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleColor, map => map.MapFrom(src => src.Vehicle.VehicleColor))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleCondition, map => map.MapFrom(src => src.Vehicle.Condition.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleMake, map => map.MapFrom(src => src.Vehicle.Make.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleModel, map => map.MapFrom(src => src.Vehicle.Model.Name))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleRegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleStatus, map => map.MapFrom(src => src.Vehicle.Status.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleType, map => map.MapFrom(src => src.Vehicle.VehicleType.Type))
                .ForMember(dest => dest.DateofAccident, map => { map.MapFrom(src => src.DateofAccident == null ? "" : ((DateTime)src.DateofAccident).ToString("dd/MM/yyyy")); })
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dest => dest.Driver, map => map.MapFrom(src =>src.ContactDetail.ContactName))
                .ForMember(dest => dest.HasReport, map => map.MapFrom(src => src.HasReport==true?"Yes":"No"))
                .ForMember(dest => dest.HasServiceBeenDone, map => map.MapFrom(src => src.ServiceDone == true ? "Yes" : "No"))
                .ForMember(dest => dest.IncidentDate, map => { map.MapFrom(src => src.DateAndTime == null ? "" : ((DateTime)src.DateAndTime).ToString("dd/MM/yyyy")); })
                .ForMember(dest => dest.IncidentFileName, map => map.MapFrom(src => src.IncidentFileName))
                .ForMember(dest => dest.IncidentFileNumber, map => map.MapFrom(src => src.IncidentFileNumber))
                .ForMember(dest => dest.IncidentRequiresService, map => map.MapFrom(src => src.RequiredService == true ? "Yes" : "No"))
                .ForMember(dest => dest.IncidentStatus, map => map.MapFrom(src => src.SystemParameter.ParameterName))
                .ForMember(dest => dest.IncidentType, map => map.MapFrom(src => src.SystemParameter1.ParameterName))
                .ForMember(dest => dest.Location, map => map.MapFrom(src => src.Location))
                .ForMember(dest => dest.RegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber));

            CreateMap<Incident, IncidentEditViewModel>()
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.BusinessGroup, map => map.MapFrom(src => src.Vehicle.BusinessGroup.GroupName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.Center, map => map.MapFrom(src => src.Vehicle.Center.Name))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.CurrentMileage, map => map.MapFrom(src => src.Vehicle.CurrentMileage.ToString()))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleColor, map => map.MapFrom(src => src.Vehicle.VehicleColor))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleCondition, map => map.MapFrom(src => src.Vehicle.Condition.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleMake, map => map.MapFrom(src => src.Vehicle.Make.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleModel, map => map.MapFrom(src => src.Vehicle.Model.Name))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleRegistrationNumber, map => map.MapFrom(src => src.Vehicle.RegistrationNumber))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleStatus, map => map.MapFrom(src => src.Vehicle.Status.ParameterName))
                .ForPath(dest => dest.VehicleDisplayInfoViewModel.VehicleType, map => map.MapFrom(src => src.Vehicle.VehicleType.Type))
                .ForMember(dest => dest.CreatedDateDisplay, map => map.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.CreatedByDisplay, map => map.MapFrom(src => src.CreatedBy));

            CreateMap<Notification, NotificationEditViewModel>()
                .ForMember(dest => dest.EmailTemplateDisplay, map => map.MapFrom(src => src.EmailTemplate.TemplateName))
                .ForMember(dest => dest.NotificationTypeDisplay, map => map.MapFrom(src => src.SystemParameter.ParameterName))
                .ForMember(dest => dest.WhenAppearBeforeDisplay, map => map.MapFrom(src => src.SystemParameter1.ParameterName))
                .ForMember(dest => dest.SeverityDisplay, map => map.MapFrom(src => src.SystemParameter2.ParameterName));

            CreateMap<Alert, AlertEditViewModel>()
                .ForMember(dest => dest.AlertTypeDisplay, map => map.MapFrom(src => src.MstSystemParameter.ParameterName))
                .ForMember(dest => dest.EmailDisplay, map => map.MapFrom(src => src.MstContactDetail.Email))
                .ForMember(dest => dest.ContactDisplay, map => map.MapFrom(src => src.MstContactDetail.ContactName));


            CreateMap<Compliance, ComplianceEditViewModel>()
                .ForMember(dest => dest.VehicleRegoDisplay, map => map.MapFrom(src => src.Vehicle == null ? "" : src.Vehicle.RegistrationNumber));

            CreateMap<ContactDetail, ContactDetailDisplayViewModel>()
                .ForMember(dest => dest.LicenceClass, map => map.MapFrom(src => src.LicanceClass))
                .ForMember(dest => dest.DateOfBirth, map => { map.MapFrom(src => src.DateOfBirth == null ? "" : ((DateTime)src.DateOfBirth).ToString("dd/MM/yyyy")); })
                .ForMember(dest => dest.LicenceExpiryDate, map => { map.MapFrom(src => src.LicenceExpiryDate == null ? "" : ((DateTime)src.LicenceExpiryDate).ToString("dd/MM/yyyy")); })
                .ForMember(dest => dest.PPLPermitIssueDate, map => { map.MapFrom(src => src.PPLPermitIssueDate == null ? "" : ((DateTime)src.PPLPermitIssueDate).ToString("dd/MM/yyyy")); })               
                .ForMember(dest => dest.IsDriver, map => map.MapFrom(src => src.IsDriver == true ? "Yes" : "No"))
                .ForPath(dest => dest.SupplierType, map => map.MapFrom(src => src.SystemParameter1.ParameterName))
                .ForPath(dest => dest.Gender, map => map.MapFrom(src => src.SystemParameter2.ParameterName))
                .ForPath(dest => dest.Center, map => map.MapFrom(src => src.Center.Name));

            CreateMap<ContactDetail, ContactDetailEditViewModel>()
                .ForMember(dest => dest.LicenceClass, map => map.MapFrom(src => src.LicanceClass));


            CreateMap<BusinessUnit, BusinessUnitEditViewModel>()
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactName, map => map.MapFrom(src => src.ContactDetail.ContactName))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactPerson, map => map.MapFrom(src => src.ContactDetail.ContactPerson))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.StreetAddress, map => map.MapFrom(src => src.ContactDetail.StreetAddress))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Facsimile, map => map.MapFrom(src => src.ContactDetail.Facsimile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Telephone, map => map.MapFrom(src => src.ContactDetail.Telephone))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Mobile, map => map.MapFrom(src => src.ContactDetail.Mobile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Email, map => map.MapFrom(src => src.ContactDetail.Email))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Website, map => map.MapFrom(src => src.ContactDetail.Website))                
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Comments, map => map.MapFrom(src => src.ContactDetail.Comments));

            CreateMap<BusinessUnit, BusinessUnitDisplayViewModel>()
                 .ForMember(dest => dest.Manager, map => map.MapFrom(src => src.ContactDetail.ContactName))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactName, map => map.MapFrom(src => src.ContactDetail.ContactName))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactPerson, map => map.MapFrom(src => src.ContactDetail.ContactPerson))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.StreetAddress, map => map.MapFrom(src => src.ContactDetail.StreetAddress))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Facsimile, map => map.MapFrom(src => src.ContactDetail.Facsimile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Telephone, map => map.MapFrom(src => src.ContactDetail.Telephone))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Mobile, map => map.MapFrom(src => src.ContactDetail.Mobile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Email, map => map.MapFrom(src => src.ContactDetail.Email))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Website, map => map.MapFrom(src => src.ContactDetail.Website))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Comments, map => map.MapFrom(src => src.ContactDetail.Comments));


            CreateMap<BusinessGroup, BusinessGroupEditViewModel>()
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactName, map => map.MapFrom(src => src.ContactDetail.ContactName))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactPerson, map => map.MapFrom(src => src.ContactDetail.ContactPerson))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.StreetAddress, map => map.MapFrom(src => src.ContactDetail.StreetAddress))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Facsimile, map => map.MapFrom(src => src.ContactDetail.Facsimile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Telephone, map => map.MapFrom(src => src.ContactDetail.Telephone))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Mobile, map => map.MapFrom(src => src.ContactDetail.Mobile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Email, map => map.MapFrom(src => src.ContactDetail.Email))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Website, map => map.MapFrom(src => src.ContactDetail.Website))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Comments, map => map.MapFrom(src => src.ContactDetail.Comments));

            CreateMap<BusinessGroup, BusinessGroupDisplayViewModel>()
                 .ForMember(dest => dest.BusinessUnit, map => map.MapFrom(src => src.BusinessUnit != null? src.BusinessUnit.Name:"" ))
                 .ForMember(dest => dest.Manager, map => map.MapFrom(src => src.ContactDetail != null ? src.ContactDetail.ContactName:""))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactName, map => map.MapFrom(src => src.ContactDetail.ContactName))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactPerson, map => map.MapFrom(src => src.ContactDetail.ContactPerson))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.StreetAddress, map => map.MapFrom(src => src.ContactDetail.StreetAddress))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Facsimile, map => map.MapFrom(src => src.ContactDetail.Facsimile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Telephone, map => map.MapFrom(src => src.ContactDetail.Telephone))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Mobile, map => map.MapFrom(src => src.ContactDetail.Mobile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Email, map => map.MapFrom(src => src.ContactDetail.Email))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Website, map => map.MapFrom(src => src.ContactDetail.Website))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Comments, map => map.MapFrom(src => src.ContactDetail.Comments));

            CreateMap<Regional, RegionEditViewModel>()
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactName, map => map.MapFrom(src => src.ContactDetail.ContactName))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactPerson, map => map.MapFrom(src => src.ContactDetail.ContactPerson))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.StreetAddress, map => map.MapFrom(src => src.ContactDetail.StreetAddress))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Facsimile, map => map.MapFrom(src => src.ContactDetail.Facsimile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Telephone, map => map.MapFrom(src => src.ContactDetail.Telephone))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Mobile, map => map.MapFrom(src => src.ContactDetail.Mobile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Email, map => map.MapFrom(src => src.ContactDetail.Email))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Website, map => map.MapFrom(src => src.ContactDetail.Website))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Comments, map => map.MapFrom(src => src.ContactDetail.Comments));

            CreateMap<Regional, RegionDisplayViewModel>()
                 .ForMember(dest => dest.Manager, map => map.MapFrom(src => src.ContactDetail.ContactName))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactName, map => map.MapFrom(src => src.ContactDetail.ContactName))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.ContactPerson, map => map.MapFrom(src => src.ContactDetail.ContactPerson))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.StreetAddress, map => map.MapFrom(src => src.ContactDetail.StreetAddress))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Facsimile, map => map.MapFrom(src => src.ContactDetail.Facsimile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Telephone, map => map.MapFrom(src => src.ContactDetail.Telephone))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Mobile, map => map.MapFrom(src => src.ContactDetail.Mobile))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Email, map => map.MapFrom(src => src.ContactDetail.Email))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Website, map => map.MapFrom(src => src.ContactDetail.Website))
                 .ForPath(dest => dest.contactDetailDisplayViewModel.Comments, map => map.MapFrom(src => src.ContactDetail.Comments));

            CreateMap<Center, CenterEditViewModel>()
             .ForMember(dest => dest.RegionId, map => map.MapFrom(src => src.RegionaNumberId))
             .ForPath(dest => dest.contactDetailDisplayViewModel.ContactName, map => map.MapFrom(src => src.ContactDetail.ContactName))
             .ForPath(dest => dest.contactDetailDisplayViewModel.ContactPerson, map => map.MapFrom(src => src.ContactDetail.ContactPerson))
             .ForPath(dest => dest.contactDetailDisplayViewModel.StreetAddress, map => map.MapFrom(src => src.ContactDetail.StreetAddress))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Facsimile, map => map.MapFrom(src => src.ContactDetail.Facsimile))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Telephone, map => map.MapFrom(src => src.ContactDetail.Telephone))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Mobile, map => map.MapFrom(src => src.ContactDetail.Mobile))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Email, map => map.MapFrom(src => src.ContactDetail.Email))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Website, map => map.MapFrom(src => src.ContactDetail.Website))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Comments, map => map.MapFrom(src => src.ContactDetail.Comments));


            CreateMap<Center, CenterDisplayViewModel>()
             .ForMember(dest => dest.Manager, map => map.MapFrom(src => src.ContactDetail.ContactName))
             .ForMember(dest => dest.Region, map => map.MapFrom(src => src.Regional.Name))  
             .ForPath(dest => dest.contactDetailDisplayViewModel.ContactName, map => map.MapFrom(src => src.ContactDetail.ContactName))
             .ForPath(dest => dest.contactDetailDisplayViewModel.ContactPerson, map => map.MapFrom(src => src.ContactDetail.ContactPerson))
             .ForPath(dest => dest.contactDetailDisplayViewModel.StreetAddress, map => map.MapFrom(src => src.ContactDetail.StreetAddress))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Facsimile, map => map.MapFrom(src => src.ContactDetail.Facsimile))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Telephone, map => map.MapFrom(src => src.ContactDetail.Telephone))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Mobile, map => map.MapFrom(src => src.ContactDetail.Mobile))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Email, map => map.MapFrom(src => src.ContactDetail.Email))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Website, map => map.MapFrom(src => src.ContactDetail.Website))
             .ForPath(dest => dest.contactDetailDisplayViewModel.Comments, map => map.MapFrom(src => src.ContactDetail.Comments));

            CreateMap<ClientInformation, ClientInformationEditViewModel>();
                

            CreateMap<SystemParameter, SystemParameterViewModel>()
                .ForMember(dest => dest.ParameterCode, map => map.MapFrom(src => src.SystemParameterCode.ParameterCode))
                .ForMember(dest => dest.HardCoded, map => map.MapFrom(src => src.IsHardCoded == true? "Yes":"No" ));

            CreateMap<FMS.Model.Model, VehicleModelViewModel>()
                 .ForMember(dest => dest.Make, map => map.MapFrom(src => src.SystemParameter.ParameterName));

            CreateMap<VehicleType, VehicleTypeViewModel>();

            CreateMap<SqlAudit, SqlAuditViewModel>()
                .ForMember(dest => dest.DateAndTime, map => map.MapFrom(src => src.DateAndTime==null ? "" : ((DateTime)src.DateAndTime).ToString("dd/MM/yyyy hh:mm: tt")));

          
        }

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

    }


}