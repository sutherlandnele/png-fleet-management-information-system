using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FMS.Service;
using FMS.Web.ViewModels;
using FMS.Model;
using Kendo.Mvc.UI;
using AutoMapper;
using Kendo.Mvc.Extensions;
using System.Web;
using System.IO;
using FMS.Web.CustomActionFilters;
using FMS.Common;
using FMS.Web.Identity;
using Microsoft.AspNet.Identity;

namespace FMS.Web.Controllers
{
    using VehicleService = Model.Service;


    [Authorize]
    [NoDirectAccess]
    public class VehicleServiceManagementController : BaseController
    {
        #region 1. Private Members

        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IBusinessGroupService _businessGroupService;
        private readonly ICenterService _centerService;       
        private readonly ISystemParameterService _systemParameterService;
        private readonly IContactDetailService _contactDetailService;
        private readonly IVehicleServiceService _vehicleServiceService;
        private readonly IVehicleServiceScheduleService _vehicleServiceScheduleService;
        private readonly IIncidentService _incidentService;
        #endregion

        #region 2. Constructors
        public VehicleServiceManagementController(IVehicleManagementService vehicleManagementService
            , IBusinessUnitService businessUnitService
            , IBusinessGroupService businessGroupService
            , ICenterService centerService           
            , IContactDetailService contactDetailService
            , IVehicleServiceService vehicleServiceService
            , IVehicleServiceScheduleService vehicleServiceScheduleService
            , IIncidentService incidentService
            , IAuditingService auditingService
            , UserManager<IdentityUser, Guid> userManager
            , IModelService modelService
            , IDepotTankService depotTankService
            , IAppRoleInterfaceAccessService appRoleInterfaceAccessService
            , IAppRoleMenuAccessService appRoleMenuAccessService
            , IAppRoleActionAccessService appRoleActionAccessService
            , IAppIssueService appIssueService
            , ISystemParameterService systemParameterService
            , ISystemParameterCodeService systemParameterCodeService

        ) : base(auditingService, userManager, contactDetailService, vehicleManagementService, vehicleServiceService
           , businessUnitService
           , businessGroupService
           , centerService
           , modelService
           , depotTankService
           , appRoleInterfaceAccessService
           , appRoleMenuAccessService
           , appRoleActionAccessService
            , systemParameterCodeService
            , systemParameterService
            , appIssueService
           )
        {
            _vehicleManagementService = vehicleManagementService;
            _businessUnitService = businessUnitService;
            _businessGroupService = businessGroupService;
            _centerService = centerService;
            _systemParameterService = systemParameterService;
            _contactDetailService = contactDetailService;
            _vehicleServiceService = vehicleServiceService;
            _vehicleServiceScheduleService = vehicleServiceScheduleService;
            _incidentService = incidentService;
            

        }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions

        [HttpGet]
        public ActionResult VehicleServices(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;

            ViewBag.Centers = _centerService.GetAllCenterWithPermission(CurrentUser).Select(t => new { Value = t.CenterNumber, Text = t.Name });

            return View();
        }

        [HttpGet]
        public ActionResult VehicleServiceSchedules(string message, bool isError)
        {

            ViewBag.Centers = _centerService.GetAllCenterWithPermission(CurrentUser).Select(t => new { Value = t.CenterNumber, Text = t.Name });
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;

            return View();
        }

        [HttpGet]
        public ActionResult ViewVehicleServiceDetails(int id)
        {
            var v = _vehicleServiceService.GetServiceById(id);

            var vm = Mapper.Map<VehicleService, VehicleServiceDisplayViewModel>(v);


            return View("VehicleServiceDetailsView", vm);
        }


        [HttpGet]
        public ActionResult EditVehicleServiceDetails(int vehicleServiceId)
        {
            var vs = _vehicleServiceService.GetServiceById(vehicleServiceId);

            var vm = Mapper.Map<VehicleService, VehicleServiceEditViewModel>(vs);

            PopulateSelectListDataSources();

            return View("VehicleServiceDetailsForm", vm);

        }

        [HttpGet]
        public ActionResult CreateVehicleServiceForScheduleDetails(int scheduleServiceId, int vehicleId, int scheduleServiceTypeId)
        {
            var vm = new VehicleServiceEditViewModel
            {
                Id = 0
                ,
                StartDate = DateTime.Today
                ,
                ScheduleServiceId = scheduleServiceId
                ,
                ScheduleServiceTypeId = scheduleServiceTypeId
                ,
                ServiceTypeId = (int)Parameters.VehicleService.Schedule_Maintenance
            };

            PopulateSelectListDataSources();

            return View("VehicleServiceDetailsForm", vm);

        }

