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
    public class VehicleManagementController : BaseController
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
        private readonly IAppRoleActionAccessService _appRoleActionAccessService;


        #endregion

        #region 2. Constructors
        public VehicleManagementController(IVehicleManagementService vehicleManagementService
            , IBusinessUnitService businessUnitService
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
            ,IAppRoleActionAccessService appRoleActionAccessService
            , IAppRoleInterfaceAccessService appRoleInterfaceAccessService
            , IAppRoleMenuAccessService appRoleMenuAccessService
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
            _appRoleActionAccessService = appRoleActionAccessService;
         

        }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions
       
        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.VEHICLE_REGISTER)]
        public ActionResult Vehicles(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;
            ViewBag.Centers = _centerService.GetAllCenterWithPermission(CurrentUser).Select(t => new { Value = t.CenterNumber, Text = t.Name });


            return View();
        }


        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.VIEW_BOS_VEHICLES)]
        public ActionResult VehiclesBOS()
        {
            ViewBag.Centers = _centerService.GetAllCenterWithPermission(CurrentUser).Select(t => new { Value = t.CenterNumber, Text = t.Name });
            return View();
        }



        [HttpGet]
        [UserActionAuthorization(Parameters.Action.VIEW_VEHICLES)]        
        public ActionResult GetVehicleDetails(int id)
        {

            var vm = this.PopulateVehicleViewDetails(id);
            return View("VehicleView", vm);
        }
        [HttpGet]
        [UserActionAuthorization(Parameters.Action.SETUP_NEW_VEHICLE)]
        public ActionResult CreateVehicle()
        {
            VehicleEditViewModel vehicleToCreate = new VehicleEditViewModel();
            this.PopulateSelectListDataSources();
            return View("VehicleForm", vehicleToCreate);
            
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.UPDATE_VEHICLE_REGISTRY)]
        public ActionResult EditVehicle(int id)
        {           
            var vehicleToEdit = _vehicleManagementService.GetVehicleById(id);            

            VehicleEditViewModel viewModelFormVehicle = Mapper.Map<Vehicle, VehicleEditViewModel>(vehicleToEdit);
          
            this.PopulateSelectListDataSources();

            return View("VehicleForm", viewModelFormVehicle);
        }

        #endregion

        #region 3.b. Get List of Values Related Actions

        #endregion

        #region 3.c. Grid Related Actions
        public ActionResult GetVehiclesList([DataSourceRequest] DataSourceRequest request
            , string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int center)
        {

            var vehicles = _vehicleManagementService.GetFilterByCenterPermission(CurrentUser
                            , assetNumber
                            , registrationNumber
                            , unitNumber
                            , groupNumber
                            , center
                            );

            var viewModelVehicleList = Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleDisplayViewModel>>(vehicles);

            return Json(viewModelVehicleList.ToDataSourceResult(request));
        }

        public ActionResult GetBOSVehiclesList([DataSourceRequest] DataSourceRequest request
    , string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int center)
        {

            var vehicles = _vehicleManagementService.GetFilterByCenterPermissionBOS(CurrentUser
                            , assetNumber
                            , registrationNumber
                            , unitNumber
                            , groupNumber
                            , center
                            );

            var viewModelVehicleList = Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleBOSDisplayViewModel>>(vehicles);

            return Json(viewModelVehicleList.ToDataSourceResult(request));
        }





        #endregion

        #region 3.d. Form CRUD Post Related Actions


        [HttpPost]
        public ActionResult CheckIfVehicleIsInUse(int id)
        {
            try
            {
                if (ModelState.IsValid && id != 0)
                {

                    bool isInUse = _vehicleManagementService.IsInUse(id);

                    if (isInUse)
                    {
                        return Json(new { isInUse = true, message = "Vehicle Is In Use.", isError = false });
                    }
                    else
                    {
                        return Json(new { isInUse = false, message = "Vehicle Is Not In Use.", isError = false });
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
        [UserActionAuthorization(Parameters.Action.SETUP_NEW_VEHICLE)]
        public ActionResult CreateVehicle(VehicleEditViewModel entityViewModel)
        {
            try
            {
                if (ModelState.IsValid && entityViewModel != null)
                {

                        var vehicle = Mapper.Map<VehicleEditViewModel, Vehicle>(entityViewModel);

                        UpdateFiles();

                        vehicle.CreatedBy = CurrentUser;
                        vehicle.CreatedDate = DateTime.Now;


                        _vehicleManagementService.Create(vehicle);               

                        _vehicleManagementService.Save();

                        CreateAuditTrail(Parameters.DatabaseAction.Insert,Parameters.SubSystem.Vehicle,Parameters.Table.Vehicle);

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
        [UserActionAuthorization(Parameters.Action.UPDATE_VEHICLE_REGISTRY)]
        public ActionResult EditVehicle(VehicleEditViewModel entityViewModel)
        {
            try
            {


                if (ModelState.IsValid && entityViewModel != null)
                {


                    var vehicle = Mapper.Map<VehicleEditViewModel, Vehicle>(entityViewModel);

                    UpdateFiles();

                    vehicle.LastUpdatedBy = CurrentUser;
                    vehicle.LastUpdatedDate = DateTime.Now;

                    _vehicleManagementService.Update(vehicle);


                    _vehicleManagementService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Vehicle, Parameters.Table.Vehicle);

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
        [UserActionAuthorization(Parameters.Action.UPDATE_VEHICLE_REGISTRY)]
        public ActionResult DeleteVehicle(int id)
        {
            try
            {
                if (ModelState.IsValid && id != 0)
                {

                        var vehicleToDelete = _vehicleManagementService.GetVehicleById(id);
                        _vehicleManagementService.Delete(vehicleToDelete);
                        _vehicleManagementService.Save();
                        CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.Vehicle, Parameters.Table.Vehicle);
                        return Json(new { message = "Vehicle record deleted.", isError = false });
    


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

        #region 3.e. File Upload/Download  
        public ActionResult DownloadFile(string fileName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + Parameters.AppConstant.BOSRPT_DLPATH;
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + fileName);           
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
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

                    var physicalPath = Path.Combine(Server.MapPath(Parameters.AppConstant.BOSRPT_PATH), saveAsFileName);

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

                    var physicalPath = Path.Combine(Server.MapPath(Parameters.AppConstant.BOSRPT_PATH), fileName);

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
            
            ViewBag.Suppliers = _contactDetailService.GetSupplierContacts().Select(t => new { Value = t.Id, Text = t.ContactName });
            ViewBag.BusinessUnits = _businessUnitService.GetAll().Select(t => new { Value = t.UnitNumber, Text = t.Name });
            ViewBag.Regions = _regionService.GetAll().Select(t => new { Value = t.RegionNumber, Text = t.Name });
            ViewBag.Models = _modelService.GetAll().Select(t => new { Value = t.Id, Text = t.Name });
            ViewBag.VehicleTypes = _vehicleTypeService.GetAll().Select(t => new { Value = t.Id, Text = t.Type });
            ViewBag.AcquisitionTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Acquisition).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.Makes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Make).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.FuelTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Fuel).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.Transmissions = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Transmission).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.OperationStatuses = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.VehicleOperationStatus).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.Conditions = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Condition).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.UsageStatuses = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.VehicleUsageStatus).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.FinancialStatuses = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.VehicleFinancialStatus).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.Statuses = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Status).Select(t => new { Value = t.Id, Text = t.ParameterName });
        }
        private VehicleDisplayViewModel PopulateVehicleViewDetails(int id)
        {
            var vehicle = _vehicleManagementService.GetVehicleById(id);

            VehicleDisplayViewModel viewModelViewOnlyVehicle = Mapper.Map<Vehicle, VehicleDisplayViewModel>(vehicle);

            //populate other calculated fields
            viewModelViewOnlyVehicle.CurrentAllocation = _vehicleManagementService.GetVehicleCustodianDriver(id);
            viewModelViewOnlyVehicle.TotalFuelConsumptionCostToDate = _vehicleManagementService.GetTotalFuelConsumptionCostToDate(id);
            viewModelViewOnlyVehicle.TotalServiceCostToDate = _vehicleManagementService.GetTotalServiceCostToDate(id);
            viewModelViewOnlyVehicle.Region = _vehicleManagementService.GetVehicleRegion(id);
            viewModelViewOnlyVehicle.BusinessUnit = _vehicleManagementService.GetVehicleBusinessUnit(id);

            VehicleDisposal vehicleDisposal = _vehicleDisposalService.GetVehicleDisposalByVehicleId(id);

            if (vehicleDisposal != null)
            {
                viewModelViewOnlyVehicle.DisposalValue = vehicleDisposal.Value;
                viewModelViewOnlyVehicle.DisposalDate = vehicleDisposal.Date != null ? ((DateTime)vehicleDisposal.Date).ToString("dd/MM/yyyy") : "";
                viewModelViewOnlyVehicle.DisposalReference = vehicleDisposal.Referance;
                viewModelViewOnlyVehicle.CODReport = vehicleDisposal.CODReport;
            }



            return viewModelViewOnlyVehicle;
        }
        
        #endregion
    }
}
