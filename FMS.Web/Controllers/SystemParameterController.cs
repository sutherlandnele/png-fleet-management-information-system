using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using FMS.Web.Identity;
using FMS.Web.ViewModels;
using FMS.Common;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using FMS.Web.CustomActionFilters;
using System.Web.Security;
using FMS.Web.Hubs;
using FMS.Service;
using FMS.Model;
using System.IO;

namespace FMS.Web.Controllers
{
   
    [Authorize]
    [NoDirectAccess]
    public class SystemParameterController : BaseController
    {
        #region 1. Private Members

        private readonly ICenterService _centerService;
        private readonly IRegionService _regionService;
        private readonly IContactDetailService _contactDetailService;
        private readonly ISystemParameterService _systemParameterService;
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IBusinessGroupService _businessGroupService;
        private readonly IClientInformationService _clientInformationService;
        private readonly ISystemParameterCodeService _systemParameterCodeService;
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IModelService _vehicleModelService;


        #endregion

        #region 2. Constructors
        public SystemParameterController(IRegionService regionService
        ,IVehicleManagementService vehicleManagementService
        ,IAuditingService auditingService
        ,IVehicleTypeService vehicleTypeService
        ,IModelService vehicleModelService
        ,IClientInformationService clientInformationService
        ,IContactDetailService contactDetailService
        ,UserManager<IdentityUser, Guid> userManager  
        ,IVehicleServiceService vehicleServiceService
        ,ICenterService centerService
        ,IBusinessUnitService businessUnitService
        ,IBusinessGroupService businessGroupService
        ,IModelService modelService
        ,IDepotTankService depotTankService
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
            _businessGroupService = businessGroupService;
            _businessUnitService = businessUnitService;
            _centerService = centerService;
            _regionService = regionService;
            _contactDetailService = contactDetailService;
            _systemParameterService = systemParameterService;
            _clientInformationService = clientInformationService;
            _systemParameterCodeService = systemParameterCodeService;
            _vehicleTypeService = vehicleTypeService;
            _vehicleModelService = vehicleModelService;
        }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions

        #region 3.a.1 System Parameter
        [HttpGet]       
        [UserInterfaceAuthorization(Parameters.Interface.USER_DEFINE_CODES)]
        public ActionResult SystemParameters()
        {
            PopulateSelectListDataSources();
            return View();
        }
        #endregion

