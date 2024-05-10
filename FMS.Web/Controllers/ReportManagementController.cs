using System;
using System.Linq;
using System.Web.Mvc;
using FMS.Service;
using FMS.Web.ViewModels;
using Kendo.Mvc.Extensions;
using FMS.Web.CustomActionFilters;
using FMS.Common;
using FMS.Web.Identity;
using Microsoft.AspNet.Identity;


namespace FMS.Web.Controllers
{

    [Authorize]
    [NoDirectAccess]
    public class ReportManagementController : BaseController
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
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IBusinessGroupService _businessGroupService;



        #endregion

        #region 2. Constructors
        public ReportManagementController(IVehicleManagementService vehicleManagementService
            , IVehicleFuelManagementService vehicleFuelManagementService
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
        }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.REGISTRY_REPORTS)]
        public ActionResult VehicleRegistryReports()
        {
            var v = new VehicleRegistryReportParameterViewModel();

            PopulateSelectListDataSources();

            return View(v);
        }
        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.FUEL_REPORTS)]
        public ActionResult FuelManagementReports()
        {
            var v = new FuelManagementReportParameterViewModel();

            PopulateSelectListDataSources();

            return View(v);
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.COMPLIANCE_REPORTS)]
        public ActionResult ComplianceReports()
        {
            var v = new ComplianceReportParameterViewModel();

            PopulateSelectListDataSources();

            return View(v);
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.SERVICE_REPORTS)]
        public ActionResult VehicleServiceReports()
        {
            var v = new VehicleServiceReportParameterViewModel();

            PopulateSelectListDataSources();

            return View(v);
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.ALLOCATION_REPORTS)]
        public ActionResult VehicleAllocationReports()
        {
            var v = new VehicleAllocationReportParameterViewModel();

            return View(v);
        }


        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.ORGANIZATION_REPORT)]
        public ActionResult OrganisationReports()
        {
            var v = new OrganisationReportParameterViewModel();

            return View(v);
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.MANAGEMENT_REPORTS)]
        public ActionResult ManagementReports()
        {
            var v = new ManagementReportParameterViewModel();

            PopulateSelectListDataSources();

            return View(v);
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.INCIDENT_REPORTS)]
        public ActionResult VehicleIncidentReports()
        {
            var v = new VehicleIncidentReportParameterViewModel();

            PopulateSelectListDataSources();

            return View(v);
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
        [ValidateAntiForgeryToken]
        [UserInterfaceAuthorization(Parameters.Interface.INCIDENT_REPORTS)]
        public ActionResult ExecuteVehicleIncidentReport(VehicleIncidentReportParameterViewModel parameters)
        {
            if (ModelState.IsValid)
            {
                return View("ReportViewer", parameters);
            }
            else
            {
                return View("VehicleIncidentReports", parameters);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserInterfaceAuthorization(Parameters.Interface.ALLOCATION_REPORTS)]
        public ActionResult ExecuteVehicleAllocationReport(VehicleAllocationReportParameterViewModel parameters)
        {
            if (ModelState.IsValid)
            {
                return View("ReportViewer", parameters);
            }
            else
            {
                return View("VehicleAllocationReports", parameters);
            }

        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserInterfaceAuthorization(Parameters.Interface.ORGANIZATION_REPORT)]
        public ActionResult ExecuteOrganisationReport(OrganisationReportParameterViewModel parameters)
        {
            if (ModelState.IsValid)
            {
                return View("ReportViewer", parameters);
            }
            else
            {
                return View("OrganisationReports", parameters);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserInterfaceAuthorization(Parameters.Interface.REGISTRY_REPORTS)]
        public ActionResult ExecuteRegistryReport(VehicleRegistryReportParameterViewModel parameters)
        {
            if (ModelState.IsValid)
            {
                return View("ReportViewer", parameters);
            }
            else
            {
                return View("VehicleRegistryReports", parameters);
            }           
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserInterfaceAuthorization(Parameters.Interface.FUEL_REPORTS)]
        public ActionResult ExecuteFuelManagementReport(FuelManagementReportParameterViewModel parameters)
        {
            if (ModelState.IsValid)
            {
                return View("ReportViewer", parameters);
            }
            else
            {
                return View("FuelManagementReports", parameters);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserInterfaceAuthorization(Parameters.Interface.COMPLIANCE_REPORTS)]
        public ActionResult ExecuteComplianceReport(ComplianceReportParameterViewModel parameters)
        {
            if (ModelState.IsValid)
            {
                return View("ReportViewer", parameters);
            }
            else
            {
                return View("ComplianceReports", parameters);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserInterfaceAuthorization(Parameters.Interface.SERVICE_REPORTS)]
        public ActionResult ExecuteVehicleServiceReport(VehicleServiceReportParameterViewModel parameters)
        {
            if (ModelState.IsValid)
            {
                return View("ReportViewer", parameters);
            }
            else
            {
                return View("VehicleServiceReports", parameters);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserInterfaceAuthorization(Parameters.Interface.MANAGEMENT_REPORTS)]
        public ActionResult ExecuteManagementReport(ManagementReportParameterViewModel parameters)
        {
            if (ModelState.IsValid)
            {
                return View("ReportViewer", parameters);
            }
            else
            {
                return View("ManagementReports", parameters);
            }
        }


        #endregion

        #endregion

        #region 4. Private Methods
        private void PopulateSelectListDataSources()
        {
            ViewBag.ServiceProviders = _contactDetailService.GetSupplierContacts().Select(t => new { Value = t.ContactName, Text = t.ContactName });
            ViewBag.ServiceTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.ServiceType).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.IncidentTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.IncidentType).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.IncidentStatuses = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.IncidentStatus).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.FuelUsageGroups = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.FuelUsageCategory).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.Centers = _centerService.GetAllCenterWithPermission(CurrentUser).Select(t => new { Value = t.Name, Text = t.Name });
            ViewBag.Vehicles = _vehicleManagementService.GetFilterByCenterPermission(CurrentUser).Select(t => new { Value = t.RegistrationNumber, Text = t.RegistrationNumber });
            ViewBag.BusinessUnits = _businessUnitService.GetAll().Select(t => new { Value = t.Name, Text = t.Name });
            ViewBag.BusinessGroups = _businessGroupService.GetAll().Select(t => new { Value = t.GroupName, Text = t.GroupName });
            ViewBag.VehicleTypes = _vehicleTypeService.GetAll().Select(t => new { Value = t.Type, Text = t.Type });
            ViewBag.AcquisitionTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Acquisition).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.Makes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Make).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.FuelTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Fuel).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.Transmissions = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Transmission).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.OperationStatuses = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.VehicleOperationStatus).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.Conditions = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Condition).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.UsageStatuses = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.VehicleUsageStatus).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.FinancialStatuses = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.VehicleFinancialStatus).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
            ViewBag.Statuses = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Status).Select(t => new { Value = t.ParameterName, Text = t.ParameterName });
        }
        #endregion


    }
}
