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



    [Authorize]
    [NoDirectAccess]
    public class DepotManagementController : BaseController
    {
        #region 1. Private Members

        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly ICenterService _centerService;
        private readonly ISystemParameterService _systemParameterService;
        private readonly IContactDetailService _contactDetailService;
        private readonly IVehicleServiceService _vehicleServiceService;
        private readonly IVehicleFuelManagementService _vehicleFuelManagementService;
        private readonly IDepotTankService _depotTankService;
        private readonly IDepotRefuelService _depotRefuelService;
        private readonly IDepotDailyMeasurementService _depotDailyMeasurementService;
        private readonly IRegionService _regionService;



        #endregion

        #region 2. Constructors
        public DepotManagementController(IVehicleManagementService vehicleManagementService
            , IVehicleFuelManagementService vehicleFuelManagementService
            , IDepotDailyMeasurementService depotDailyMeasurementService
            , IDepotTankService depotTankService
            , IRegionService regionService
            , ICenterService centerService           
            , IContactDetailService contactDetailService
            , IVehicleServiceService vehicleServiceService
            , IAuditingService auditingService
            , UserManager<IdentityUser, Guid> userManager          
            , IBusinessUnitService businessUnitService
            , IBusinessGroupService businessGroupService
            , IModelService modelService
            , IDepotRefuelService depotRefuelService
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
            ,systemParameterCodeService
            ,systemParameterService
            ,appIssueService
           )
        {
            _regionService = regionService;
            _vehicleManagementService = vehicleManagementService;
            _centerService = centerService;
            _systemParameterService = systemParameterService;
            _contactDetailService = contactDetailService;
            _vehicleServiceService = vehicleServiceService;
            _vehicleFuelManagementService = vehicleFuelManagementService;
            _depotTankService = depotTankService;
            _depotDailyMeasurementService = depotDailyMeasurementService;
            _depotRefuelService = depotRefuelService;
        }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.BOWSER_DIP_READINGS)]
        public ActionResult DepotDailyMeasurements(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;
            PopulateSelectListDataSources();

            return View();
        }


        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.BOWSER_REFUEL)]
        public ActionResult DepotRefuels(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;
            PopulateSelectListDataSources();

            return View();
        }

        [HttpGet]      
        [UserInterfaceAuthorization(Parameters.Interface.BOWSER_STATUS_SETUP)]
        public ActionResult DepotTanks(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;
            PopulateSelectListDataSources();

            return View();
        }


        #endregion

        #region 3.b. Get List of Values Related Actions


        #endregion

        #region 3.c. Grid Related Actions

        //DepotDailyMeasurement
        public ActionResult GetDepotDailyMeasurementList([DataSourceRequest] DataSourceRequest request
            , int centerId, DateTime? date, string bowserNumber)
        {            

            var m = _depotDailyMeasurementService.GetFilterByCenterPermission(CurrentUser,centerId, date, bowserNumber);

            var v = Mapper.Map<IEnumerable<DepotDailyMeasurement>, IEnumerable<DepotDailyMeasurementEditViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateDepotDailyMeasurement([DataSourceRequest] DataSourceRequest request, DepotDailyMeasurementEditViewModel entityViewModel)
        {

            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_BOWSER_DAILY_DIP_READINGS))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<DepotDailyMeasurementEditViewModel, DepotDailyMeasurement>(entityViewModel);
                            _depotDailyMeasurementService.Create(m);
                            _depotDailyMeasurementService.Save();
                            CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.DepotDailyMeasurement, Parameters.Table.DepotDailyMeasurement);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }


            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateDepotDailyMeasurement([DataSourceRequest] DataSourceRequest request, DepotDailyMeasurementEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_BOWSER_DAILY_DIP_READINGS))
            {
                try
                {
                    if (entityViewModel != null)
                    {

                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<DepotDailyMeasurementEditViewModel, DepotDailyMeasurement>(entityViewModel);
                            _depotDailyMeasurementService.Update(m);
                            _depotDailyMeasurementService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.DepotDailyMeasurement, Parameters.Table.DepotDailyMeasurement);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }
               
        [AcceptVerbs(HttpVerbs.Post)]       
        public ActionResult DeleteDepotDailyMeasurement([DataSourceRequest] DataSourceRequest request, DepotDailyMeasurementEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_BOWSER_DAILY_DIP_READINGS))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var d = Mapper.Map<DepotDailyMeasurementEditViewModel, DepotDailyMeasurement>(entityViewModel);

                            _depotDailyMeasurementService.Delete(d);

                            _depotDailyMeasurementService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.DepotDailyMeasurement, Parameters.Table.DepotDailyMeasurement);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }

        //DepotRefuel

        public ActionResult GetDepotRefuelList([DataSourceRequest] DataSourceRequest request, int centerId, string bowserNumber)
        {

            var m = _depotRefuelService.GetFilterByCenterPermission(CurrentUser, bowserNumber, centerId);

            var v = Mapper.Map<IEnumerable<DepotRefuel>, IEnumerable<DepotRefuelEditViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateDepotRefuel([DataSourceRequest] DataSourceRequest request, DepotRefuelEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_BOWSER_REFUEL))
            {

                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<DepotRefuelEditViewModel, DepotRefuel>(entityViewModel);

                            _depotRefuelService.Create(m);
                            _depotRefuelService.Save();
                            CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.DepotRefuel, Parameters.Table.DepotRefuel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]    
        public ActionResult UpdateDepotRefuel([DataSourceRequest] DataSourceRequest request, DepotRefuelEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_BOWSER_REFUEL))
            {
                try
                {
                    if (entityViewModel != null)
                    {

                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<DepotRefuelEditViewModel, DepotRefuel>(entityViewModel);
                            _depotRefuelService.Update(m);
                            _depotRefuelService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.DepotRefuel, Parameters.Table.DepotRefuel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }
            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteDepotRefuel([DataSourceRequest] DataSourceRequest request, DepotRefuelEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_BOWSER_REFUEL))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var d = Mapper.Map<DepotRefuelEditViewModel, DepotRefuel>(entityViewModel);

                            _depotRefuelService.Delete(d);

                            _depotRefuelService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.DepotRefuel, Parameters.Table.DepotRefuel);
                        }
                    }
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }

        //DepotTank

        public ActionResult GetDepotTankList([DataSourceRequest] DataSourceRequest request, string bowserNumber, string name, decimal? currentVolume, decimal? maximumCapacity)
        {

            var m = _depotTankService.GetFilterByCenterPermission(CurrentUser, bowserNumber, name, currentVolume??0, maximumCapacity??0);

            var v = Mapper.Map<IEnumerable<DepotTank>, IEnumerable<DepotTankEditViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateDepotTank([DataSourceRequest] DataSourceRequest request, DepotTankEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_BOWSER_STATUS_SETUP))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<DepotTankEditViewModel, DepotTank>(entityViewModel);

                            _depotTankService.Create(m);
                            _depotTankService.Save();
                            CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.DeportTank, Parameters.Table.DepotTank);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateDepotTank([DataSourceRequest] DataSourceRequest request, DepotTankEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_BOWSER_STATUS_SETUP))
            {
                try
                {
                    if (entityViewModel != null)
                    {

                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<DepotTankEditViewModel, DepotTank>(entityViewModel);
                            _depotTankService.Update(m);
                            _depotTankService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.DeportTank, Parameters.Table.DepotTank);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }


            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)] 
        public ActionResult DeleteDepotTank([DataSourceRequest] DataSourceRequest request, DepotTankEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_BOWSER_STATUS_SETUP))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var d = Mapper.Map<DepotTankEditViewModel, DepotTank>(entityViewModel);

                            _depotTankService.Delete(d);

                            _depotTankService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.DeportTank, Parameters.Table.DepotTank);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }
            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }


        #endregion

        #region 3.d. Form CRUD Post Related Actions      

        #endregion

        #region 3.e. Other Post Related Actions  
        [HttpPost]
        public ActionResult GetDepotTankInfo(string depotTankId)
        {
            try
            {
                var m = _depotRefuelService.GetPreviousVolume(depotTankId);

                if (m == null)            
                {
                    return Json(new { maximumCapacity = 0, currentVolume = 0, message = "Previous volume does not exist.", isError = true });
                }
                else
                {
                    return Json(new { maximumCapacity = m.MaximumCapacity, currentVolume = m.CurrentVolume, message = "Previous volume exists.", isError = false });
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
        private void PopulateSelectListDataSources()
        {          
            //Fuel Tanks/Bowser Numbers
            ViewBag.FuelTanks = _depotTankService.GetTankListByPermission(CurrentUser).Select(t => new { Value = t.BowserNumber, Text = t.BowserNumber });

            //Centers
            ViewBag.Centers = _centerService.GetAllCenterWithPermission(CurrentUser).Select(t => new { Value = t.CenterNumber, Text = t.Name });

            //Regions
            ViewBag.Regions = _regionService.GetAll().Select(t => new { Value = t.RegionNumber, Text = t.Name });
                            
            //Fuel Types
            ViewBag.FuelTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Fuel).Select(t => new { Value = t.Id, Text = t.ParameterName });
           

        }
        #endregion
    }
}
