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
    public class VehicleFuelManagementController : BaseController
    {
        #region 1. Private Members

        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly ICenterService _centerService;       
        private readonly ISystemParameterService _systemParameterService;
        private readonly IContactDetailService _contactDetailService;
        private readonly IVehicleServiceService _vehicleServiceService;
        private readonly IVehicleFuelManagementService _vehicleFuelManagementService;
        private readonly IDepotTankService _depotTankService;


        #endregion

        #region 2. Constructors
        public VehicleFuelManagementController(IVehicleManagementService vehicleManagementService
            , IVehicleFuelManagementService vehicleFuelManagementService
            ,IDepotTankService depotTankService
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
            _centerService = centerService;
            _systemParameterService = systemParameterService;
            _contactDetailService = contactDetailService;
            _vehicleServiceService = vehicleServiceService;
            _vehicleFuelManagementService = vehicleFuelManagementService;
            _depotTankService = depotTankService;
        }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.FUEL_REGISTER)]
        public ActionResult VehicleRefuels(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;

            PopulateSelectListDataSources();

            return View();
        }


        [HttpGet]
        [UserActionAuthorization(Parameters.Action.VIEW_VEHICLE_FUEL_REGISTER)]
        public ActionResult ViewVehicleRefuelDetails(int id)
        {
            var v = _vehicleFuelManagementService.GetVehicleRefuelById(id);

            var vm = Mapper.Map<VehicleRefuel, VehicleRefuelDisplayViewModel>(v);

            return View("VehicleRefuelDetailsView", vm);      
        }


        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_VEHICLE_FUEL_REGISTER)]
        public ActionResult EditVehicleRefuelDetails(int vehicleRefuelId)
        {
            var vs = _vehicleFuelManagementService.GetVehicleRefuelById(vehicleRefuelId);

            var vm = Mapper.Map<VehicleRefuel, VehicleRefuelEditViewModel>(vs);

            PopulateSelectListDataSources();

            return View("VehicleRefuelEditDetailsForm", vm);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_VEHICLE_FUEL_REGISTER)]
        public ActionResult GetCreateVehicleRefuelMasterDetails()
        {
            var vm = new VehicleRefuelEditViewModel { Id = 0, Date = DateTime.Today };

            PopulateSelectListDataSources();

            return View("VehicleRefuelCreateMasterForm", vm);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.ACQUIT_FUEL_VOUCHER)]
        public ActionResult GetVehicleRefuelDetails(int vehicleRefuelId)
        {

            var r = _vehicleFuelManagementService.GetVehicleRefuelById(vehicleRefuelId);

            var vm = Mapper.Map<VehicleRefuel, VehicleRefuelEditViewModel>(r);

            return PartialView("VehicleRefuelAcquitalForm", vm);
        }


        #endregion

        #region 3.b. Get List of Values Related Actions


        #endregion

        #region 3.c. Grid Related Actions

        public ActionResult GetVehicleRefuelsList([DataSourceRequest] DataSourceRequest request
            ,string fuelVoucherNumber, string tankNumber, int center, int fuelType, bool showVouchersNotAcquitted)
        {

            var vs = _vehicleFuelManagementService.GetFilterByCenterPermission(CurrentUser, tankNumber, fuelVoucherNumber, fuelType,center, showVouchersNotAcquitted);

            var vm = Mapper.Map<IEnumerable<VehicleRefuel>, IEnumerable<VehicleRefuelDisplayViewModel>>(vs);

            return Json(vm.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [UserActionAuthorization(Parameters.Action.MANAGE_VEHICLE_FUEL_REGISTER)]
        public ActionResult CreateVehicleRefuel([DataSourceRequest] DataSourceRequest request, VehicleRefuelEditViewModel entityViewModel)
        {

            try
            {
                if (entityViewModel != null)
                {
                    ModelState.Remove("VoucherReceiptNumber");

                    if (entityViewModel.IsBowserFuel == true)
                    {
                        ModelState.Remove("FuelDistributorId");
                    }
                    else
                    {
                        ModelState.Remove("BowserNumber");
                    }

                    if (entityViewModel.VehicleId > 0 || entityViewModel.VehicleId != null) {
                        var v = _vehicleManagementService.GetVehicleById((int)entityViewModel.VehicleId);
                        entityViewModel.RegistrationNumber = v.RegistrationNumber;
                    }                    

                    if (ModelState.IsValid)
                    {
                        var r = Mapper.Map<VehicleRefuelEditViewModel, VehicleRefuel>(entityViewModel);


                        r.CreatedBy = CurrentUser;
                        r.CreatedDate = DateTime.Now;

                        _vehicleFuelManagementService.Create(r);
                        _vehicleFuelManagementService.Save();
                        CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.Center, Parameters.Table.Center);
                        entityViewModel.Id = r.Id;

                        //update vehicle Current Mileage when refuelling
                        UpdateVehicleCurrentMileage(r);

                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }


            return Json(new[]{entityViewModel}.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [UserActionAuthorization(Parameters.Action.MANAGE_VEHICLE_FUEL_REGISTER)]
        public ActionResult EditVehicleRefuel([DataSourceRequest] DataSourceRequest request, VehicleRefuelEditViewModel entityViewModel)
        {
            try
            {

                if (entityViewModel != null)
                {
                    ModelState.Remove("VoucherReceiptNumber");                   

                    if (entityViewModel.IsBowserFuel == true)
                    {
                        ModelState.Remove("FuelDistributorId");
                    }
                    else
                    {
                        ModelState.Remove("BowserNumber");
                    }

                    if (entityViewModel.VehicleId > 0 || entityViewModel.VehicleId != null)
                    {
                        var v = _vehicleManagementService.GetVehicleById((int)entityViewModel.VehicleId);
                        entityViewModel.RegistrationNumber = v.RegistrationNumber;
                    }

                    if (ModelState.IsValid)
                    {
                        var r = Mapper.Map<VehicleRefuelEditViewModel, VehicleRefuel>(entityViewModel);

                        r.LastUpdatedBy = CurrentUser;
                        r.LastUpdatedDate = DateTime.Now;

                        _vehicleFuelManagementService.Update(r);
                        _vehicleFuelManagementService.Save();

                        CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.VehicleRefuel, Parameters.Table.VehicleRefuel);

                        //update vehicle Current Mileage when refuelling
                        UpdateVehicleCurrentMileage(r);

                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }


            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }
               
        [AcceptVerbs(HttpVerbs.Post)]
        [UserActionAuthorization(Parameters.Action.MANAGE_VEHICLE_FUEL_REGISTER)]
        public ActionResult DeleteVehicleRefuel([DataSourceRequest] DataSourceRequest request, VehicleRefuelEditViewModel entityViewModel)
        {
            try
            {


                if (entityViewModel != null)
                {
                    ModelState.Remove("VoucherReceiptNumber");

                    if (entityViewModel.IsBowserFuel == true)
                    {
                        ModelState.Remove("FuelDistributorId");
                    }
                    else
                    {
                        ModelState.Remove("BowserNumber");
                    }

                    if (ModelState.IsValid)
                    {
                        var r = Mapper.Map<VehicleRefuelEditViewModel, VehicleRefuel>(entityViewModel);
                        _vehicleFuelManagementService.Delete(r);
                        _vehicleFuelManagementService.Save();

                        CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.VehicleRefuel, Parameters.Table.VehicleRefuel);
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }


            return Json(new[] { entityViewModel }.ToDataSourceResult(request, ModelState));
        }
         

        #endregion

        #region 3.d. Form CRUD Post Related Actions      

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_VEHICLE_FUEL_REGISTER)]
        public ActionResult CreateVehicleRefuelMasterDetails(VehicleRefuelEditViewModel entityViewModel)
        {

            if (entityViewModel != null)
            {
                ViewBag.Center = _centerService.GetByCenterNumber((int)entityViewModel.CenterId).Name;
                PopulateSelectListDataSources();


                if (entityViewModel.FuelDistributorId != null)
                {
                    ViewBag.FuelDistributor = _contactDetailService.GetFuelDistributorContacts().Where(d => d.Id == entityViewModel.FuelDistributorId).FirstOrDefault().ContactName;

                }

                return View("VehicleRefuelsBatchCreateForm", entityViewModel);
            }
            else
            {
                return View("VehicleRefuelCreateMasterForm", entityViewModel);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_VEHICLE_FUEL_REGISTER)]
        public ActionResult UpdateVehicleRefuelDetails(VehicleRefuelEditViewModel entityViewModel)
        {
            try
            {
                ModelState.Remove("entityViewModel.VoucherReceiptNumber");
                ModelState.Remove("entityViewModel.FuelUsageCategory");

                if (entityViewModel.IsBowserFuel == true)
                {
                    ModelState.Remove("entityViewModel.FuelDistributorId");
                }
                else
                {
                    ModelState.Remove("entityViewModel.BowserNumber");
                }

                if (ModelState.IsValid && entityViewModel != null)
                {
                    if (entityViewModel.VehicleId > 0 || entityViewModel.VehicleId != null)
                    {
                        var v = _vehicleManagementService.GetVehicleById((int)entityViewModel.VehicleId);
                        entityViewModel.RegistrationNumber = v.RegistrationNumber;
                    }

                    var vs = Mapper.Map<VehicleRefuelEditViewModel, VehicleRefuel>(entityViewModel);

                    vs.LastUpdatedBy = CurrentUser;
                    vs.LastUpdatedDate = DateTime.Now;

                    _vehicleFuelManagementService.Update(vs);

                    _vehicleFuelManagementService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.VehicleRefuel, Parameters.Table.VehicleRefuel);

                    UpdateVehicleCurrentMileage(vs);

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
        [UserActionAuthorization(Parameters.Action.ACQUIT_FUEL_VOUCHER)]
        public ActionResult UpdateVehicleRefuelAcquitalDetails(VehicleRefuelEditViewModel entityViewModel)
        {
            try
            {
                if (entityViewModel != null)
                {
                    var r = _vehicleFuelManagementService.GetVehicleRefuelById(entityViewModel.Id);
                    r.IsVoucherAcquitted = entityViewModel.IsVoucherAcquitted;
                    r.VoucherReceiptNumber = entityViewModel.VoucherReceiptNumber;

                    r.LastUpdatedBy = CurrentUser;
                    r.LastUpdatedDate = DateTime.Now;

                    _vehicleFuelManagementService.Update(r);
                    _vehicleFuelManagementService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.VehicleRefuel, Parameters.Table.VehicleRefuel);
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
        [UserActionAuthorization(Parameters.Action.MANAGE_VEHICLE_FUEL_REGISTER)]
        public ActionResult DeleteVehicleRefuelDetails(int id)
        {
            try
            {
                if (id != 0)
                {

                    var vehicleRefuelToDelete = _vehicleFuelManagementService.GetVehicleRefuelById(id);
                    _vehicleFuelManagementService.Delete(vehicleRefuelToDelete);
                    _vehicleFuelManagementService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.VehicleRefuel, Parameters.Table.VehicleRefuel);


                    return Json(new { message = "Vehicle refuel record deleted.", isError = false });


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
        #region 3.e. Other Post Related Actions  
        [HttpPost]
        public ActionResult GetNewFuelVoucherNumber(int centerId)
        {
            try
            {
                if (_centerService.HasUnacquittedFuelVouchers(centerId)) //check if unacquited vouchers for this center exist               
                {                    
                    return Json(new { fuelVoucherNumber = "Unacquitted vouchers exist!", message = "Cannot generate any more fuel vouchers for this center until you acquit all vouchers.", isError = true });
                }
                else
                {
                    int nextVoucherNumber = _centerService.GetNextFuelVoucherNumberForMonth(centerId, DateTime.Today.ToString("MM"), DateTime.Today.ToString("yy"));

                    if (nextVoucherNumber == 0) //check if voucher capacity reached for the month
                    {
                        return Json(new { fuelVoucherNumber = "Capacity Reached!", message = "Cannot generate any more fuel vouchers for this center. Monthly fuel voucher capacity reached.", isError = true });
                    }
                    else
                    {
                      
                        var center = _centerService.GetByCenterNumber(centerId);

                        if (string.IsNullOrEmpty(center.CenterCode))
                        {
                            return Json(new { fuelVoucherNumber = "Center code is null!", message = "Please enter vehicle center code first before refuelling.", isError = true });
                        }
                        else
                        {

                            //all conditions met... generate new fuel voucher

                            string nextFuelVoucherNumStr = nextVoucherNumber.ToString().PadLeft(3, '0');

                            string cc = center.CenterCode.PadLeft(2, '0');
                            string nextFuelVoucherNumber = 'F' + cc + nextFuelVoucherNumStr + DateTime.Today.ToString("MM") + DateTime.Today.ToString("yy");

                            return Json(new { fuelVoucherNumber = nextFuelVoucherNumber, message = "New fuel voucher number successfully generated.", isError = false });

                        }


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

        private void UpdateVehicleCurrentMileage(VehicleRefuel r)
        {
            //update vehicle Current Mileage when refuelling
            if (r.VehicleId != null && r.Mileage != null)
            {
                var m = _vehicleManagementService.GetVehicleById((int)r.VehicleId);
                m.CurrentMileage = r.Mileage;

                m.LastUpdatedBy = CurrentUser;
                m.LastUpdatedDate = DateTime.Now;

                _vehicleManagementService.Update(m);
                _vehicleManagementService.Save();
                CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Vehicle, Parameters.Table.Vehicle);
            }
        }

        private void PopulateSelectListDataSources()
        {

            //Fuel Usage Categories
            var fuelUsageCategories = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.FuelUsageCategory)
                                            .Select(t => new ListOfValuesDisplayViewModel { Value = t.Id, Text = t.ParameterName });
            ViewBag.FuelUsageCategories = fuelUsageCategories;
            ViewBag.DefaultFuelUsageCategory = fuelUsageCategories.FirstOrDefault();

            //Vehicles
             var vehicles = _vehicleManagementService.GetFilterByCenterPermission(CurrentUser).Select(t => new ListOfValuesDisplayViewModel { Value = t.Id, Text = t.RegistrationNumber });
            ViewBag.Vehicles = vehicles;


            //Fuel Types
            var fuelTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Fuel).Select(t => new ListOfValuesDisplayViewModel { Value = t.Id, Text = t.ParameterName });
            ViewBag.FuelTypes = fuelTypes;


            //Drivers
            var drivers = _contactDetailService.GetDriverContacts().Select(t => new ListOfValuesDisplayViewModel { Value = t.Id, Text = t.ContactName });
            ViewBag.Drivers = drivers;

            //Fuel Tanks/Bower Numbers
            ViewBag.FuelTanks = _depotTankService.GetTankListByPermission(CurrentUser).Select(t => new { Value = t.BowserNumber, Text = t.BowserNumber });

            //Fuel Distributors
            ViewBag.FuelDistributors = _contactDetailService.GetFuelDistributorContacts().Select(t => new { Value = t.Id, Text = t.ContactName });

            //Centers
            ViewBag.Centers = _centerService.GetAllCenterWithPermission(CurrentUser).Select(t => new { Value = t.CenterNumber, Text = t.Name });
        }
        #endregion
    }
}
