
using AutoMapper;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using FMS.Service;
using FMS.Model;
using FMS.Web.ViewModels;
using System.Linq;
using System;
using FMS.Common;

namespace FMS.Web.Mappings
{
    public class ScheduleServiceExistsResolver : IValueResolver<ScheduleService,VehicleServiceScheduleDisplayViewModel,bool>
    {
        private readonly IVehicleServiceService _vehicleServiceService;

        public bool Resolve(ScheduleService source, VehicleServiceScheduleDisplayViewModel destination, bool destMember, ResolutionContext context)
        {
            return _vehicleServiceService.GetAll().Any(x => x.ScheduleServiceId == source.Id);
        }

        public ScheduleServiceExistsResolver(IVehicleServiceService vehicleServiceService)
        {
            _vehicleServiceService = vehicleServiceService;           
        }
    }

    public class IsAgeBOSResolver : IValueResolver<Vehicle, VehicleBOSDisplayViewModel, bool>
    {
        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly IVehicleTypeService _vehicleTypeService;

        public bool Resolve(Vehicle source, VehicleBOSDisplayViewModel destination, bool destMember, ResolutionContext context)
        {
            var result = from c in _vehicleManagementService.GetAll()
                         join d in _vehicleTypeService.GetAll()
                     on c.VehicleTypeId equals d.Id
                         where (
                            ((c.AcquisitionDate != null) && ((DateTime.Today.Year - ((DateTime)(c.AcquisitionDate)).Year) > (int)d.LifeSpan)))
                     select c;

            return result.Any(x => x.Id == source.Id);
        }

        public IsAgeBOSResolver(IVehicleManagementService vehicleManagementService, IVehicleTypeService vehicleTypeService)
        {
            _vehicleManagementService = vehicleManagementService;
            _vehicleTypeService = vehicleTypeService;

        }
    }

    public class IsMileageBOSResolver : IValueResolver<Vehicle, VehicleBOSDisplayViewModel, bool>
    {
        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly IVehicleTypeService _vehicleTypeService;

        public bool Resolve(Vehicle source, VehicleBOSDisplayViewModel destination, bool destMember, ResolutionContext context)
        {
            var result = from c in _vehicleManagementService.GetAll()
                         join d in _vehicleTypeService.GetAll()
                     on c.VehicleTypeId equals d.Id
                         where (((c.CurrentMileage != null) && (int)c.CurrentMileage > (int)d.MileageSpan))
                         select c;

            return result.Any(x => x.Id == source.Id);
        }

        public IsMileageBOSResolver(IVehicleManagementService vehicleManagementService, IVehicleTypeService vehicleTypeService)
        {
            _vehicleManagementService = vehicleManagementService;
            _vehicleTypeService = vehicleTypeService;

        }
    }



    public class DepotTankMaximumCapacityResolver : IValueResolver<DepotRefuel, DepotRefuelEditViewModel, Decimal?>
    {
        private readonly IDepotRefuelService _depotRefuelService;

        public Decimal? Resolve(DepotRefuel source, DepotRefuelEditViewModel destination, Decimal? destMember, ResolutionContext context)
        {
            return _depotRefuelService.GetPreviousVolume(source.BowserNumber).MaximumCapacity;
        }

        public DepotTankMaximumCapacityResolver(IDepotRefuelService depotRefuelService)
        {
            _depotRefuelService = depotRefuelService;
        }
    }

}