        #region 3.a.2 Vehicle Type

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.VEHICLE_TYPES)]
        public ActionResult VehicleTypes()
        {
            return View();
        }

        
        #endregion

        #region 3.a.3 Vehicle Model

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.VEHICLE_MODEL)]
        public ActionResult VehicleModels()
        {

            PopulateSelectListDataSources();
            return View();
        }

        #endregion

        #endregion

        #region 3.b. Get List of Values Related Actions

        #endregion

        #region 3.c. Grid Related Actions

        #region 3.c.1 System Paramter
        public ActionResult GetSystemParameterList([DataSourceRequest] DataSourceRequest request, int systemParameterCode)
        {
            var m = _systemParameterService.GetAllFilterByParameterType(systemParameterCode);

            var v = Mapper.Map<IEnumerable<SystemParameter>, IEnumerable<SystemParameterViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateSystemParameter([DataSourceRequest] DataSourceRequest request, SystemParameterViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_USER_DEFINED_CODES))
            {
                try
                {
                    if (entityViewModel != null && ModelState.IsValid)
                    {

                        var m = Mapper.Map<SystemParameterViewModel, SystemParameter>(entityViewModel);
                        _systemParameterService.Create(m);
                        _systemParameterService.Save();

                        CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.SystemParameters, Parameters.Table.SystemParameters);

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

        public ActionResult EditSystemParameter([DataSourceRequest] DataSourceRequest request, SystemParameterViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_USER_DEFINED_CODES))
            { 
                try
            {
                if (entityViewModel != null && ModelState.IsValid)
                {
                    var m = Mapper.Map<SystemParameterViewModel, SystemParameter>(entityViewModel);
                    _systemParameterService.Update(m);
                    _systemParameterService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.SystemParameters, Parameters.Table.SystemParameters);

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

        public ActionResult DeleteSystemParameter([DataSourceRequest] DataSourceRequest request, SystemParameterViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_USER_DEFINED_CODES))
            {
                try
                {
                    if (entityViewModel != null && ModelState.IsValid)
                    {
                        if (!_systemParameterService.IsInUse(entityViewModel.Id))
                        {
                            var m = _systemParameterService.GetAll().FirstOrDefault(x => x.Id == entityViewModel.Id);

                            _systemParameterService.Delete(m);
                            _systemParameterService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.SystemParameters, Parameters.Table.SystemParameters);
                        }
                        else
                        {
                            ModelState.AddModelError("", "User defined code cannot be deleted. It is currently in use.");
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

        #region 3.c.2 Vehicle Type
        public ActionResult GetVehicleTypeList([DataSourceRequest] DataSourceRequest request, string vehicleType)
        {
            var m = _vehicleTypeService.GetAll(vehicleType);

            var v = Mapper.Map<IEnumerable<VehicleType>, IEnumerable<VehicleTypeViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateVehicleType([DataSourceRequest] DataSourceRequest request, VehicleTypeViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_VEHICLE_TYPES))
            {
                try
            {
                if (entityViewModel != null && ModelState.IsValid)
                {

                    var m = Mapper.Map<VehicleTypeViewModel, VehicleType>(entityViewModel);
                    _vehicleTypeService.Create(m);
                    _vehicleTypeService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.SystemParameters, Parameters.Table.VehicleType);

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
        public ActionResult EditVehicleType([DataSourceRequest] DataSourceRequest request, VehicleTypeViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_VEHICLE_TYPES))
            {
                try
            {
                if (entityViewModel != null && ModelState.IsValid)
                {
                    var m = Mapper.Map<VehicleTypeViewModel, VehicleType>(entityViewModel);
                    _vehicleTypeService.Update(m);
                    _vehicleTypeService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.SystemParameters, Parameters.Table.VehicleType);

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
        public ActionResult DeleteVehicleType([DataSourceRequest] DataSourceRequest request, VehicleTypeViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_VEHICLE_TYPES))
            {
                try
            {
                if (entityViewModel != null && ModelState.IsValid)
                {

                        var m = _vehicleTypeService.GetVehicleTypeById(entityViewModel.Id);

                        _vehicleTypeService.Delete(m);
                        _vehicleTypeService.Save();

                        CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.SystemParameters, Parameters.Table.VehicleType);


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

        #region 3.c.3 Vehicle Model
        public ActionResult GetVehicleModelList([DataSourceRequest] DataSourceRequest request, string vehicleModel, int vehicleMake)
        {
            var m = _vehicleModelService.GetAll(vehicleModel, vehicleMake);

            var v = Mapper.Map<IEnumerable<FMS.Model.Model>, IEnumerable<VehicleModelViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateVehicleModel([DataSourceRequest] DataSourceRequest request, VehicleModelViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_VEHICLE_MODEL))
            {
                try
            {
                if (entityViewModel != null && ModelState.IsValid)
                {

                    var m = Mapper.Map<VehicleModelViewModel, FMS.Model.Model>(entityViewModel);
                    _vehicleModelService.Create(m);
                    _vehicleModelService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.SystemParameters, Parameters.Table.Model);

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
        public ActionResult EditVehicleModel([DataSourceRequest] DataSourceRequest request, VehicleModelViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_VEHICLE_MODEL))
            {
                try
                {
                    if (entityViewModel != null && ModelState.IsValid)
                    {
                        var m = Mapper.Map<VehicleModelViewModel, FMS.Model.Model>(entityViewModel);
                        _vehicleModelService.Update(m);
                        _vehicleModelService.Save();

                        CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.SystemParameters, Parameters.Table.Model);

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
        public ActionResult DeleteVehicleModel([DataSourceRequest] DataSourceRequest request, VehicleModelViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_VEHICLE_MODEL))
            {
                try
                {
                    if (entityViewModel != null && ModelState.IsValid)
                    {

                        var m = _vehicleModelService.GetModelById(entityViewModel.Id);

                        _vehicleModelService.Delete(m);
                        _vehicleModelService.Save();

                        CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.SystemParameters, Parameters.Table.Model);


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



        #endregion

        #region 3.d. Form CRUD Post Related Actions
        #endregion

        #region 3.e. Other Post Related Actions


        #endregion

        #endregion

        #region 4. Protected Members

        #endregion

        #region 5. Private Members
        private void PopulateSelectListDataSources()
        {
            ViewBag.VehicleMakes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Make).Select(t => new { Value = t.Id, Text = t.ParameterName });          
            ViewBag.SystemParameterCodes = _systemParameterCodeService.GetAll().Select(t => new { Value = t.Id, Text = t.ParameterCode });
        }

        #endregion

        #region 6. Helpers

        #endregion
    }
}