        [HttpGet]
        public ActionResult CreateVehicleServiceDetails()
        {
            var vm = new VehicleServiceEditViewModel { Id = 0, StartDate = DateTime.Today };

            PopulateSelectListDataSources();

            return View("VehicleServiceDetailsForm",vm);
        }

        [HttpGet]
        public ActionResult CreateVehicleScheduledServiceDetails()
        {
            var vm = new VehicleServiceScheduleEditViewModel { Id = 0, ServiceAlertDate = DateTime.Today };

            PopulateSelectListDataSources();

            return View("VehicleServiceScheduleDetailsForm", vm);
        }

        [HttpGet]
        public ActionResult ViewVehicleScheduledServiceDetails(int vehicleScheduledServiceId)
        {
            var vss = _vehicleServiceScheduleService.GetScheduleServiceById(vehicleScheduledServiceId);

            var vm = Mapper.Map<ScheduleService, VehicleServiceScheduleDisplayViewModel>(vss);

            var vs = _vehicleServiceService.GetAll().FirstOrDefault(x => x.ScheduleServiceId == vss.Id);

            if (vs != null)
            {
                vm.VehicleServiceDisplayViewModel = MapVehicleServiceDisplayInfo(vs.Id);
            }

           

            return View("VehicleServiceScheduleDetailsView", vm);
        }

        [HttpGet]
        public ActionResult EditVehicleScheduledServiceDetails(int vehicleScheduledServiceId)
        {
            var vss = _vehicleServiceScheduleService.GetScheduleServiceById(vehicleScheduledServiceId); 

            var vm = Mapper.Map<ScheduleService, VehicleServiceScheduleEditViewModel>(vss);

            var vs = _vehicleServiceService.GetAll().FirstOrDefault(x => x.ScheduleServiceId == vss.Id);

            if (vs != null)
            {
                vm.VehicleServiceDisplayViewModel = MapVehicleServiceDisplayInfo(vs.Id);
            }            

            PopulateSelectListDataSources();

            return View("VehicleServiceScheduleDetailsForm", vm);
        }


        #endregion

        #region 3.b. Get List of Values Related Actions


        #endregion

        #region 3.c. Grid Related Actions

        public ActionResult GetVehicleServicesList([DataSourceRequest] DataSourceRequest request
            ,string serviceJobNumber, string registrationNumber, int unitNumber, int groupNumber, int center, bool completeStatus, bool inCompleteStatus)
        {

            var vs = _vehicleServiceService.GetFilterByCenterPermission(CurrentUser, serviceJobNumber, registrationNumber, groupNumber, center, inCompleteStatus, completeStatus);

            var vm = Mapper.Map<IEnumerable<VehicleService>, IEnumerable<VehicleServiceDisplayViewModel>>(vs);            

            return Json(vm.ToDataSourceResult(request));
        }


        public ActionResult GetVehicleScheduledServicesList([DataSourceRequest] DataSourceRequest request
            , string registrationNumber, int unitNumber, int groupNumber, int center, bool showScheduledVehicles, bool showUnscheduledVehicles)
        {


            var result = _vehicleServiceScheduleService.GetFilterByCenterPermission(CurrentUser, registrationNumber, groupNumber, center);

            if (showScheduledVehicles && !showUnscheduledVehicles) //get schedules that are attached to vehicle services
            {

                var vs = _vehicleServiceService.GetAll().Where(x => x.ScheduleServiceId.HasValue && !x.EndDate.HasValue).Select(x => x.ScheduleServiceId).Distinct();

                result = result.Where(ss => vs.Any(s => s == ss.Id));

            }

            if (showUnscheduledVehicles && !showScheduledVehicles) //get schedules that are NOT attached to any vehicle services
            {

                var vs = _vehicleServiceService.GetAll().Where(x => x.ScheduleServiceId.HasValue);

                result = result.Where(ss => !vs.Any(s => s.ScheduleServiceId == ss.Id));
            }

            var vm = Mapper.Map<IEnumerable<ScheduleService>, IEnumerable<VehicleServiceScheduleDisplayViewModel>>(result);

            return Json(vm.ToDataSourceResult(request));
        }

                     
        #endregion

