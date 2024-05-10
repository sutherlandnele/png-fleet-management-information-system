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
using Microsoft.AspNet.Identity;
using FMS.Web.Identity;

namespace FMS.Web.Controllers
{
    [Authorize]
    [NoDirectAccess]
    public class VehicleIncidentManagementController : BaseController
    {
        #region 1. Private Members

        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IBusinessGroupService _businessGroupService;
        private readonly ICenterService _centerService;
        private readonly IVehicleDisposalService _vehicleDisposalService;
        private readonly ISystemParameterService _systemParameterService;
        private readonly IContactDetailService _contactDetailService;
        private readonly IRegionService _regionService;
        private readonly IModelService _modelService;
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IIncidentService _incidentService;

        #endregion

        #region 2. Constructors
        public VehicleIncidentManagementController(IVehicleManagementService vehicleManagementService
            , IBusinessUnitService businessUnitService
            , IIncidentService incidentService
            , IBusinessGroupService businessGroupService
            , ICenterService centerService
            , IVehicleDisposalService vehicleDisposalService           
            , IContactDetailService contactDetailService
            , IRegionService regionService
            , IModelService modelService
            , IVehicleTypeService vehicleTypeService
            , IAuditingService auditingService
            , UserManager<IdentityUser, Guid> userManager
            , IVehicleServiceService vehicleServiceService
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
            _vehicleDisposalService = vehicleDisposalService;
            _systemParameterService = systemParameterService;
            _contactDetailService = contactDetailService;
            _regionService = regionService;
            _modelService = modelService;
            _vehicleTypeService = vehicleTypeService;
            _incidentService = incidentService;

        }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions
        [HttpGet]
        public ActionResult VehicleIncidents(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;
            PopulateSelectListDataSources();

            return View();
        }
        [HttpGet]
        public ActionResult ViewVehicleIncidentDetails(int id)
        {

            var m = _incidentService.GetIncidentById(id);

            var v = Mapper.Map<Incident, IncidentDisplayViewModel>(m);

           return View("VehicleIncidentDetailsView", v);
        }
        [HttpGet]
        public ActionResult CreateVehicleIncidentDetails()
        {
            var v = new IncidentEditViewModel { Id = 0, DateAndTime = DateTime.Today };

            PopulateSelectListDataSources();

            return View("VehicleIncidentDetailsForm", v);

        }

        [HttpGet]
        public ActionResult EditVehicleIncidentDetails(int id)
        {
            var m = _incidentService.GetIncidentById(id);

            var v = Mapper.Map<Incident, IncidentEditViewModel>(m);

            PopulateSelectListDataSources();

            return View("VehicleIncidentDetailsForm", v);
        }

        #endregion

        #region 3.b. Get List of Values Related Actions

        #endregion

        #region 3.c. Grid Related Actions
        public ActionResult GetVehicleIncidentList([DataSourceRequest] DataSourceRequest request
            , int vehicleId, string incidentFileNumber, int incidentType)
        {

            var m = _incidentService.GetFilterByCenterPermission(CurrentUser
                            , vehicleId
                            , incidentFileNumber
                            , incidentType);

            var v = Mapper.Map<IEnumerable<Incident>, IEnumerable<IncidentDisplayViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }



        #endregion

        #region 3.d. Form CRUD Post Related Actions

