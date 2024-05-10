using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Common
{
    public static class Parameters
    {
        #region Enum Functions

        #region General Application Management Enums

        public enum AppIssueType
        {
            PasswordResetRequest = 1268,
            ReportApplicationError = 1269,
            ApplicationAccessRequest = 1270,
            UnauthorizedAccessRequest = 1271,
            ApplicationUsageTrainingRequest = 1272,
            ApplicationEnhancementRequest = 1273,
            ApplicationPermissionRequest = 1275
        }

        public enum SystemParameterType
        {
            Fuel = 1,
            Acquisition = 2,
            Status = 3,
            Condition = 4,
            ScheduleServiceType = 5,
            Transmission = 6,
            ServiceType = 7,
            IncidentType = 8,
            NotificationType = 9,
            WhenAppear = 10,
            Severity = 11,
            Gender = 12,
            ContactType = 13,
            IncidentStatus = 14,
            FuelUsageCategory = 15,
            Make = 16,
            AlertType = 17,
            ComplianceType = 18,
            VehicleOperationStatus = 19,
            VehicleUsageStatus = 24,
            VehicleFinancialStatus = 25,
            SupplierType = 26,
            AppIssueType = 36
        }
        public enum SystemParameterCode
        {
            Supplier = 39, //contact type
            Employee = 43, //contact type
            Mechanics = 237, //contact type
            Driver = 246, //contact type
            Fuel_Distributors = 228, //supplier type
            Motor_Dealers = 229, //supplier type
            Workshops = 230, //supplier type
            Registration = 80, //Complicance Type
            SafetySticker = 81, //Complicance Type
            ThirdPartyInsurance = 82 //Complicance Type

        }
        public enum CommandType
        {
            View,
            Edit,
            Delete,
            Dispose
        }
        public enum ComplianceType
        {
            Registration = 80,
            SafetySticker = 81
        }
        public enum ContactType
        {
            Supplier = 39,
            Employee = 43,
            Mechanic = 237,
            Driver = 246
        }
        public enum ReportType
        {
            //vehicle registry reports
            VehicleInformationReport = 100,
            VehicleAcquisitionReport = 101,
            DisposedVehiclesListing = 102,

            //vehicle service reports
            ServiceDetailsReport = 200,
            ServiceMonthlySummary = 201,
            VehicleScheduleServiceReport = 202,

            //vehicle allocation reports
            AllocatedVehiclesReport = 300,
            UnAllocatedVehiclesReport = 301,

            //management reports
            VehicleActivitiesHistory = 400,

            //compliance reports
            RegistrationExpiry = 500,
            SafetyStickerExpiry = 501,
            VehicleScheduleServiceDueNotice = 502,
            DriverLicenseExpiry = 503,
            ComplianceMonthlySummaryReport = 504,

            //incident reports
            IncidentStatusReport = 600,
            DriverInformationReport = 601,

            //fuel management reports
            BowserDailyFuelUsageReport = 700,
            BowserFuelStatusReport = 701,
            MonthlyFuelConsumption = 702

            //organization reports

            //admin reports
        }
        public enum VehicleFinancialStatus
        {
            Disposed = 227
        }
        public enum VehicleStatus
        {
            ActiveUnallocated = 15,
            ActiveAllocated = 16,
            Inservice = 17,
            Disposed = 18,
            BoardOfSurvey = 175,
            DueForBOS = 184
        }
        public enum VehicleOperationalStatus
        {
            Operational = 221,
            NotOperational = 222,
            Stolen = 252,
            Sold = 255,
            Grounded = 256,
            Accident = 257,
            CanibalisedForSpareParts = 258
        }
        public enum VehicleConditionStatus
        {
            Running = 19,
            NeedsService = 20,
            BeyondRepair = 21,
            WrittenOff = 254,
            Sold = 259
        }
        public enum VehicleService
        {
            Schedule_Maintenance = 46,
            Incident_Maintenance = 48,
            Other_maintenance = 49
        }
        public enum FileOperation
        {
            Add_File,
            Remove_File
        }
        #endregion

        #region Audit Trail Management
        public enum SubSystem
        {
            Operator,
            Vehicle,
            DeportTank,
            Role,
            vehicleDisposal,
            VehicleService,
            VehicleServiceSchedule,
            DepotRefuel,
            DepotDailyMeasurement,
            IncidentStatus,
            FuelManagement,
            VehicleRefuel,
            Notification,
            EmailTemplate,
            VehicleAllocation,
            BusinessGroup,
            BusinessUnit,
            Regional,
            Center,
            FuelVoucher,
            ContactDetail,
            Compliance,
            SystemParameters

        }
        public enum Table
        {
            DepotRefuel,
            DepotTank,
            BusinessGroupSecurity,
            Functions,
            Incident,
            Operator,
            RoleFunctions,
            Service,
            SqlAudit,
            SystemParameterCode,
            SystemParameters,
            Vehicle,
            UserContact,
            VehicleAllocation,
            VehicleDisposal,
            VehicleRefuel,
            aspnet_Roles,
            ScheduleService,
            DepotDailyMeasurement,
            Notification,
            EmailTemplate,
            BusinessGroup,
            BusinessUnit,
            Regional,
            Model,
            Make,
            VehicleType,
            VehicleTransfer,
            Center,
            FuelVoucher,
            Compliance,
            CenterSecurity,
            ContactDetail
        }
        public enum DatabaseAction
        {
            Insert,
            Update,
            Delete
        }
        #endregion

        #region App Permission Management
        public enum RoleAction
        {
            Settingupnewvehicle = 1,
            UpdatingVehicleRegistry = 2,
            SetVehicleExpiryDates = 3,
            DisposeVehicle = 4,
            ScheduleVehiclforService = 5,
            RecordVehicleService = 6,
            RecordFuelDockets = 7,
            RecordDailyBowserDipReadings = 8,
            RecordVehicleIncident = 9,
            AllocateandtransferVehicles = 10,
            ViewVehicleRegistryreports = 11,
            ViewVehicleServiceReports = 12,
            ViewVehicleComplianceReports = 13,
            ViewVehicleAllocationReports = 14,
            ViewSystemParametersreports = 15,
            ViewAdministratorReports = 16
        }
        public enum MenuName
        {
            VEHICLE_MANAGEMENT = 1,
            ALLOCATION_MANAGEMENT = 2,
            SERVICE_MANAGEMENT = 3,
            FUEL_MANAGEMENT = 4,
            INCIDENT_MANAGEMENT = 5,
            COMPLIANCE_MANAGEMENT = 6,
            ORGANIZATION = 7,
            PARAMETERS = 8,
            SECURITY = 9,
            REPORTS = 10
        }
        public enum Interface
        {
            FUEL_REGISTER = 1,
            BOWSER_DIP_READINGS = 2,
            BOWSER_REFUEL = 3,
            BOWSER_STATUS_SETUP = 4,
            MANAGE_NOTIFICATION = 5,
            COMPLIANCE_DASHBOARD = 6,
            CONTACTS = 7,
            DRIVERS = 8,
            BUSINESS_UNITS = 9,
            BUSINESS_GROUPS = 10,
            REGIONS = 11,
            CENTRES = 12,
            CLIENT_INFORMATION = 13,
            USER_DEFINE_CODES = 14,
            VEHICLE_TYPES = 15,
            VEHICLE_MODEL = 16,
            MANAGE_USERS = 17,
            CENTRE_SECURITY = 18,
            AUDIT_TRAIL = 19,
            REGISTRY_REPORTS = 20,
            SERVICE_REPORTS = 21,
            FUEL_REPORTS = 22,
            ALLOCATION_REPORTS = 23,
            MANAGEMENT_REPORTS = 24,
            COMPLIANCE_REPORTS = 25,
            INCIDENT_REPORTS = 26,
            ADMIN_REPORTS = 27,
            VEHICLE_REGISTER = 28,
            ALLOCATION = 29,
            SERVICE = 30,
            INCIDENTS = 31,
            ROLE = 32,
            FUEL_VOUCHER = 33,
            SCHEDULE_SERVICE = 34,
            COMPLIANCE_ENTRIES = 35,
            ALERTS = 36,
            PERMISSION = 37,
            VIEW_DISPOSED_VEHICLES = 38,
            MECHANICS = 39,
            MANAGE_SAFETY_STICKER = 40,
            ORGANIZATION_REPORT = 41,   
            VIEW_BOS_VEHICLES = 42,

            ALL_ALLOWED = 0

        }
        public enum Action
        {
            MANAGE_VEHICLE_ALLOCATION = 1,
            UPDATE_VEHICLE_REGISTRY = 2,
            DISPOSE_VEHICLE = 3,
            SETUP_NEW_VEHICLE = 4,
            SET_VEHICLE_EXPIRY_DATES = 5,
            TRANSFER_VEHICLE = 6,
            MANAGE_SERVICE_OF_VEHICLES = 10,
            VIEW_SERVICE_OF_VEHICLES = 11,
            MANAGE_VEHICLE_FUEL_REGISTER = 12,
            VIEW_VEHICLE_FUEL_REGISTER = 13,
            MANAGE_BOWSER_DAILY_DIP_READINGS = 14,
            VIEW_BOWSER_DAILY_DIP_READINGS = 15,
            MANAGE_BOWSER_REFUEL = 16,
            VIEW_BOWSER_REFUEL = 17,
            MANAGE_BOWSER_STATUS_SETUP = 18,
            VIEW_BOWSER_STATUS_SETUP = 19,
            MANAGE_INCIDENTS = 20,
            VIEW_INCIDENTS = 21,
            MANAGE_NOTIFICATIONS = 22,
            VIEW_NOTIFICATIONS = 23,
            MANAGE_COMPLIANCE_DASHBOARD = 24,
            VIEW_COMPLIANCE_DASHBOARD = 25,
            MANAGE_CONTACTS = 26,
            SEARCH_CONTACTS = 27,
            VIEW_CONTACTS = 28,
            MANAGE_DRIVERS = 29,
            SEARCH_DRIVERS = 30,
            VIEW_DRIVERS = 31,
            MANAGE_BUSINESS_UNITS = 32,
            SEARCH_BUSINESS_UNITS = 33,
            VIEW_BUSINESS_UNITS = 34,
            MANAGE_BUSINESS_GROUPS = 35,
            SEARCH_BUSINESS_GROUPS = 36,
            VIEW_BUSINESS_GROUPS = 37,
            MANAGE_REGIONS = 38,
            SEARCH_REGIONS = 39,
            VIEW_REGIONS = 40,
            MANAGE_CENTRES = 41,
            SEARCH_CENTRES = 42,
            VIEW_CENTRES = 43,
            MANAGE_CLIENT_INFORMATION = 44,
            MANAGE_USER_DEFINED_CODES = 47,
            VIEW_USER_DEFINE_CODES = 48,
            MANAGE_VEHICLE_TYPES = 49,
            VIEW_VEHICLE_TYPES = 50,
            SEARCH_VEHICLE_TYPES = 51,
            MANAGE_VEHICLE_MODEL = 52,
            VIEW_VEHICLE_MODEL = 53,
            SEARCH_VEHICLE_MODEL = 54,
            SCHEDULE_VEHICLE_FOR_SERVICE = 55,            
            MANAGE_USER_INFORMATION = 57,
            VIEW_USER_INFORMATION = 58,
            MANAGE_CENTRE_SECURITY = 59,
            VIEW_CENTRE_SECURITY = 60,
            MANAGE_AUDIT = 61,
            VIEW_AUDIT = 62,
            SEARCH_AUDIT = 63,
            RUN_VEHICLE_INFORMATION_REPORT = 64,
            RUN_VEHICLE_ACQUISITION_REPORT = 65,
            RUN_DISPOSED_VEHICLE_LISTING = 66,
            RUN_SERVICE_DETAILS_REPORT = 67,
            RUN_VEHICLE_SCHEDULE_SERVICE = 68,
            RUN_BOWSER_DAILY_USAGE = 69,
            RUN_BOWSER_FUEL_STATUS = 70,
            RUN_MONTHLY_VEHICLE_FUEL_CONSUMPTION = 71,
            RUN_ALLOCATED_VEHICLE_REPORT = 72,
            RUN_UNALLOCATED_VEHICLE_REPORT = 73,
            RUN_VEHICLE_HISTORY_DETAIL_REPORT = 74,
            RUN_REGISTRATION_EXPIRY = 75,
            RUN_SAFETY_STICKER_EXPIRY = 76,
            RUN_SCHEDULE_SERVICE_DUE_NOTICE = 77,
            RUN_DRIVER_SERVICE_EXPIRY_NOTICE = 78,
            RUN_INCIDENT_STATUS = 79,
            RUN_USER_REPORT = 80,
            RUN_CENTRE_REPORT = 81,
            RUN_BUSINESS_GROUP_REPORT = 82,
            RUN_VEHICLE_TYPE_REPORT = 83,
            MANAGE_ROLE = 84,
            RUN_COMPLIANCE_MONTHLY_SUMMARY = 85,
            RUN_SERVICE_MONTHLY_SUMMARY = 86,
            ACQUIT_FUEL_VOUCHER = 88,
            MANAGE_SCHEDULE_SERVICE = 89,
            VIEW_SCHEDULE_SERVICE = 90,
            MANAGE_COMPLICANCE_ENTRIES = 91,
            VIEW_COMPLICANCE_ENTRIES = 92,
            MANAGE_ALERTS = 93,
            VIEW_ALERTS = 94,
            MANAGE_PERMISSION = 95,
            VIEW_DISPOSED_VEHICLES = 96,
            MANAGE_MECHANICS = 97,
            SEARCH_MECHANICS = 98,
            VIEW_MECHANICS = 99,
            UPDATE_SAFETY_STICKEY = 100,
            RUN_DRIVER_INFORMATION_REPORT = 101,
            VIEW_BOS_VEHICLES = 102,
            VIEW_VEHICLES = 103,
            ALL_ALLOWED = 0
        }
        public enum ViewMode
        {
            Edit = 0,
            View = 1,
            Add = 2
        }

        public enum RolePermissionType
        {
            Menu,
            Interface,
            Action
        }

        #endregion

        #endregion

        #region Inner Static Classes
        public static class AppConstant
        {
            //use static readonly instead of const to allow for the values to be read at runtime. const is only read at compile time
            public static readonly string BOSRPT_PATH = "~/UploadedFiles/BOSReports";
            public static readonly string BOSRPT_DLPATH = "UploadedFiles/BOSReports/";
            public static readonly string CODRPT_PATH = "~/UploadedFiles/CODReports";
            public static readonly string CODRPT_DLPATH = "UploadedFiles/CODReports/";
            public static readonly string INCRPT_PATH = "~/UploadedFiles/IncidentReports";
            public static readonly string INCRPT_DLPATH = "UploadedFiles/IncidentReports/";

            public static readonly string ADMIN_ROLE_NAME = "Administrator";

        }

        #endregion
    }
}