        #region 3.d. Form CRUD Post Related Actions        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVehicleServiceDetails(VehicleServiceEditViewModel entityViewModel)
        {
            try
            {
                if (ModelState.IsValid && entityViewModel != null)
                {
                    var v = _vehicleManagementService.GetVehicleById((int)entityViewModel.VehicleId);

                    var vs = Mapper.Map<VehicleServiceEditViewModel, VehicleService>(entityViewModel);

                    vs.CenterId = v.CenterId;
                    vs.BusinessGroupId = v.BusinessGroupId;

                    if (entityViewModel.Cost != null && Math.Abs((decimal)entityViewModel.Cost) > 0)
                    {
                        vs.IsAmountPaid = true;
                    }
                    else
                    {
                        vs.IsAmountPaid = false;
                    }

                    if (entityViewModel.IncidentId != null && entityViewModel.IncidentId > 0)
                    {
                        vs.IsIncidentService = true;
                    }
                    else
                    {
                        vs.IsIncidentService = false;
                    }

                    vs.CreatedBy = CurrentUser;
                    vs.CreatedDate = DateTime.Now;


                    _vehicleServiceService.Create(vs);

                    _vehicleServiceService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.VehicleService, Parameters.Table.Service);

                    UpdateVehicleLastServiceDate(vs);

                    return Json(new { message = "Changes saved successfully.", isError = false });
                }
                else
                {
                    return Json(new { message = "The ModelState is invalid or the ViewModel is null.", isError = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    message = ex.Message.Length > 100 ? ex.Message.Substring(0, 100) + " ..." : ex.Message,
                    isError = true
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateVehicleServiceDetails(VehicleServiceEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var vs = Mapper.Map<VehicleServiceEditViewModel, VehicleService>(entityViewModel);

                    if (entityViewModel.Cost != null && Math.Abs((decimal)entityViewModel.Cost) > 0)
                    {
                        vs.IsAmountPaid = true;
                    }
                    else
                    {
                        vs.IsAmountPaid = false;
                    }

                    if (entityViewModel.IncidentId != null && entityViewModel.IncidentId > 0)
                    {
                        vs.IsIncidentService = true;
                    }
                    else
                    {
                        vs.IsIncidentService = false;
                    }

                    vs.LastUpdatedBy = CurrentUser;
                    vs.LastUpdatedDate = DateTime.Now;

                    _vehicleServiceService.Update(vs);

                    _vehicleServiceService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.VehicleService, Parameters.Table.Service);

                    UpdateVehicleLastServiceDate(vs);

                    return Json(new { message = "Changes saved successfully.", isError = false });


                }
                else
                {
                    return Json(new { message = "The ModelState is invalid or the ViewModel is null.", isError = true });
                }
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    message = ex.Message.Length > 100 ? ex.Message.Substring(0, 100) + " ..." : ex.Message,
                    isError = true
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]      
        public ActionResult DeleteVehicleServiceDetails(int id)
        {
            try
            {
                if (ModelState.IsValid && id != 0)
                {
 
                        var vehicleServiceToDelete = _vehicleServiceService.GetServiceById(id);
                        _vehicleServiceService.Delete(vehicleServiceToDelete);
                        _vehicleServiceService.Save();
                        CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.VehicleService, Parameters.Table.Service);


                    return Json(new { message = "Vehicle Service record deleted.", isError = false });
 

                }
                else
                {

                    return Json(new { message = "The ModelState is invalid or the Id is 0.", isError = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message, isError = true });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult CreateVehicleServiceScheduleDetails(VehicleServiceScheduleEditViewModel entityViewModel)
        {
            try
            {
                if (ModelState.IsValid && entityViewModel != null)
                {
                    var v = _vehicleManagementService.GetVehicleById((int)entityViewModel.VehicleId);

                    var vss = Mapper.Map<VehicleServiceScheduleEditViewModel, ScheduleService>(entityViewModel);

                    vss.CurrentMileage = v.CurrentMileage;

                    _vehicleServiceScheduleService.Create(vss);

                    _vehicleServiceScheduleService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.VehicleServiceSchedule, Parameters.Table.ScheduleService);

                    return Json(new { message = "Changes saved successfully.", isError = false });
                }
                else
                {
                    return Json(new { message = "The ModelState is invalid or the ViewModel is null.", isError = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    message = ex.Message.Length > 100 ? ex.Message.Substring(0, 100) + " ..." : ex.Message,
                    isError = true
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult UpdateVehicleServiceScheduleDetails(VehicleServiceScheduleEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var vss = Mapper.Map<VehicleServiceScheduleEditViewModel, ScheduleService>(entityViewModel);


                    _vehicleServiceScheduleService.Update(vss);

                    _vehicleServiceScheduleService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.VehicleServiceSchedule, Parameters.Table.ScheduleService);

                    return Json(new { message = "Changes saved successfully.", isError = false });


                }
                else
                {
                    return Json(new { message = "The ModelState is invalid or the ViewModel is null.", isError = true });
                }
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    message = ex.Message.Length > 100 ? ex.Message.Substring(0, 100) + " ..." : ex.Message,
                    isError = true
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVehicleServiceScheduleDetails(int id)
        {
            try
            {
                if (ModelState.IsValid && id != 0)
                {

                    var vss = _vehicleServiceScheduleService.GetScheduleServiceById(id);
                    _vehicleServiceScheduleService.Delete(vss);
                    _vehicleServiceScheduleService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.VehicleServiceSchedule, Parameters.Table.ScheduleService);


                    return Json(new { message = "Vehicle Service Schedule record deleted.", isError = false });


                }
                else
                {

                    return Json(new { message = "The ModelState is invalid or the Id is 0.", isError = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    message = ex.Message.Length > 100 ? ex.Message.Substring(0, 100) + " ..." : ex.Message,
                    isError = true
                });
            }
        }

        #endregion

        #region 3.e. Other Post Related Actions  

        [HttpPost] 
        public ActionResult GetNewServiceJobNumber(int vehicleId)
        {
            try
            {
                var v = _vehicleManagementService.GetVehicleById(vehicleId);
                var centerId = (int)v.CenterId;

                int nextJobNumber = _centerService.GetNextServiceNumberForMonth(centerId, DateTime.Today.ToString("MM"), DateTime.Today.ToString("yy"));

                if (nextJobNumber == 0)
                {
                    return Json(new { serviceJobNumber = "Capacity Reached!", message = "Cannot generate anymore vehicle service jobs for this center. Monthly vehicle service capacity reached.", isError = true });
                }
                else
                {
                    var center = _centerService.GetByCenterNumber(centerId);


                    if (string.IsNullOrEmpty(center.CenterCode))
                    {
                        return Json(new { serviceJobNumber = "Center code is null!", message = "Please enter vehicle center code first before servicing.", isError = true });
                    }
                    else
                    {
                        string nextJobNumStr = nextJobNumber.ToString().PadLeft(3, '0');
                        string cc = center.CenterCode.PadLeft(2, '0');


                        string nextServiceJobNumber = 'S' + cc + nextJobNumStr + DateTime.Today.ToString("MM") + DateTime.Today.ToString("yy");

                        return Json(new { serviceJobNumber = nextServiceJobNumber, message = "New vehicle service job number successfully generated.", isError = false });
                    }


                }

            }
            
            catch (Exception ex)
            {
                return Json(new
                {
                    message = ex.Message.Length > 100 ? ex.Message.Substring(0, 100) + " ..." : ex.Message,
                    isError = true
                });
            }


        }

        #endregion

        #endregion

        #region 4. Private Methods

        private void UpdateVehicleLastServiceDate(VehicleService s)
        {
            //update vehicle Current Mileage when refuelling
            if (s.VehicleId != null && s.StartDate != null)
            {
                var m = _vehicleManagementService.GetVehicleById((int)s.VehicleId);
                m.LastServiceDate = s.StartDate;

                m.LastUpdatedBy = CurrentUser;
                m.LastUpdatedDate = DateTime.Now;

                _vehicleManagementService.Update(m);
                _vehicleManagementService.Save();
                CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Vehicle, Parameters.Table.Vehicle);
            }
        }

        private void PopulateSelectListDataSources()
        {

            ViewBag.ServiceProviders = _contactDetailService.GetSupplierContacts().Select(t => new { Value = t.Id, Text = t.ContactName });
            ViewBag.ServiceTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.ServiceType).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.ScheduleServiceTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.ScheduleServiceType).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.IncidentServices = _incidentService.GetAll().Select(t => new { Value = t.Id, Text = t.IncidentFileNumber });
            ViewBag.ServiceMechanics = _contactDetailService.GetMechanicContacts().Select(t => new { Value = t.Id, Text = t.ContactName });
            ViewBag.Vehicles = _vehicleManagementService.GetFilterByCenterPermission(CurrentUser).Select(t => new { Value = t.Id, Text = t.RegistrationNumber });

        }



        #endregion
    }
}
