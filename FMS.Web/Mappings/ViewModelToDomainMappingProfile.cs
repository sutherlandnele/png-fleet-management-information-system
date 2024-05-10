using AutoMapper;
using FMS.Web.ViewModels;
using FMS.Model;
using FMS.Web.Identity;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace FMS.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VehicleEditViewModel, Vehicle>();

            CreateMap<IdentityUser, User>()
                .ForMember(dest => dest.UserId, map => map.MapFrom(src => src.Id));

            CreateMap<IdentityRole, Role>()
                .ForMember(dest => dest.RoleId, map => map.MapFrom(src => src.Id));

            CreateMap<RoleViewModel, IdentityRole>();

            CreateMap<VehicleDisposalEditViewModel, VehicleDisposal>()
                .ForMember(dest=>dest.Value, map=>map.MapFrom(src=>src.Value.ToString()));

            CreateMap<VehicleAllocationViewModel, VehicleAllocation>();

            CreateMap<VehicleTransferViewModel, VehicleTransfer>();

            CreateMap<VehicleServiceEditViewModel, FMS.Model.Service>();             

            CreateMap<VehicleServiceScheduleEditViewModel, ScheduleService>();

            CreateMap<VehicleServiceScheduleEditViewModel, ScheduleService>();


            CreateMap<VehicleRefuelEditViewModel, VehicleRefuel>();

            CreateMap<DepotDailyMeasurementEditViewModel,DepotDailyMeasurement>();

            CreateMap<DepotRefuelEditViewModel, DepotRefuel>()
                .ForMember(dest => dest.BowserNumber, map => map.MapFrom(src => src.DeportTankId));

            CreateMap<DepotTankEditViewModel, DepotTank>();

            CreateMap<IncidentEditViewModel, Incident>();

            CreateMap<NotificationEditViewModel, Notification>();

            CreateMap<AlertEditViewModel, Alert>();

            CreateMap<ComplianceEditViewModel,Compliance>();

            CreateMap<ContactDetailEditViewModel, ContactDetail>()
                 .ForMember(dest => dest.LicanceClass, map => map.MapFrom(src => src.LicenceClass));

            CreateMap<BusinessUnitEditViewModel, BusinessUnit>();

            CreateMap<BusinessGroupEditViewModel, BusinessGroup>();

            CreateMap<RegionEditViewModel, Regional>();

            CreateMap<CenterEditViewModel, Center>()
                .ForMember(dest => dest.RegionaNumberId, map => map.MapFrom(src => src.RegionId));

            CreateMap<ClientInformationEditViewModel, ClientInformation>();

            CreateMap<SystemParameterViewModel, SystemParameter>();

            CreateMap<VehicleModelViewModel,FMS.Model.Model>();

            CreateMap<VehicleTypeViewModel,VehicleType>();

            CreateMap<AppIssueEditViewModel, AppIssue>();


        }
            

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

    }
}