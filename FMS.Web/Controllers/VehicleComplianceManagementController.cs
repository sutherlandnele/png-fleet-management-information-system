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
    public class VehicleComplianceManagementController : BaseController
    {
        #region 1. Private Members

        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly ICenterService _centerService;
        private readonly ISystemParameterService _systemParameterService;
        private readonly IContactDetailService _contactDetailService;
        private readonly INotificationService _notificationService;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IComplianceService _complianceService;
        private readonly IAlertService _alertService;
        private readonly IVehicleServiceScheduleService _vehicleServiceScheduleService;
        
        
        #endregion

        #region 2. Constructors
        public VehicleComplianceManagementController(IVehicleManagementService vehicleManagementService         
            , IVehicleServiceScheduleService vehicleServiceScheduleService
            , INotificationService notificationService
            , IEmailTemplateService emailTemplateService
            , IComplianceService complianceService
            , IAlertService alertService
            , IDepotTankService depotTankService          
            , ICenterService centerService           
            , IContactDetailService contactDetailService
            , IVehicleServiceService vehicleServiceService
            , IAuditingService auditingService
            , UserManager<IdentityUser, Guid> userManager          
            , IBusinessUnitService businessUnitService
            , IBusinessGroupService businessGroupService
            , IModelService modelService
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
            _vehicleServiceScheduleService = vehicleServiceScheduleService;
            _centerService = centerService;
            _systemParameterService = systemParameterService;
            _contactDetailService = contactDetailService;
            _notificationService = notificationService;
            _emailTemplateService = emailTemplateService;
            _complianceService = complianceService;
            _alertService = alertService;

        }

        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions


        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.ALERTS)]
        public ActionResult Alerts(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;
            PopulateSelectListDataSources();

            return View();
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.MANAGE_NOTIFICATION)]
        public ActionResult Notifications(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;
            PopulateSelectListDataSources();

            return View();
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.COMPLIANCE_ENTRIES)]
        public ActionResult VehicleRegistrations(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;
            PopulateSelectListDataSources();

            return View();
        }


        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.COMPLIANCE_ENTRIES)]
        public ActionResult VehicleSafetyStickers(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;
            PopulateSelectListDataSources();

            return View();
        }


        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.COMPLIANCE_DASHBOARD)]
        public ActionResult VehicleComplianceDashboard()
        {
            return View();
        }

        


        #endregion

        #region 3.b. Get List of Values Related Actions


        #endregion

        #region 3.c. Grid Related Actions

        #region Vehicle Compliance Dashboard
        public ActionResult GetVehicleDueForServiceList([DataSourceRequest] DataSourceRequest request)
        {

            var vm = (from s in _vehicleServiceScheduleService.GetVehicleListByScheduleServiceRenewal()
                       join v in _vehicleManagementService.GetFilterByCenterPermission(CurrentUser) on s.VehicleId equals v.Id
                       select new VehicleDueForServiceDisplayViewModel
                       {
                           Id = v.Id,
                           Center = v.Center != null ? v.Center.Name : string.Empty,
                           RegistrationNumber = v.RegistrationNumber,
                           CurrentMileage = v.CurrentMileage.ToString(),
                           AlertMileage = s.ServiceAlertMileage.ToString(),
                           AlertDate = s.ServiceAlertDate
                       }).OrderBy(x => x.AlertDate).ThenBy(x => x.Center);
          
            return Json(vm.ToDataSourceResult(request));
        }

        public ActionResult GetVehicleRegistrationExpiryList([DataSourceRequest] DataSourceRequest request)
        {

            var vm = (from a in _vehicleManagementService.GetVehicleRegistrationExpiryByCenterPermission(CurrentUser)
                      select new VehicleRegistrationExpiryDisplayViewModel
                      {
                          Id = a.Id,
                          Center = a.Center != null ? a.Center.Name : string.Empty,
                          RegistrationNumber = a.RegistrationNumber,
                          RegistrationExpiry = a.RegistrationExpiry 

                      });

            return Json(vm.ToDataSourceResult(request));
        }

        public ActionResult GetVehicleSafetyStickerExpiryList([DataSourceRequest] DataSourceRequest request)
        {

            var vm = (from a in _vehicleManagementService.GetVehicleSafetyStickerExpiryByCenterPermission(CurrentUser)
                      select new VehicleSafetyStickerExpiryDisplayViewModel
                      {
                          Id = a.Id,
                          Center = a.Center != null ? a.Center.Name : string.Empty,
                          RegistrationNumber = a.RegistrationNumber,
                          SafetyStickerExpiry = a.SafetyStickyExpiry
                      });

            return Json(vm.ToDataSourceResult(request));
        }

        #endregion

        #region Alert
        public ActionResult GetAlertList([DataSourceRequest] DataSourceRequest request)
        {

            var m = _alertService.GetAll();

            var v = Mapper.Map<IEnumerable<Model.Alert>, IEnumerable<AlertEditViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult CreateAlert([DataSourceRequest] DataSourceRequest request, AlertEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_ALERTS))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<AlertEditViewModel, Model.Alert>(entityViewModel);
                            _alertService.Create(m);
                            _alertService.Save();
                            CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.Compliance, Parameters.Table.Compliance);
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
        public ActionResult UpdateAlert([DataSourceRequest] DataSourceRequest request, AlertEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_ALERTS))
            {
                try
                {
                    if (entityViewModel != null)
                    {

                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<AlertEditViewModel, Model.Alert>(entityViewModel);
                            _alertService.Update(m);
                            _alertService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Compliance, Parameters.Table.Compliance);
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
        public ActionResult DeleteAlert([DataSourceRequest] DataSourceRequest request, AlertEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_ALERTS))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var d = Mapper.Map<AlertEditViewModel, Model.Alert>(entityViewModel);

                            _alertService.Delete(d);

                            _alertService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.Compliance, Parameters.Table.Compliance);
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
        
        #region Notification
        public ActionResult GetNotificationList([DataSourceRequest] DataSourceRequest request
            , int notificationTypeId, int whenAppearId, int serverity, int emailTemplate)
        {

            var m = _notificationService.GetAll(notificationTypeId, whenAppearId, serverity, emailTemplate);

            var v = Mapper.Map<IEnumerable<Model.Notification>, IEnumerable<NotificationEditViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateNotification([DataSourceRequest] DataSourceRequest request, NotificationEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_NOTIFICATIONS))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<NotificationEditViewModel, Model.Notification>(entityViewModel);
                            _notificationService.Create(m);
                            _notificationService.Save();
                            CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.Notification, Parameters.Table.Notification);
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
        public ActionResult UpdateNotification([DataSourceRequest] DataSourceRequest request, NotificationEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_NOTIFICATIONS))
            {
                try
                {
                    if (entityViewModel != null)
                    {

                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<NotificationEditViewModel, Model.Notification>(entityViewModel);
                            _notificationService.Update(m);
                            _notificationService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Notification, Parameters.Table.Notification);
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
        public ActionResult DeleteNotification([DataSourceRequest] DataSourceRequest request, NotificationEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_NOTIFICATIONS))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var d = Mapper.Map<NotificationEditViewModel, Model.Notification>(entityViewModel);

                            _notificationService.Delete(d);

                            _notificationService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.Notification, Parameters.Table.Notification);
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

        #region Vehicle Registration
        public ActionResult GetVehicleRegistrationList([DataSourceRequest] DataSourceRequest request
            , int vehicleId)
        {

            var m = _complianceService.GetAllRegistryByCenterPermission(CurrentUser, vehicleId);

            var v = Mapper.Map<IEnumerable<Model.Compliance>, IEnumerable<ComplianceEditViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateVehicleRegistration([DataSourceRequest] DataSourceRequest request, ComplianceEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_COMPLICANCE_ENTRIES))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<ComplianceEditViewModel, Model.Compliance>(entityViewModel);

                            m.CreatedBy = CurrentUser;
                            m.CreatedDate = DateTime.Now;


                            _complianceService.Create(m);
                            _complianceService.Save();
                            CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.Compliance, Parameters.Table.Compliance);

                            UpdateVehicleComplianceExpiry(m);
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
        public ActionResult UpdateVehicleRegistration([DataSourceRequest] DataSourceRequest request, ComplianceEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_COMPLICANCE_ENTRIES))
            {
                try
                {
                    if (entityViewModel != null)
                    {

                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<ComplianceEditViewModel, Model.Compliance>(entityViewModel);

                            m.LastUpdatedBy = CurrentUser;
                            m.LastUpdatedDate = DateTime.Now;

                            _complianceService.Update(m);
                            _complianceService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Compliance, Parameters.Table.Compliance);

                            UpdateVehicleComplianceExpiry(m);
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
        public ActionResult DeleteVehicleRegistration([DataSourceRequest] DataSourceRequest request, ComplianceEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_COMPLICANCE_ENTRIES))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var d = Mapper.Map<ComplianceEditViewModel, Model.Compliance>(entityViewModel);

                            _complianceService.Delete(d);

                            _complianceService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.Compliance, Parameters.Table.Compliance);
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

        #region Vehicle SafetySticker
        public ActionResult GetVehicleSafetyStickerList([DataSourceRequest] DataSourceRequest request
            , int vehicleId)
        {

            var m = _complianceService.GetSafetyStickerRegistryByCenterPermission(CurrentUser, vehicleId);

            var v = Mapper.Map<IEnumerable<Model.Compliance>, IEnumerable<ComplianceEditViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateVehicleSafetySticker([DataSourceRequest] DataSourceRequest request, ComplianceEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_COMPLICANCE_ENTRIES))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<ComplianceEditViewModel, Model.Compliance>(entityViewModel);


                            m.CreatedBy = CurrentUser;
                            m.CreatedDate = DateTime.Today;

                            _complianceService.Create(m);
                            _complianceService.Save();
                            CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.Compliance, Parameters.Table.Compliance);

                            UpdateVehicleComplianceExpiry(m);
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
        public ActionResult UpdateVehicleSafetySticker([DataSourceRequest] DataSourceRequest request, ComplianceEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_COMPLICANCE_ENTRIES))
            {
                try
                {
                    if (entityViewModel != null)
                    {

                        if (ModelState.IsValid)
                        {
                            var m = Mapper.Map<ComplianceEditViewModel, Model.Compliance>(entityViewModel);

                            m.LastUpdatedBy = CurrentUser;
                            m.LastUpdatedDate = DateTime.Today;

                            _complianceService.Update(m);
                            _complianceService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Compliance, Parameters.Table.Compliance);

                            UpdateVehicleComplianceExpiry(m);
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
        public ActionResult DeleteVehicleSafetySticker([DataSourceRequest] DataSourceRequest request, ComplianceEditViewModel entityViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_COMPLICANCE_ENTRIES))
            {
                try
                {
                    if (entityViewModel != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var d = Mapper.Map<ComplianceEditViewModel, Model.Compliance>(entityViewModel);

                            _complianceService.Delete(d);

                            _complianceService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.Compliance, Parameters.Table.Compliance);
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

        #endregion

        #region 3.d. Form CRUD Post Related Actions      

        #endregion

        #region 3.e. Other Post Related Actions  

        #endregion

        #endregion

        #region 4. Private Methods

        private void UpdateVehicleComplianceExpiry(Model.Compliance c)
        {
            
            if (c.RegistrationNumber != null && c.NextExpiryDate != null)
            {
                var m = _vehicleManagementService.GetVehicleById((int)c.RegistrationNumber);

                if(c.ComplianceType == (int)Parameters.ComplianceType.Registration)
                {
                    m.RegistrationExpiry = c.NextExpiryDate;
                }

                if (c.ComplianceType == (int)Parameters.ComplianceType.SafetySticker)
                {
                    m.SafetyStickyExpiry = c.NextExpiryDate;
                }

                m.LastUpdatedBy = CurrentUser;
                m.LastUpdatedDate = DateTime.Now;

                _vehicleManagementService.Update(m);
                _vehicleManagementService.Save();
                CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Vehicle, Parameters.Table.Vehicle);
            }


        }
        private void PopulateSelectListDataSources()
        {          
           
            ViewBag.NotificationTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.NotificationType).Select(t => new { Value = t.Id, Text = t.ParameterName });

            ViewBag.Severities = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Severity).Select(t => new { Value = t.Id, Text = t.ParameterName });

            ViewBag.WhenAppearTimes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.WhenAppear).Select(t => new { Value = t.Id, Text = t.ParameterName });

            ViewBag.EmailTemplates = _emailTemplateService.GetAll().Select(t => new { Value = t.Id, Text = t.TemplateName });

            ViewBag.Contacts = _contactDetailService.GetAll().Select(t => new { Value = t.Id, Text = t.ContactName });

            ViewBag.AlertTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.AlertType).Select(t => new { Value = t.Id, Text = t.ParameterName });

            ViewBag.Vehicles = _vehicleManagementService.GetFilterByCenterPermission(CurrentUser).Select(t => new { Value = t.Id, Text = t.RegistrationNumber });

        }
        #endregion


    }
}
