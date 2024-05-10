using AutoMapper;
using FMS.Model;
using FMS.Service;
using FMS.Web.CustomActionFilters;
using FMS.Web.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FMS.Common;
using System;
using Microsoft.AspNet.Identity;
using FMS.Web.Identity;

namespace FMS.Web.Controllers
{
    [Authorize]
    [NoDirectAccess]
    public class VehicleAllocationController : BaseController
    {
        #region 1. Private Members
        private readonly IVehicleDisposalService _vehicleDisposalService;
        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly IVehicleAllocationService _vehicleAllocationService;
        private readonly IOperatorService _operatorService;
        private readonly IVehicleTransferService _vehicleTransferService;
        private readonly IContactDetailService _contactDetailService;
        private readonly IBusinessGroupService _businessGroupService;
        private readonly ICenterService _centerService;

        #endregion

        #region 2. Constructors
        public VehicleAllocationController(IVehicleDisposalService vehicleDisposalService
            ,IVehicleManagementService vehicleManagementService
            ,IOperatorService operatorService
            ,IVehicleAllocationService vehicleAllocationService
            ,IVehicleTransferService vehicleTransferService
            ,IContactDetailService contactDetailService
            ,IBusinessGroupService businessGroupService
            ,ICenterService centerService
            , IAuditingService auditingService
            , UserManager<IdentityUser, Guid> userManager
            , IVehicleServiceService vehicleServiceService          
            , IBusinessUnitService businessUnitService        
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
            _vehicleAllocationService = vehicleAllocationService;
            _vehicleDisposalService = vehicleDisposalService;
            _vehicleManagementService = vehicleManagementService;
            _operatorService = operatorService;
            _vehicleTransferService = vehicleTransferService;
            _contactDetailService = contactDetailService;
            _centerService = centerService;
            _businessGroupService = businessGroupService;
            
        }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions

        [HttpGet]        
        public ActionResult VehicleAllocationMain(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;

            return View();
        }

        [HttpGet]
        public ActionResult AllocateVehicleDetails(int vehicleId)
        {
            VehicleAllocationViewModel vm = new VehicleAllocationViewModel
            {
                Id = 0,
                StartDate = DateTime.Today
            };

            if (_vehicleAllocationService.IsVehicleExist(vehicleId)) 
            {
                var va = _vehicleAllocationService.GetbyVehicleId(vehicleId);                

                vm = Mapper.Map<VehicleAllocation, VehicleAllocationViewModel>(va);

            }

            vm.VehicleDisplayInfoViewModel = MapVehicleDisplayInfo(vehicleId);

            ViewBag.Operators = _contactDetailService.GetEmployeeContacts(Parameters.SystemParameterCode.Employee, null).Select(t => new { Value = t.Id, Text = t.ContactName }).OrderBy(c=>c.Text);

            return View(vm);
        }

        [HttpGet]
        public ActionResult TransferVehicleDetails(int vehicleId)
        {
            var v = _vehicleManagementService.GetVehicleById(vehicleId);

            VehicleTransferViewModel vm = new VehicleTransferViewModel { Id = 0
                , Date = DateTime.Today               
            };

            vm.VehicleDisplayInfoViewModel = MapVehicleDisplayInfo(vehicleId);

            ViewBag.BusinessGroups = _businessGroupService.GetAll().Select(t => new { Value = t.GroupNumber, Text = t.GroupName }).OrderBy(c => c.Text);

            ViewBag.Centers = _centerService.GetAllCenterWithPermission(CurrentUser).Select(t => new { Value = t.CenterNumber, Text = t.Name }).OrderBy(c => c.Text);

            return View(vm);
        }        

        #endregion

        #region 3.b. Get List of Values Related Actions

        #endregion

        #region 3.c. Grid Related Actions


        public ActionResult Get_Unallocated_Vehicles([DataSourceRequest] DataSourceRequest request, int vehicleId)
        {
            var vehicles = _vehicleManagementService.GetUnallocatedVehicles(CurrentUser, vehicleId);

            var viewModelVehicleList = Mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleDisplayViewModel>>(vehicles);

            return Json(viewModelVehicleList.ToDataSourceResult(request));
        }

        public ActionResult Get_Allocated_Vehicles([DataSourceRequest] DataSourceRequest request, int vehicleId)
        {

            var va = _vehicleAllocationService.GetFilterByCenterPermission(CurrentUser, vehicleId);
            var vm = Mapper.Map<IEnumerable<VehicleAllocation>, IEnumerable<VehicleAllocationViewModel>>(va);

            return Json(vm.ToDataSourceResult(request));
        }


        public ActionResult Get_Allocation_History([DataSourceRequest] DataSourceRequest request, int vehicleId)
        {

            var va = _vehicleAllocationService.GetHistory(CurrentUser, vehicleId);

            var vm = Mapper.Map<IEnumerable<VehicleAllocation>, IEnumerable<VehicleAllocationViewModel>>(va);    

            return Json(vm.ToDataSourceResult(request));
        }
        
        public ActionResult Get_Transfer_History([DataSourceRequest] DataSourceRequest request, int vehicleId)
        {
            var va = _vehicleTransferService.GetfilterbyCenter(CurrentUser, vehicleId);

            var vm = Mapper.Map<IEnumerable<VehicleTransfer>, IEnumerable<VehicleTransferViewModel>>(va);

            return Json(vm.ToDataSourceResult(request));
        }

        #endregion

        #region 3.d. Form CRUD Post Related Actions

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AllocateVehicle(VehicleAllocationViewModel entityViewModel)
        {
            try
            {
                if (ModelState.IsValid && entityViewModel != null)
                {
                    var va = Mapper.Map<VehicleAllocationViewModel, VehicleAllocation>(entityViewModel);
                    _vehicleAllocationService.Create(va);
                    _vehicleAllocationService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.VehicleAllocation, Parameters.Table.VehicleAllocation);

                    var v = _vehicleManagementService.GetVehicleById((int)va.VehicleId);
                    v.IsAllocated = true;
                    _vehicleManagementService.Update(v);
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
        public ActionResult EndVehicleAllocation(VehicleAllocationViewModel entityViewModel)
        {
            try
            {
                if (ModelState.IsValid && entityViewModel != null)
                {
                    var va = Mapper.Map<VehicleAllocationViewModel, VehicleAllocation>(entityViewModel);

                    va.EndDate = entityViewModel.StartDate;  //vm.StartDate is the "Allocated Date"

                    _vehicleAllocationService.Update(va);
                    _vehicleAllocationService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.VehicleAllocation, Parameters.Table.VehicleAllocation);

                    var v = _vehicleManagementService.GetVehicleById((int)va.VehicleId);

                    v.IsAllocated = false;

                    _vehicleManagementService.Update(v);
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
        public ActionResult TransferVehicle(VehicleTransferViewModel entityViewModel)
        {
            try
            {
                if (ModelState.IsValid && entityViewModel != null)
                {
                    var vt = Mapper.Map<VehicleTransferViewModel, VehicleTransfer>(entityViewModel);
                    
                    _vehicleTransferService.Create(vt);
                    _vehicleTransferService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.VehicleAllocation, Parameters.Table.VehicleAllocation);

                    var v = _vehicleManagementService.GetVehicleById((int)vt.VehicleId);

                    v.CenterId = vt.CenterId;
                    v.BusinessGroupId = vt.BusinessGroupId;

                    _vehicleManagementService.Update(v);
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

        #endregion

        #region 3.e. Other Post Relation Actions  

        #endregion
        #endregion

        #region 4. Private Methods

       



        #endregion
    }
}