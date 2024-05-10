using AutoMapper;
using FMS.Common;
using FMS.Model;
using FMS.Service;
using FMS.Web.CustomActionFilters;
using FMS.Web.Identity;
using FMS.Web.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMS.Web.Controllers
{
    [Authorize]
    [NoDirectAccess]
    public class VehicleDisposalController : BaseController
    {
        #region 1. Private Members
        private readonly IVehicleDisposalService _vehicleDisposalService;
        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly ICenterService _centerService;
        private readonly UserManager<IdentityUser, Guid> _userManager;

        #endregion

        #region 2. Constructors
        public VehicleDisposalController(IVehicleDisposalService vehicleDisposalService
            ,IVehicleManagementService vehicleManagementService         
            , IAuditingService auditingService
            , ICenterService centerService
            ,IContactDetailService contactDetailService
            , UserManager<IdentityUser, Guid> userManager
            , IVehicleServiceService vehicleServiceService        
            , IBusinessUnitService businessUnitService
            , IBusinessGroupService businessGroupService
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
                _vehicleDisposalService = vehicleDisposalService;
                _vehicleManagementService = vehicleManagementService;
                _centerService = centerService;
                _userManager = userManager;
            }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions
        [HttpGet]
        [UserActionAuthorization(Parameters.Action.VIEW_DISPOSED_VEHICLES)]
        public ActionResult GetDisposeVehicle(int vehId)
        {
       
            var vehicle = _vehicleManagementService.GetVehicleById(vehId);

            var vm = new VehicleDisposalEditViewModel {Id = 0
                , VehicleId = vehId
                , VehicleRegoNumber = vehicle.RegistrationNumber
                , VehicleCondition = vehicle.Condition.ParameterName
                , VehicleMake = vehicle.Make.ParameterName
                , VehicleModel = vehicle.Model.Name
                , VehicleStatus = vehicle.Status.ParameterName
                , VehicleType = vehicle.VehicleType.Type
            };

            return PartialView("VehicleDisposalForm", vm);
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.VIEW_DISPOSED_VEHICLES)]
        public ActionResult VehiclesDisposed()
        {
            ViewBag.Centers = _centerService.GetAllCenterWithPermission(CurrentUser).Select(t => new { Value = t.CenterNumber, Text = t.Name });

            return View();
        }

        #endregion

        #region 3.b. Get List of Values Related Actions

        #endregion

        #region 3.c. Grid Related Actions
        public ActionResult VehiclesDisposed_Grid_Read([DataSourceRequest] DataSourceRequest request
           , string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int center)
        {

            IEnumerable<Vehicle> vehiclesDisposed = _vehicleManagementService.GetDisposedVehicles(CurrentUser
                            , assetNumber
                            , registrationNumber
                            , unitNumber
                            , groupNumber
                            , center
                            );

            IEnumerable<VehicleDisposal> disposals = _vehicleDisposalService.GetAll();
           

            IEnumerable<VehicleDisplayViewModel> vehiclesDisposedViewModel = from v in vehiclesDisposed
                                                                              join d in disposals on v.Id equals d.VehicleId
                                                                              select new VehicleDisplayViewModel
                                                                              {
                                                                                  DisposalValue = d.Value,
                                                                                  DisposalDate = d.Date!=null? ((DateTime)d.Date).ToString("dd/MM/yyyy"):"",
                                                                                  DisposalReference = d.Referance,
                                                                                  CODReport = d.CODReport,
                                                                                  AssetNumber = v.AssetNumber,
                                                                                  BusinessGroup = v.BusinessGroup.GroupName,
                                                                                  RegistrationNumber = v.RegistrationNumber,
                                                                                  VehicleType = v.VehicleType.Type,
                                                                                  Make = v.Make.ParameterName,
                                                                                  Center = v.Center.Name,
                                                                                  Condition = v.Condition.ParameterName,
                                                                                  Status = v.Status.ParameterName,
                                                                                  CurrentMileage = v.CurrentMileage,
                                                                                  BOS_Recommendation = v.BOS_Recommendation != null ? (v.BOS_Recommendation == true ? "Yes" : "No") : "",
                                                                                  Id = v.Id
                                                                                 
                                                                              };

            return Json(vehiclesDisposedViewModel.ToDataSourceResult(request));
        }
        #endregion

        #region 3.d. Form CRUD Post Related Actions



        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.DISPOSE_VEHICLE)]
        public ActionResult DisposeVehicle(VehicleDisposalEditViewModel entityViewModel)
        {
            if (ModelState.IsValid && entityViewModel != null)
            {
                try
                {
                    //1.create disposal record
                    entityViewModel.DisposalUserId = CurrentUser;

                    var vehicleToDispose = Mapper.Map<VehicleDisposalEditViewModel, VehicleDisposal>(entityViewModel);

                    _vehicleDisposalService.Create(vehicleToDispose);

                    UpdateFiles();

                    _vehicleDisposalService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.vehicleDisposal, Parameters.Table.VehicleDisposal);


                    //2.update vehicle status to dispose
                    var vehicle = _vehicleManagementService.GetVehicleById((int)entityViewModel.VehicleId);
                    vehicle.StatusId = Convert.ToInt32(Parameters.VehicleFinancialStatus.Disposed);
                    _vehicleManagementService.Update(vehicle);
                    _vehicleManagementService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Vehicle, Parameters.Table.Vehicle);

                    return Json(new { message = "Changes saved successfully.", isError = false });
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
            else
            {
                return Json(new { message = "The ModelState is invalid or the ViewModel is null.", isError = true });
            }
        }

        #endregion

        #region 3.e. File Upload/Download  
        public ActionResult DownloadFile(string fileName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + Parameters.AppConstant.CODRPT_DLPATH;
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + fileName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public ActionResult File_Add(IEnumerable<HttpPostedFileBase> files, string fileType)
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

                    var physicalPath = Path.Combine(Server.MapPath(Parameters.AppConstant.CODRPT_PATH), saveAsFileName);

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
        #endregion
    }
}