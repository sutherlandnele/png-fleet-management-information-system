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
    public class OrganisationManagementController : BaseController
    {
        #region 1. Private Members

        private readonly ICenterService _centerService;
        private readonly IRegionService _regionService;
        private readonly IContactDetailService _contactDetailService;
        private readonly ISystemParameterService _systemParameterService;
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IBusinessGroupService _businessGroupService;
        private readonly IClientInformationService _clientInformationService;


        #endregion

        #region 2. Constructors
        public OrganisationManagementController(IRegionService regionService
        ,IVehicleManagementService vehicleManagementService
        ,IAuditingService auditingService
        ,IClientInformationService clientInformationService
        ,IContactDetailService contactDetailService
        ,UserManager<IdentityUser, Guid> userManager       
        ,IVehicleServiceService vehicleServiceService
        ,ICenterService centerService
        ,IBusinessUnitService businessUnitService
        ,IBusinessGroupService businessGroupService
        ,IModelService modelService
        ,IDepotTankService depotTankService
        ,IAppRoleInterfaceAccessService appRoleInterfaceAccessService
        ,IAppRoleMenuAccessService appRoleMenuAccessService
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
        }
        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions

        #region 3.a.1 Contact Details
        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.CONTACTS)]
        public ActionResult Contacts(string message, bool isError, int contactType)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;

            PopulateSelectListDataSources();

            switch (contactType)
            {
                case (int)Parameters.ContactType.Employee:
                   
                    ViewBag.ListTitle = "Staff Contacts";
                    ViewBag.ContactNameTitle = "Employee Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Employee;

                    break;
                case (int)Parameters.ContactType.Supplier:
                   
                    ViewBag.ListTitle = "Supplier Contacts";
                    ViewBag.ContactNameTitle = "Supplier Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Supplier;
                    break;
                case (int)Parameters.ContactType.Mechanic:
                    
                    ViewBag.ListTitle = "Mechanic Contacts";
                    ViewBag.ContactNameTitle = "Mechanic Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Mechanic;
                    break;
                default:                   
                    break;
            }


            return View();
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_CONTACTS)]
        public ActionResult EditContactDetails(int id, int contactType)
        {
            var m = _contactDetailService.GetContactDetailById(id);

            var v = Mapper.Map<ContactDetail, ContactDetailEditViewModel>(m);

            switch (contactType)
            {
                case (int)Parameters.ContactType.Employee:

                    ViewBag.FormTitle = "Staff Contacts Details";
                    ViewBag.ContactNameTitle = "Employee Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Employee;
                    break;
                case (int)Parameters.ContactType.Supplier:

                    ViewBag.FormTitle = "Supplier Contacts Details";
                    ViewBag.ContactNameTitle = "Supplier Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Supplier;
                    break;
                case (int)Parameters.ContactType.Mechanic:

                    ViewBag.FormTitle = "Mechanic Contacts Details";
                    ViewBag.ContactNameTitle = "Mechanic Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Mechanic;
                    break;
                default:

                    break;
            }

            PopulateSelectListDataSources();

            return View("ContactDetailsForm", v);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_CONTACTS)]
        public ActionResult CreateContactDetails(int contactType)
        {
            ContactDetailEditViewModel v;

            switch (contactType)
            {
                case (int)Parameters.ContactType.Employee:
                    v = new ContactDetailEditViewModel { Id = 0, Contacttype = (int)Parameters.ContactType.Employee };
                    ViewBag.FormTitle = "Staff Contacts Details";
                    ViewBag.ContactNameTitle = "Employee Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Employee;
                    break;
                case (int)Parameters.ContactType.Supplier:
                    v = new ContactDetailEditViewModel { Id = 0, Contacttype = (int)Parameters.ContactType.Supplier };
                    ViewBag.FormTitle = "Supplier Contacts Details";
                    ViewBag.ContactNameTitle = "Supplier Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Supplier;
                    break;
                case (int)Parameters.ContactType.Mechanic:
                    v = new ContactDetailEditViewModel { Id = 0, Contacttype = (int)Parameters.ContactType.Mechanic };
                    ViewBag.FormTitle = "Mechanic Contacts Details";
                    ViewBag.ContactNameTitle = "Mechanic Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Mechanic;
                    break;
                default:
                    v = new ContactDetailEditViewModel();
                    break;
            }        

            PopulateSelectListDataSources();

            return View("ContactDetailsForm", v);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.VIEW_CONTACTS)]
        public ActionResult GetContactDetails(int id, int contactType)
        {

            var m = _contactDetailService.GetContactDetailById(id);

            switch (contactType)
            {
                case (int)Parameters.ContactType.Employee:
                    
                    ViewBag.FormTitle = "Staff Contacts Details";
                    ViewBag.ContactNameTitle = "Employee Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Employee;
                    break;
                case (int)Parameters.ContactType.Supplier:
                   
                    ViewBag.FormTitle = "Supplier Contacts Details";
                    ViewBag.ContactNameTitle = "Supplier Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Supplier;
                    break;
                case (int)Parameters.ContactType.Mechanic:
                    
                    ViewBag.FormTitle = "Mechanic Contacts Details";
                    ViewBag.ContactNameTitle = "Mechanic Name";
                    ViewBag.ContactType = (int)Parameters.ContactType.Mechanic;
                    break;
                default:
                   
                    break;
            }



            var v = Mapper.Map<ContactDetail, ContactDetailDisplayViewModel>(m);

            PopulateSelectListDataSources();

            return View("ContactDetailsView", v);
        }
        #endregion

        #region 3.a.2 Center

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.CENTRES)]
        public ActionResult Centers(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;

            PopulateSelectListDataSources();

            return View();
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_CENTRES)]
        public ActionResult EditCenter(int id)
        {
            var m = _centerService.GetByCenterNumber(id);

            var v = Mapper.Map<Center, CenterEditViewModel>(m);

            PopulateSelectListDataSources();

            return View("CenterForm", v);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_CENTRES)]
        public ActionResult CreateCenter()
        {
            CenterEditViewModel v = new CenterEditViewModel { CenterNumber = 0 };       

            PopulateSelectListDataSources();

            return View("CenterForm", v);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.VIEW_CENTRES)]
        public ActionResult GetCenter(int id)
        {

            var m = _centerService.GetByCenterNumber(id);

            var v = Mapper.Map<Center, CenterDisplayViewModel>(m);

            return View("CenterView", v);
        }
        #endregion

        #region 3.a.3 Business Unit

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.BUSINESS_UNITS)]
        public ActionResult BusinessUnits(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;

            PopulateSelectListDataSources();

            return View();
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_BUSINESS_UNITS)]
        public ActionResult EditBusinessUnit(int id)
        {
            var m = _businessUnitService.GetBusinessUnitById(id);

            var v = Mapper.Map<BusinessUnit, BusinessUnitEditViewModel>(m);

            PopulateSelectListDataSources();

            return View("BusinessUnitForm", v);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_BUSINESS_UNITS)]
        public ActionResult CreateBusinessUnit()
        {
            BusinessUnitEditViewModel v = new BusinessUnitEditViewModel { UnitNumber = 0 };

            PopulateSelectListDataSources();

            return View("BusinessUnitForm", v);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.VIEW_BUSINESS_UNITS)]
        public ActionResult GetBusinessUnit(int id)
        {

            var m = _businessUnitService.GetBusinessUnitById(id);

            var v = Mapper.Map<BusinessUnit, BusinessUnitDisplayViewModel>(m);          

            return View("BusinessUnitView", v);
        }
        #endregion

        #region 3.a.4 Business Group
        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.BUSINESS_GROUPS)]
        public ActionResult BusinessGroups(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;

            PopulateSelectListDataSources();

            return View();
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_BUSINESS_GROUPS)]
        public ActionResult EditBusinessGroup(int id)
        {
            var m = _businessGroupService.GetBusinessGroupById(id);

            var v = Mapper.Map<BusinessGroup, BusinessGroupEditViewModel>(m);

            PopulateSelectListDataSources();

            return View("BusinessGroupForm", v);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_BUSINESS_GROUPS)]
        public ActionResult CreateBusinessGroup()
        {
            BusinessGroupEditViewModel v = new BusinessGroupEditViewModel { GroupNumber = 0 };

            PopulateSelectListDataSources();

            return View("BusinessGroupForm", v);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.VIEW_BUSINESS_GROUPS)]
        public ActionResult GetBusinessGroup(int id)
        {

            var m = _businessGroupService.GetBusinessGroupById(id);

            var v = Mapper.Map<BusinessGroup, BusinessGroupDisplayViewModel>(m);


            return View("BusinessGroupView", v);
        }
        #endregion

        #region 3.a.5 Region
        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.REGIONS)]
        public ActionResult Regions(string message, bool isError)
        {
            ViewBag.NotificationMessage = message;
            ViewBag.NotificationIsError = isError;

            PopulateSelectListDataSources();

            return View();
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_REGIONS)]
        public ActionResult EditRegion(int id)
        {
            var m = _regionService.GetRegionalById(id);

            var v = Mapper.Map<Regional, RegionEditViewModel>(m);

            PopulateSelectListDataSources();

            return View("RegionForm", v);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.MANAGE_REGIONS)]
        public ActionResult CreateRegion()
        {
            RegionEditViewModel v = new RegionEditViewModel { RegionNumber = 0 };

            PopulateSelectListDataSources();

            return View("RegionForm", v);
        }

        [HttpGet]
        [UserActionAuthorization(Parameters.Action.VIEW_REGIONS)]
        public ActionResult GetRegion(int id)
        {

            var m = _regionService.GetRegionalById(id);

            var v = Mapper.Map<Regional, RegionDisplayViewModel>(m);            

            return View("RegionView", v);
        }
        #endregion

        #region 3.a.6 Company
        
        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.CLIENT_INFORMATION)]
        [UserActionAuthorization(Parameters.Action.MANAGE_CLIENT_INFORMATION)]
        public ActionResult EditCompany()
        {
            var m = _clientInformationService.GetClient();

            var v = Mapper.Map<ClientInformation, ClientInformationEditViewModel>(m);          

            return View("CompanyInformationForm", v);
        }

        #endregion


        #endregion

        #region 3.b. Get List of Values Related Actions

        #endregion

        #region 3.c. Grid Related Actions

        #region 3.c.1 Contacts Grid Related Actions
        public ActionResult GetContactDetailList([DataSourceRequest] DataSourceRequest request,
                string contactName, int contactType)
        {
            IEnumerable<ContactDetail> m;

            switch (contactType)
            {
                case (int)Parameters.ContactType.Employee:
                    m = _contactDetailService.GetEmployeeContacts(Parameters.SystemParameterCode.Employee, contactName);
                    break;
                case (int)Parameters.ContactType.Supplier:
                    m = _contactDetailService.GetSupplierContacts(contactName);
                    break;
                case (int)Parameters.ContactType.Mechanic:
                    m = _contactDetailService.GetEmployeeContacts(Parameters.SystemParameterCode.Mechanics, contactName);
                    break;
                default:
                    m = new List<ContactDetail>();
                    break;
            }

            var v = Mapper.Map<IEnumerable<ContactDetail>, IEnumerable<ContactDetailDisplayViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }
        #endregion

        #region 3.c.2 Center Grid Related Actions
        public ActionResult GetCenterList([DataSourceRequest] DataSourceRequest request, 
                string name, int region)
        {
            var centers = _centerService.GetAllCenterWithPermission(CurrentUser, name, region);

            var vm = Mapper.Map<IEnumerable<Center>, IEnumerable<CenterDisplayViewModel>>(centers);           

            return Json(vm.ToDataSourceResult(request));
        }

        #endregion

        #region 3.c.3 Business Unit Grid Related Actions
        public ActionResult GetBusinessUnitList([DataSourceRequest] DataSourceRequest request,
                string name, int manager)
        {
            var m = _businessUnitService.GetAll(name, manager);

            var v = Mapper.Map<IEnumerable<BusinessUnit>, IEnumerable<BusinessUnitDisplayViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        #endregion

        #region 3.c.4 Business Group Grid Related Actions
        public ActionResult GetBusinessGroupList([DataSourceRequest] DataSourceRequest request,
                string name, int businessUnit, int manager)
        {
            var m = _businessGroupService.GetAll(name,manager,businessUnit);

            var v = Mapper.Map<IEnumerable<BusinessGroup>, IEnumerable<BusinessGroupDisplayViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        #endregion

        #region 3.c.5 Region Grid Related Actions
        public ActionResult GetRegionList([DataSourceRequest] DataSourceRequest request)
        {
            var m = _regionService.GetAll();

            var v = Mapper.Map<IEnumerable<Regional>, IEnumerable<RegionDisplayViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        #endregion

        #endregion

        #region 3.d. Form CRUD Post Related Actions

        #region 3.d.1 Contact Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_CONTACTS)]
        public ActionResult CreateContactDetails(ContactDetailEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<ContactDetailEditViewModel, ContactDetail>(entityViewModel);

                    _contactDetailService.Create(m);

                    _contactDetailService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.ContactDetail, Parameters.Table.ContactDetail);

                    return Json(new {id = m.Id, message = "Changes saved successfully.", isError = false });

                }
                else
                {
                    return Json(new { id = -1,message = "The ModelState is invalid or the ViewModel is null.", isError = true });
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
        [UserActionAuthorization(Parameters.Action.MANAGE_CONTACTS)]
        public ActionResult UpdateContactDetails(ContactDetailEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<ContactDetailEditViewModel, ContactDetail>(entityViewModel);

                    _contactDetailService.Update(m);

                    _contactDetailService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.ContactDetail, Parameters.Table.ContactDetail);

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
        [UserActionAuthorization(Parameters.Action.MANAGE_CONTACTS)]
        public ActionResult DeleteContactDetails(int id)
        {
            try
            {
                if (id != 0)
                {

                    var m = _contactDetailService.GetContactDetailById(id);
                    _contactDetailService.Delete(m);
                    _contactDetailService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.ContactDetail, Parameters.Table.ContactDetail);


                    return Json(new { message = "Record deleted successfully.", isError = false });


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

        #region 3.d.2 Center
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_CENTRES)]
        public ActionResult CreateCenter(CenterEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<CenterEditViewModel, Center>(entityViewModel);

                    _centerService.Create(m);

                    _centerService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.Center, Parameters.Table.Center);

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
        [UserActionAuthorization(Parameters.Action.MANAGE_CENTRES)]
        public ActionResult UpdateCenter(CenterEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<CenterEditViewModel, Center>(entityViewModel);

                    _centerService.Update(m);

                    _centerService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Center, Parameters.Table.Center);

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
        [UserActionAuthorization(Parameters.Action.MANAGE_CENTRES)]
        public ActionResult DeleteCenter(int id)
        {
            try
            {
                if (id != 0)
                {

                    var m = _centerService.GetByCenterNumber(id);

                    if (_centerService.IsInUse(id))
                    {
                        return Json(new { isInUse = true, message = "Cannot delete Center. Center is in use.", isError = true });
                    }
                    else
                    {
                        _centerService.Delete(m);
                        _centerService.Save();
                        CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.Center, Parameters.Table.Center);
                        return Json(new { isInUse = false, message = "Record deleted successfully.", isError = false });
                    }

                }
                else
                {

                    return Json(new { message = "The ModelState is invalid or the Id is 0.", isError = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { isInUse = false, message = ex.Message, isError = true });
            }

        }

        #endregion

        #region 3.d. Business Unit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_BUSINESS_UNITS)]
        public ActionResult CreateBusinessUnit(BusinessUnitEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<BusinessUnitEditViewModel, BusinessUnit>(entityViewModel);

                    _businessUnitService.Create(m);

                    _businessUnitService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.BusinessUnit, Parameters.Table.BusinessUnit);

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
        [UserActionAuthorization(Parameters.Action.MANAGE_BUSINESS_UNITS)]
        public ActionResult UpdateBusinessUnit(BusinessUnitEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<BusinessUnitEditViewModel, BusinessUnit>(entityViewModel);

                    _businessUnitService.Update(m);

                    _businessUnitService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.BusinessUnit, Parameters.Table.BusinessUnit);

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
        [UserActionAuthorization(Parameters.Action.MANAGE_BUSINESS_UNITS)]
        public ActionResult DeleteBusinessUnit(int id)
        {
            try
            {
                if (id != 0)
                {

                    var m = _businessUnitService.GetBusinessUnitById(id);

                    if (_businessUnitService.IsInUse(id))
                    {
                        return Json(new { isInUse = true, message = "Cannot delete Business Unit. Business Unit is in use.", isError = true });
                    }
                    else
                    {
                        _businessUnitService.Delete(m);
                        _businessUnitService.Save();
                        CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.BusinessUnit, Parameters.Table.BusinessUnit);
                        return Json(new { isInUse = false, message = "Record deleted successfully.", isError = false });
                    }

                }
                else
                {

                    return Json(new { message = "The ModelState is invalid or the Id is 0.", isError = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { isInUse = false, message = ex.Message, isError = true });
            }

        }

        #endregion

        #region 3.d.4 Business Group
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_BUSINESS_GROUPS)]
        public ActionResult CreateBusinessGroup(BusinessGroupEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<BusinessGroupEditViewModel, BusinessGroup>(entityViewModel);

                    _businessGroupService.Create(m);

                    _businessGroupService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.BusinessGroup, Parameters.Table.BusinessGroup);

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
        [UserActionAuthorization(Parameters.Action.MANAGE_BUSINESS_GROUPS)]
        public ActionResult UpdateBusinessGroup(BusinessGroupEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<BusinessGroupEditViewModel, BusinessGroup>(entityViewModel);

                    _businessGroupService.Update(m);

                    _businessGroupService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.BusinessGroup, Parameters.Table.BusinessGroup);

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
        [UserActionAuthorization(Parameters.Action.MANAGE_BUSINESS_GROUPS)]
        public ActionResult DeleteBusinessGroup(int id)
        {
            try
            {
                if (id != 0)
                {

                    var m = _businessGroupService.GetBusinessGroupById(id);

                    if (_businessGroupService.IsInUse(id))
                    {
                        return Json(new { message = "Cannot delete Business Group. Business Group is in use.", isError = true });
                    }
                    else
                    {
                        _businessGroupService.Delete(m);
                        _businessGroupService.Save();
                        CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.BusinessGroup, Parameters.Table.BusinessGroup);
                        return Json(new { message = "Record deleted successfully.", isError = false });
                    }

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

        #region 3.d.5 Region
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_REGIONS)]
        public ActionResult CreateRegion(RegionEditViewModel entityViewModel)
        {
            try
            {

                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<RegionEditViewModel, Regional>(entityViewModel);

                    _regionService.Create(m);

                    _regionService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.Regional, Parameters.Table.Regional);

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
        [UserActionAuthorization(Parameters.Action.MANAGE_REGIONS)]
        public ActionResult UpdateRegion(RegionEditViewModel entityViewModel)
        {
            try
            {
                if (ModelState.IsValid && entityViewModel != null)
                {

                    var m = Mapper.Map<RegionEditViewModel, Regional>(entityViewModel);

                    _regionService.Update(m);

                    _regionService.Save();

                    CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.Regional, Parameters.Table.Regional);

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
        [UserActionAuthorization(Parameters.Action.MANAGE_REGIONS)]
        public ActionResult DeleteRegion(int id)
        {
            try
            {
                if (id != 0)
                {

                    var m = _regionService.GetRegionalById(id);

                    _regionService.Delete(m);
                    _regionService.Save();
                    CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.Regional, Parameters.Table.Regional);

                    return Json(new { message = "Record deleted successfully.", isError = false });
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


        #region 3.d.6 Company 

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_CLIENT_INFORMATION)]
        public ActionResult UpdateCompany(ClientInformationEditViewModel entityViewModel, IEnumerable<HttpPostedFileBase> logoFiles)
        {
   
            if (ModelState.IsValid && entityViewModel != null)
            {

                if (logoFiles != null)
                {
                    MemoryStream target = new MemoryStream();
                    logoFiles.ToList()[0].InputStream.CopyTo(target);
                    entityViewModel.Logo = target.ToArray();
                }

                var m = Mapper.Map<ClientInformationEditViewModel, ClientInformation>(entityViewModel);

                _clientInformationService.Update(m);

                _clientInformationService.Save();

                CreateAuditTrail(Parameters.DatabaseAction.Update, Parameters.SubSystem.SystemParameters, Parameters.Table.SystemParameters);

            }

            return RedirectToAction("EditCompany");
        }



        #endregion


        #endregion

        #region 3.e. Other Post Related Actions


        #endregion

        #endregion

        #region 4. Protected Members

        #endregion

        #region 5. Private Members


        private void PopulateSelectListDataSources()
        {
            ViewBag.BusinessUnits = _businessUnitService.GetAll().Select(t => new { Value = t.UnitNumber, Text = t.Name });
            ViewBag.Genders = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.Gender).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.SupplierTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.SupplierType).Select(t => new { Value = t.Id, Text = t.ParameterName });
            ViewBag.Centers = _centerService.GetAllCenterWithPermission(CurrentUser).Select(t => new { Value = t.CenterNumber, Text = t.Name });
            ViewBag.Managers = _contactDetailService.GetManagerContacts().Select(t => new { Value = t.Id, Text = t.ContactName });          
            ViewBag.Regions = _regionService.GetAll().Select(t => new { Value = t.RegionNumber, Text = t.Name });           
        }

        #endregion

        #region 6. Helpers

        #endregion
    }
}