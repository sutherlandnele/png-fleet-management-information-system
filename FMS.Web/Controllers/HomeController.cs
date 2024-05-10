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
using System.Collections;

namespace FMS.Web.Controllers
{

    [Authorize]
    [NoDirectAccess]
    public class HomeController : BaseController
    {
        #region 1. Private Members

        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly ICenterService _centerService;
        private readonly ISystemParameterService _systemParameterService;
        private readonly ISystemParameterCodeService _systemParameterCodeService;
        private readonly IContactDetailService _contactDetailService;
        private readonly IVehicleServiceService _vehicleServiceService;
        private readonly IVehicleFuelManagementService _vehicleFuelManagementService;
        private readonly IDepotTankService _depotTankService;
        private readonly IDepotRefuelService _depotRefuelService;
        private readonly IDepotDailyMeasurementService _depotDailyMeasurementService;
        private readonly IRegionService _regionService;
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IBusinessGroupService _businessGroupService;
        private readonly IDashboardService _dashboardService;
        private readonly ICenterSecurityService _centerSecurityService;
        private readonly IAppIssueService _appIssueService;



        #endregion

        #region 2. Constructors
        public HomeController(IVehicleManagementService vehicleManagementService
            ,ICenterSecurityService centerSecurityService
            , IVehicleFuelManagementService vehicleFuelManagementService
            , IDashboardService dashboardService
            , IDepotDailyMeasurementService depotDailyMeasurementService
            , IVehicleTypeService vehicleTypeService
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
            , systemParameterCodeService
            , systemParameterService
            , appIssueService
           )
        {
         
            _centerSecurityService = centerSecurityService;
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
            _vehicleTypeService = vehicleTypeService;
            _businessUnitService = businessUnitService;
            _businessGroupService = businessGroupService;
            _dashboardService = dashboardService;
            _systemParameterCodeService = systemParameterCodeService;
        }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions      
        [HttpGet] 
        public ActionResult Index()
        {
            ViewBag.UserHasCenterAccess = _centerSecurityService.UserExists(CurrentUser);
            return View();

        }
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult VehicleStatusCount(List<int> centerIds, bool isInitialLoad)
        {
            var v = new List<VehicleStatusBarChartViewModel>();
            IList objList;

            if (centerIds == null && isInitialLoad == false)
            {
                objList = (IList)_dashboardService.GetVehicleStatus(GetCenterIds().ToList());

                var dList = ((IEnumerable<dynamic>)objList).ToList();

                foreach (var d in dList)
                {

                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var json = serializer.Serialize(d);
                    var c = serializer.Deserialize<VehicleStatusBarChartViewModel>(json);

                    if (c is VehicleStatusBarChartViewModel)
                    {
                        v.Add(new VehicleStatusBarChartViewModel { Count = 0, Status = c.Status });
                    }
                }
            }
            else
            {
                

                if (isInitialLoad)
                {
                    objList = (IList)_dashboardService.GetVehicleStatus(GetCenterIds().ToList());
                }
                else
                {
                    objList = (IList)_dashboardService.GetVehicleStatus(centerIds);
                }

                var dList = ((IEnumerable<dynamic>)objList).ToList();              

                foreach (var d in dList)
                {

                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var json = serializer.Serialize(d);
                    var c = serializer.Deserialize<VehicleStatusBarChartViewModel>(json);

                    if (c is VehicleStatusBarChartViewModel)
                    {
                        v.Add(c);
                    }
                }
            }

            
            return Json(v, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FuelUsageByDate(List<int> centerIds, bool isInitialLoad)
        {
            var v = new List<FuelUsageBarChartViewModel>();

            IList objList;

            if (centerIds == null && isInitialLoad == false)
            {
                objList = (IList)_dashboardService.GetFuelUsage(GetCenterIds().ToList());

                var dList = ((IEnumerable<dynamic>)objList).ToList();

                foreach (var d in dList)
                {

                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var json = serializer.Serialize(d);
                    var c = serializer.Deserialize<FuelUsageBarChartViewModel>(json);

                    if (c is FuelUsageBarChartViewModel)
                    {
                        v.Add(new FuelUsageBarChartViewModel { Litres = 0, Date = c.Date});
                    }
                }
            }
            else
            {


                if (isInitialLoad)
                {
                    objList = (IList)_dashboardService.GetFuelUsage(GetCenterIds().ToList());
                }
                else
                {
                    objList = (IList)_dashboardService.GetFuelUsage(centerIds);
                }

                var dList = ((IEnumerable<dynamic>)objList).ToList();

                foreach (var d in dList)
                {

                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var json = serializer.Serialize(d);
                    var c = serializer.Deserialize<FuelUsageBarChartViewModel>(json);

                    if (c is FuelUsageBarChartViewModel)
                    {
                        v.Add(c);
                    }
                }
            }


            return Json(v, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUserCenters(int? id)
        {
          
                var userCenters = from c in GetUserCenterSelectionTreeViewData()
                                  where (id.HasValue ? c.ParentId == id : c.ParentId == null)
                                  select new
                                  {
                                      c.id, /* Important to have the name as "id" and not "Id" or any other name */
                                      c.Name,
                                      c.hasChildren
                                  };



            return Json(userCenters, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 3.b. Get List of Values Related Actions

        #endregion

        #region 3.c. Grid Related Actions


        #endregion

        #region 3.d. Form CRUD Post Related Actions          

        #endregion

        #region 3.e. Other Post Related Actions  
        [HttpPost]
        public ActionResult GetChartData(List<int> selectedUserCenters)
        {
            try
            {
                return Json(new { message = "Success.", isError = false });
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
        private IEnumerable<TreeViewBaseDisplayViewModel> GetUserCenterSelectionTreeViewData()
        {

            var rootNode = new TreeViewBaseDisplayViewModel { id = 0, ParentId = null , Name = "Select All", hasChildren=true};

            var userCenterNodes = new List<TreeViewBaseDisplayViewModel>{rootNode};            

            foreach(var c in _centerService.GetAllCenterWithPermission(CurrentUser))
            {
                userCenterNodes.Add(new TreeViewBaseDisplayViewModel { id = c.CenterNumber, Name = c.Name, ParentId = 0, hasChildren = false });
            }

            return userCenterNodes;
            

        }

        private IEnumerable<int> GetCenterIds()
        {
            return _centerService.GetAllCenterWithPermission(CurrentUser).Select(m => m.CenterNumber);
        }

        
        #endregion


    }


}