        [HttpPost]
        public ActionResult CheckIfVehicleIncidentIsInUse(int id)
        {
            try
            {
                if (ModelState.IsValid && id > 0)
                {

                    bool canDelete = _incidentService.CanDelete(id);

                    if (canDelete)
                    {
                        return Json(new { isInUse = false, message = "Vehicle Incident Is Not In Use.", isError = false });
                    }
                    else
                    {
                        return Json(new { isInUse = true, message = "Vehicle Incident Is In Use.", isError = false });
                    }
                }
                else
                {
                    return Json(new { isInUse = true, message = "The ModelState is invalid or the Id is 0.", isError = true });
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
        public ActionResult CreateVehicleIncidentDetails(IncidentEditViewModel entityViewModel)
        {
            try
            {
                if (ModelState.IsValid && entityViewModel != null)
                {                   

                    var m = Mapper.Map<IncidentEditViewModel, Incident>(entityViewModel);

                    UpdateFiles();

                    m.CreatedBy = CurrentUser;
                    m.CreatedDate = DateTime.Now;

                    _incidentService.Create(m);

                    _incidentService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.IncidentStatus, Parameters.Table.Incident);

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
        public ActionResult UpdateVehicleIncidentDetails(IncidentEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<IncidentEditViewModel, Incident>(entityViewModel);

                    UpdateFiles();

                    m.LastUpdatedBy = CurrentUser;
                    m.LastUpdatedDate = DateTime.Now;

                    _incidentService.Update(m);

                    _incidentService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.IncidentStatus, Parameters.Table.Incident);

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
        public ActionResult DeleteVehicleIncidentDetails(int id)
        {
            try
            {
                if (ModelState.IsValid && id != 0)
                {

                    var m = _incidentService.GetIncidentById(id);
                    _incidentService.Delete(m);
                    _incidentService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.IncidentStatus, Parameters.Table.Incident);

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
        #endregion

        #region 3.e. File Upload/Download  
        public ActionResult DownloadFile(string fileName)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + Parameters.AppConstant.INCRPT_DLPATH;

            if (System.IO.File.Exists(path + fileName))
            {

                byte[] fileBytes = System.IO.File.ReadAllBytes(path + fileName);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            else
            {
                return HttpNotFound("File not found! File has been removed!");               
            }

           
        }
        public ActionResult File_Add(IEnumerable<HttpPostedFileBase> files, string fileType )
        {
            // The Name of the Upload component must be the same as the name (id) given to the kendoUpload control

            if (files != null)
            {
                
                foreach (var file in files)
                {
                    if (Session["FilesToRemove"] != null)
                    {
                        var filesToRemove = Session["FilesToRemove"] as List<string>;

                        if (filesToRemove.Contains(Path.GetFileName(file.FileName)))
                        {                         

                            filesToRemove.Remove(Path.GetFileName(file.FileName));

                            Session["FilesToRemove"] = filesToRemove;
                        }
                        else
                        {
                            CheckAndAddFilesToAdd(file, files);
                        }

                    }
                    else
                    {
                        CheckAndAddFilesToAdd(file, files);
                    }

                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult File_Remove(string[] fileNames)
        {
            if (fileNames != null)
            {
                foreach (var fileName in fileNames)
                {
                    if (Session["FilesToAdd"] != null)
                    {
                        var filesToAdd = Session["FilesToAdd"] as List<HttpPostedFileBase>;

                        if (filesToAdd.Any(item => Path.GetFileName(item.FileName) == fileName))
                        {
                            RemoveFileFromFilesToAdd(filesToAdd, fileName);
                        }
                        else
                        {
                            CheckAndAddFilesToRemove(fileName, fileNames);
                        }
                    }
                    else
                    {
                        CheckAndAddFilesToRemove(fileName, fileNames);
                    }
                }
               
            }

            // Return an empty string to signify success
            return Content("");
        }

        #endregion

        #endregion

        #region 4. Private Methods
        private void RemoveFileFromFilesToAdd(List<HttpPostedFileBase> filesToAdd, string fileName)
        {
            var file = filesToAdd.Find(item => Path.GetFileName(item.FileName) == fileName);

            filesToAdd.Remove(file);

            Session["FilesToAdd"] = filesToAdd;
        }
        private void CheckAndAddFilesToRemove(string fileName, string[] fileNames)
        {
            if (Session["FilesToRemove"] != null)
            {
                var filesToRemove = Session["FilesToRemove"] as List<string>;

                if (!filesToRemove.Contains(fileName))
                {
                    filesToRemove.Add(fileName);
                }

                Session["FilesToRemove"] = filesToRemove;
            }
            else
            {
                Session["FilesToRemove"] = fileNames.ToList();
            }
        }
        private void CheckAndAddFilesToAdd(HttpPostedFileBase file, IEnumerable<HttpPostedFileBase> files)
        {
            if (Session["FilesToAdd"] != null)
            {
                var filesToAdd = Session["FilesToAdd"] as List<HttpPostedFileBase>;

                if (!filesToAdd.Any(item => Path.GetFileName(item.FileName) == Path.GetFileName(file.FileName)))
                {
                    filesToAdd.Add(file);
                }

                Session["FilesToAdd"] = filesToAdd;
            }
            else
            {
                Session["FilesToAdd"] = files.ToList();
            }
        }
        private void UpdateFiles()
        {
            
            //1.check and add files
            var filesToAdd = Session["FilesToAdd"] as List<HttpPostedFileBase>;

            if (filesToAdd != null)
            {
                foreach (var file in filesToAdd)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.

                    var saveAsFileName = Path.GetFileName(file.FileName);

                    var physicalPath = Path.Combine(Server.MapPath(Parameters.AppConstant.INCRPT_PATH), saveAsFileName);

                    file.SaveAs(physicalPath);
                }
                filesToAdd.Clear();
                Session["FilesToAdd"] = filesToAdd;
            }
                                 
            //2.check and remove files
            var filesToRemove = Session["FilesToRemove"] as List<string>;

            if (filesToRemove != null)
            {

                foreach (var fullFileName in filesToRemove)
                {
                    var fileName = Path.GetFileName(fullFileName);

                    var physicalPath = Path.Combine(Server.MapPath(Parameters.AppConstant.INCRPT_PATH), fileName);

                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                }
                filesToRemove.Clear();
                Session["FilesToRemove"] = filesToRemove;
            }

        }
        private void PopulateSelectListDataSources()
        {
            //Vehicles
            ViewBag.Vehicles = _vehicleManagementService.GetFilterByCenterPermission(CurrentUser).Select(t => new { Value = t.Id, Text = t.RegistrationNumber });
            ViewBag.Drivers = _contactDetailService.GetDriverContacts().Select(t => new { Value = t.Id, Text = t.ContactName });
            ViewBag.IncidentTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.IncidentType).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.IncidentStatuses = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.IncidentStatus).Select(t => new { Value = t.Id, Text = t.ParameterName });

        }

        #endregion
    }
}
