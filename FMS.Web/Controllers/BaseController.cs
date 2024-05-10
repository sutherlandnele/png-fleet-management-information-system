using AutoMapper;
using FMS.Common;
using FMS.Model;
using FMS.Service;
using FMS.Web.Identity;
using FMS.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FMS.Web.Controllers
{  
    [Authorize]
    public abstract class BaseController : Controller
    {
        #region 1. Private Members

        private readonly IAuditingService _auditingService;
        private readonly IContactDetailService _contactDetailService;
        private readonly UserManager<IdentityUser, Guid> _userManager;
        private readonly IVehicleManagementService _vehicleManagementService;
        private readonly IVehicleServiceService _vehicleServiceService;
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IBusinessGroupService _businessGroupService;
        private readonly ICenterService _centerService;
        private readonly IModelService _modelService;
        private readonly IDepotTankService _depotTankService;
        private readonly IAppRoleInterfaceAccessService _appRoleInterfaceAccessService;
        private readonly IAppRoleMenuAccessService _appRoleMenuAccessService;
        private readonly IAppRoleActionAccessService _appRoleActionAccessService;
        private readonly ISystemParameterCodeService _systemParameterCodeService;
        private readonly ISystemParameterService _systemParameterService;
        private readonly IAppIssueService _appIssueService;
      

        protected string CurrentUser { get; set; }
        protected string CurrentUserRole { get; set; }

        #endregion

        #region 2. Constructors
        public BaseController(IAuditingService auditingService
            ,UserManager<IdentityUser, Guid> userManager
            ,IContactDetailService contactDetailService
            ,IVehicleManagementService vehicleManagementService
            ,IVehicleServiceService vehicleServiceService
            ,IBusinessUnitService businessUnitService
            ,IBusinessGroupService businessGroupService
            ,ICenterService centerService
            ,IModelService modelService
            ,IDepotTankService depotTankService
            ,IAppRoleInterfaceAccessService appRoleInterfaceAccessService
            ,IAppRoleMenuAccessService appRoleMenuAccessService
            ,IAppRoleActionAccessService appRoleActionAccessService
            ,ISystemParameterCodeService systemParameterCodeService
            ,ISystemParameterService systemParameterService
            ,IAppIssueService appIssueService
           )
        {
           
            _appRoleActionAccessService = appRoleActionAccessService;
            _appRoleInterfaceAccessService = appRoleInterfaceAccessService;
            _appRoleMenuAccessService = appRoleMenuAccessService;
            _auditingService = auditingService;
            _userManager = userManager;
            _contactDetailService = contactDetailService;
            _vehicleManagementService = vehicleManagementService;
            _vehicleServiceService = vehicleServiceService;
            _businessUnitService = businessUnitService;
            _businessGroupService = businessGroupService;
            _centerService = centerService;
            _modelService = modelService;
            _depotTankService = depotTankService;
            _systemParameterCodeService = systemParameterCodeService;
            _systemParameterService = systemParameterService;
            _appIssueService = appIssueService;

        }
        #endregion

        #region 3. Shared Actions

        #region 3.a Shared Ajax Display Info Actions

        [HttpPost]
        public ActionResult GetOperatorInformation(int operatorId)
        {
            try
            {        

                OperatorDisplayInfoViewModel od = MapOperatorDisplayInfo(operatorId);


                return Json(new
                {
                    op = od,
                    message = "Retrieved Operator Information Successfully.",
                    isError = false
                });


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
        public ActionResult GetVehicleInformation(int vehicleId)
        {
            try
            {

                VehicleDisplayInfoViewModel vd = MapVehicleDisplayInfo(vehicleId);

                return Json(new
                {
                    vehicle = vd,
                    message = "Retrieved Operator Information Successfully.",
                    isError = false
                });


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
        public ActionResult GetVehicleServiceInformation(int vehicleServiceId)
        {
            try
            {

                VehicleServiceDisplayViewModel vm = MapVehicleServiceDisplayInfo(vehicleServiceId);

                return Json(new
                {
                    vehicleService = vm,
                    message = "Retrieved Vehicle Service Information Successfully.",
                    isError = false
                });


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
        public ActionResult GetContactInformation(int contactDetailId)
        {
            try
            {

                var m = _contactDetailService.GetContactDetailById(contactDetailId);

                var v = Mapper.Map<ContactDetail, ContactDetailDisplayViewModel>(m);

                return Json(new
                {
                    contact = v,
                    message = "Retrieved Vehicle Service Information Successfully.",
                    isError = false
                });


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

        #region 3.b Shared List of Values
        public JsonResult GetBusinessUnits()
        {
            IEnumerable<BusinessUnit> businessUnits;

            businessUnits = _businessUnitService.GetAll();

            return Json(businessUnits.Select(bu => new { Value = bu.UnitNumber, Text = bu.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVehiclesByCenterPermission()
        {
            var vehicles = _vehicleManagementService.GetFilterByCenterPermission(CurrentUser);

            return Json(vehicles.Select(bu => new { Value = bu.Id, Text = bu.RegistrationNumber }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmployeeDrivers()
        {
     
            var empDrivers = _contactDetailService.GetDriverContacts().Select(t => new ListOfValuesDisplayViewModel { Value = t.Id, Text = t.ContactName });

            return Json(empDrivers, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetVehicles()
        {
            var vehicles = _vehicleManagementService.GetAll();

            return Json(vehicles.Select(bu => new { Value = bu.Id, Text = bu.RegistrationNumber }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBusinessGroupsByBusinessUnitId(int? businessUnitId, string businessGroupFilter)
        {
            var businessGroups = _businessGroupService.GetAll();

            if (businessUnitId != -1)
            {
                businessGroups = businessGroups.Where(bg => bg.BusinessUnitId == businessUnitId);
            }
            if (!string.IsNullOrEmpty(businessGroupFilter))
            {
                businessGroups = businessGroups.Where(bg => bg.GroupName.ToLower().Contains(businessGroupFilter.ToLower()));
            }

            return Json(businessGroups.Select(bg => new { Value = bg.GroupNumber, Text = bg.GroupName }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModelsByMakeId(int? makeId, string modelFilter)
        {
            var models = _modelService.GetAll();

            if (makeId != -1)
            {

                models = models.Where(m => m.MakeId == makeId);
            }
            if (!string.IsNullOrEmpty(modelFilter))
            {
                models = models.Where(bg => bg.Name.ToLower().Contains(modelFilter.ToLower()));
            }

            return Json(models.Select(m => new { Value = m.Id, Text = m.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCenters()
        {
            var centers = _centerService.GetAllCenterWithPermission(CurrentUser);

            return Json(centers.Select(c => new { Value = c.CenterNumber, Text = c.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCentersByRegionId(int? regionId, string centerFilter)
        {
            var centers = _centerService.GetAllCenterWithPermission(CurrentUser);

            if (regionId != -1)
            {
                centers = centers.Where(c => c.RegionaNumberId == regionId);
            }

            if (!string.IsNullOrEmpty(centerFilter))
            {
                centers = centers.Where(c => c.Name.ToLower().Contains(centerFilter.ToLower()));
            }

            return Json(centers.Select(c => new { Value = c.CenterNumber, Text = c.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFuelTanksByCenterId(int? centerId, string depotTankFilter)
        {
           var fuelTanks = _depotTankService.GetTankListByPermission(CurrentUser);

            if (centerId != -1)
            {
                fuelTanks = fuelTanks.Where(c => c.CenterId == centerId);
            }

            if (!string.IsNullOrEmpty(depotTankFilter))
            {
                fuelTanks = fuelTanks.Where(f => f.BowserNumber .ToLower().Contains(depotTankFilter.ToLower()));
            }

            return Json(fuelTanks.Select(c => new { Value = c.BowserNumber, Text = c.BowserNumber }), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 3.c Shared Actions

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ApplicationPermissionRequest()
        {

            ViewBag.AppIssueTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.AppIssueType)
                                    .Select(t => new { Value = t.Id, Text = t.ParameterName });

            var vm = new AppIssueEditViewModel
            {
                Id = 0,
                AppIssueTypeId = (int)Parameters.AppIssueType.ApplicationPermissionRequest,
                CreatedBy = CurrentUser ?? "",
                Description = "Hi, I currently do not have permission to access .... Please kindly review my request and grant me access. Thanks"
            };

            return PartialView("ApplicationIssueRegistration", vm);
        }




        [HttpGet]
        [AllowAnonymous]
        public ActionResult ContactUs()
        {

            ViewBag.AppIssueTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.AppIssueType)
                                    .Select(t => new { Value = t.Id, Text = t.ParameterName });

            var vm = new AppIssueEditViewModel
            {
                Id = 0,
                AppIssueTypeId = (int)Parameters.AppIssueType.ReportApplicationError,
                CreatedBy = CurrentUser ?? "",
                Description = "Hi, I would like to report an application error... Thanks"
            };

            return PartialView("ApplicationIssueRegistration", vm);
        }



        [HttpGet]
        [AllowAnonymous]
        public ActionResult ApplicationAccessRequest()
        {

            ViewBag.AppIssueTypes = _systemParameterService.GetAllFilterByParameterType((int)Parameters.SystemParameterType.AppIssueType)
                                    .Select(t => new { Value = t.Id, Text = t.ParameterName });

            var vm = new AppIssueEditViewModel
            {
                Id = 0,
                AppIssueTypeId = (int)Parameters.AppIssueType.ApplicationAccessRequest,             
                CreatedBy = CurrentUser ?? "",
                Description = "Hi, I require access to the Fleet Management System. Please kindly create my account. Thanks"
            };

            return PartialView("ApplicationIssueRegistration", vm);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateApplicationIssue(AppIssueEditViewModel entityViewModel)
        {
            if (ModelState.IsValid && entityViewModel != null)
            {
                try
                {
                    entityViewModel.CreatedDate = DateTime.Now;
                    entityViewModel.HasBeenResolved = false;

                    var m = Mapper.Map<AppIssueEditViewModel, AppIssue>(entityViewModel);

                    _appIssueService.Create(m);
                    _appIssueService.Save();

                    var appIssueType = _systemParameterService.GetAll().FirstOrDefault(x=>x.Id == m.AppIssueTypeId).ParameterName;

                    var userEmail = m.CreatedBy;

                    var mailSubject = "FMS Application Service or Incidient Request: " + appIssueType;

                    var logoPath  = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~/Content/images/menu/app-logo.png"));
                    var loginPath = string.Format("{0}://{1}", Request.Url.Scheme, Request.Url.Authority);


                    var emailLinkButtonMarkUp = "<div>" +
                                "<!--[if mso]>" + 
                                "<v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns: w='urn:schemas-microsoft-com:office:word' href='" + loginPath + "' style='height:40px;v-text-anchor:middle;width:300px;' arcsize='10%' stroke ='f' fillcolor='#d62828'>" +
                                "<w:anchorlock />" +
                                "<center style='color:#ffffff;font-family:sans-serif;font-size:16px;font-weight:bold;'>" +
                                "Login to FMS" + 
                                 "</center>" +                 
                                 "</v:roundrect>" +                  
                                 "<![endif]-->" + 
                                 "<![if !mso]>" +
                                 "<table cellspacing='0' cellpadding='0'><tr>" +                      
                                 "<td align='center' width='300' height='40' bgcolor='#d62828' style ='-webkit-border-radius:5px;-moz-border-radius:5px; border-radius:5px;color:#ffffff;display:block;'>" +
                                 "<a href='" + loginPath + "' style='font-size:16px;font-weight:bold;font-family:sans-serif; text-decoration: none; line-height:40px; width:100%; display:inline-block'>" +
                                 "<span style = 'color:#ffffff;'>" +
                                 "Login to FMS" +
                                 "</span>" +
                                 "</a>" +
                                 "</td>" +
                                 "</tr>" + 
                                 "</table>" +
                                 "<![endif]>"+
                                 "</div>";


                    var mailMessage = "<p style='background-color:#666699;padding:10px;'><img style='display: block; margin-left: auto; margin-right: auto;' src='" + logoPath + "' /></p>" +
                              "<p>Hi Admin,</p>" +
                              "<p>An Application Service or Incidient Request has been raised. Please kindly attend to this request.</p>" +
                              "<div style='background-color:#001a4d;padding:10px;color:#ffffff'><p><strong>Category:</strong> " + appIssueType + "</p>" + 
                              "<p><strong>Requester Email:</strong> " + m.CreatedBy + "</p>" + 
                              "<p><strong>Date/Time Requested:</strong> " + ((DateTime)m.CreatedDate).ToString("dd/MM/yyyy hh:mm ss tt") + "</p>" +
                              "<p><strong>Brief Description:</strong></p>" +
                              "<p>" + m.Description + "</p></div>" + 
                              "<p>&nbsp;</p>" + emailLinkButtonMarkUp +
                              "<p>Kind Regards,</p>" +
                              "<p>Fleet Management Team</p>";



                    var hasMailBeenSent = await SendSysAdminEmailAsync(mailSubject, mailMessage);

                    if (hasMailBeenSent)
                    {
                        return Json(new { message = "Changes saved successfully. Email sent to sys admin.", isError = false });
                    }
                    else
                    {
                        return Json(new { message = "Changes saved successfully. Email NOT sent to sys admin. ", isError = false });
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
            else
            {
                return Json(new { message = "The ModelState is invalid or the ViewModel is null.", isError = true });
            }
        }
       

        #endregion

        #endregion

        #region 4. Protected Methods

        protected VehicleDisplayInfoViewModel MapVehicleDisplayInfo(int vehicleId)
        {
            var v = _vehicleManagementService.GetVehicleById(vehicleId);
            var vd = new VehicleDisplayInfoViewModel();

            if (v != null)
            {

                vd.VehicleRegistrationNumber = v.RegistrationNumber;
                vd.VehicleMake = v.Make != null ? v.Make.ParameterName : string.Empty;
                vd.VehicleColor = v.VehicleColor;
                vd.VehicleCondition = v.Condition != null ? v.Condition.ParameterName : string.Empty;
                vd.VehicleStatus = v.Status != null ? v.Status.ParameterName : string.Empty;
                vd.VehicleModel = v.Model != null ? v.Model.Name : string.Empty;
                vd.VehicleType = v.VehicleType != null ? v.VehicleType.Type : string.Empty;
                vd.BusinessGroup = v.BusinessGroup != null ? v.BusinessGroup.GroupName : string.Empty;
                vd.Center = v.Center != null ? v.Center.Name : string.Empty;
                vd.CurrentMileage = v.CurrentMileage.ToString();
                
            }

            return vd;
        }

        protected VehicleServiceDisplayViewModel MapVehicleServiceDisplayInfo(int vehicleServiceId)
        {
            var vs = _vehicleServiceService.GetServiceById(vehicleServiceId);
            var vm = new VehicleServiceDisplayViewModel();

            if (vs != null)
            {
                vm.Id = vs.Id;
                vm.Cost = vs.Cost.ToString();
                vm.EndDate = vs.EndDate != null ? ((DateTime)vs.EndDate).ToString("dd/MM/yyyy") : string.Empty;
                vm.StartDate = vs.StartDate != null ? ((DateTime)vs.StartDate).ToString("dd/MM/yyyy") : string.Empty;
                vm.Incident = vs.Incident != null ? vs.Incident.IncidentFileNumber : string.Empty;
                vm.IsAmountPaid = (bool)vs.IsAmountPaid;
                vm.IsIncidentService = (bool)vs.IsIncidentService;
                vm.PoReference = vs.PoReference;
                vm.Provider = vs.ContactDetail1 != null? vs.ContactDetail1.ContactName : string.Empty;
                vm.ServiceJobNumber = vs.ServiceJobNumber;
                vm.ServiceMechanic = vs.ContactDetail != null? vs.ContactDetail.ContactName : string.Empty;
            }

            return vm;
        }

        protected void CreateAuditTrail(Parameters.DatabaseAction action, Parameters.SubSystem subSystem, Parameters.Table table)
        {
            var user = _userManager.FindByName(User.Identity.Name);

            SqlAudit audit = new SqlAudit()
            {
                ComputerName = Request.UserHostAddress,
                Username = user.UserName,
                DateAndTime = DateTime.Now,
                Role = string.Join(", ", _userManager.GetRoles(user.Id)),
                DatabaseAction = action.ToString(),
                SqlStatement = "",
                SubSystem = subSystem.ToString(),
                DatabaseTable = table.ToString()
            };

            _auditingService.Create(audit);
            _auditingService.Save();
        }

        protected OperatorDisplayInfoViewModel MapOperatorDisplayInfo(int operatorId)
        {
            var od = new OperatorDisplayInfoViewModel();

            var ct = _contactDetailService.GetAll().FirstOrDefault(c => c.Id == (int)operatorId);

            if (ct != null)
            {
                od.StaffNumber = string.Empty;
                od.DriverDateOfBirth = ct.DateOfBirth != null ? ((DateTime)ct.DateOfBirth).ToString("dd/MM/yyyy"):string.Empty;
                od.DriverEmail = ct.Email;
                od.DriverLicenceNumber = ct.LicenceNumber;
                od.DriverMobile = ct.Mobile;
                od.DriverName = ct.ContactName;
            }
            else
            {
                od.StaffNumber = string.Empty;
                od.DriverDateOfBirth = null;
                od.DriverEmail = string.Empty;
                od.DriverLicenceNumber = string.Empty;
                od.DriverMobile = string.Empty;
                od.DriverName = string.Empty;
            }


            return od;
        }

        protected bool UserIsAuthorizedForGridAction(Parameters.Action action)
        {
            return _appRoleActionAccessService.CanAccess(action, CurrentUserRole);
        }    

   

        #endregion

        #region 5. Protected Overrides
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (HttpContext != null)
            {
                if (HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated)
                {
                    CurrentUser = HttpContext.User.Identity.Name;
                    var m = _userManager.Users.Where(u => u.UserName == CurrentUser).FirstOrDefault();
                    CurrentUserRole = _userManager.GetRoles(m.Id).FirstOrDefault();

                    if (Session[CurrentUserRole + "UIVisibilityList"] == null)
                    {
                        SetUserControlsVisibility();
                    }

                }
            }
        }


        #endregion

        #region 6. Private Methods

        protected bool SendUserEmail(string userEmailTo, string subject, string message)
        {
            // Initialization.  
            bool isSend = false;
            try
            {

                var smtpServerId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPServer");
                var smtpPortId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPPort");
                var smtpUserId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPUser");
                var smptUserPwdId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPPassword");
                var smtpServer = _systemParameterService.GetSystemParameterNameByCodeId((int)smtpServerId);
                var smtpPort = _systemParameterService.GetSystemParameterNameByCodeId((int)smtpPortId);
                var smtpUser = _systemParameterService.GetSystemParameterNameByCodeId((int)smtpUserId);
                var smptUserPwd = _systemParameterService.GetSystemParameterNameByCodeId((int)smptUserPwdId);

                if (smtpServerId != null && smtpPortId != null && smtpUserId != null && smptUserPwdId != null)
                {
                    if (!string.IsNullOrEmpty(userEmailTo) && !string.IsNullOrEmpty(smtpServer) && !string.IsNullOrEmpty(smtpPort)
                        && !string.IsNullOrEmpty(smtpUser) && !string.IsNullOrEmpty(smptUserPwd))
                    {
                        using (var smtpClient = new SmtpClient(smtpServer))
                        {
                            smtpClient.Port = Convert.ToInt32(smtpPort);
                            smtpClient.EnableSsl = true;
                            smtpClient.Credentials = new NetworkCredential(smtpUser, smptUserPwd);
                            MailMessage mailMessage = new MailMessage();
                            mailMessage.IsBodyHtml = true;
                            mailMessage.From = new MailAddress(smtpUser);
                            mailMessage.To.Add(userEmailTo);
                            mailMessage.Subject = subject;
                            mailMessage.Body = message;

                            smtpClient.Send(mailMessage);

                            isSend = true;
                        }

                    }
                }

            }

            catch
            {
                isSend = false;
            }

            // info.  
            return isSend;
        }

        protected async Task<bool> SendUserEmailAsync(string userEmailTo, string subject, string message)
        {
            // Initialization.  
            bool isSend = false;
            try
            {
               
                var smtpServerId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPServer");
                var smtpPortId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPPort");
                var smtpUserId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPUser");
                var smptUserPwdId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPPassword");               
                var smtpServer = _systemParameterService.GetSystemParameterNameByCodeId((int)smtpServerId);
                var smtpPort = _systemParameterService.GetSystemParameterNameByCodeId((int)smtpPortId);
                var smtpUser = _systemParameterService.GetSystemParameterNameByCodeId((int)smtpUserId);
                var smptUserPwd = _systemParameterService.GetSystemParameterNameByCodeId((int)smptUserPwdId);

                if (smtpServerId != null && smtpPortId != null && smtpUserId != null && smptUserPwdId != null)
                {
                    if (!string.IsNullOrEmpty(userEmailTo) && !string.IsNullOrEmpty(smtpServer) && !string.IsNullOrEmpty(smtpPort)
                        && !string.IsNullOrEmpty(smtpUser) && !string.IsNullOrEmpty(smptUserPwd))
                    {
                        using (var smtpClient = new SmtpClient(smtpServer))
                        {
                            smtpClient.Port = Convert.ToInt32(smtpPort);
                            smtpClient.EnableSsl = true;
                            smtpClient.Credentials = new NetworkCredential(smtpUser, smptUserPwd);
                            MailMessage mailMessage = new MailMessage();
                            mailMessage.IsBodyHtml = true;
                            mailMessage.From = new MailAddress(smtpUser);
                            mailMessage.To.Add(userEmailTo);
                            mailMessage.Subject = subject;
                            mailMessage.Body = message;

                            await smtpClient.SendMailAsync(mailMessage);

                            isSend = true;
                        }

                    }
                }

            }

            catch
            {
                isSend = false;
            }

            // info.  
            return isSend;
        }

        protected async Task<bool> SendSysAdminEmailAsync(string subject, string message)
        {
            // Initialization.  
            bool isSend = false;
            try
            {
                var toEmailId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SysAdminEmail");
                var smtpServerId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPServer");
                var smtpPortId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPPort");
                var smtpUserId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPUser");
                var smptUserPwdId = _systemParameterCodeService.GetSystemParameterCodeIdByCodeText("SMTPPassword");
                var toEmail =  _systemParameterService.GetSystemParameterNameByCodeId((int)toEmailId);       
                var smtpServer = _systemParameterService.GetSystemParameterNameByCodeId((int)smtpServerId);
                var smtpPort = _systemParameterService.GetSystemParameterNameByCodeId((int)smtpPortId);
                var smtpUser = _systemParameterService.GetSystemParameterNameByCodeId((int)smtpUserId);
                var smptUserPwd = _systemParameterService.GetSystemParameterNameByCodeId((int)smptUserPwdId);

                if (toEmailId != null && smtpServerId != null && smtpPortId != null && smtpUserId != null && smptUserPwdId != null)
                {
                    if (!string.IsNullOrEmpty(toEmail) && !string.IsNullOrEmpty(smtpServer) && !string.IsNullOrEmpty(smtpPort)
                        && !string.IsNullOrEmpty(smtpUser) && !string.IsNullOrEmpty(smptUserPwd))
                    {
                        using (var smtpClient = new SmtpClient(smtpServer))
                        {
                            smtpClient.Port = Convert.ToInt32(smtpPort);
                            smtpClient.EnableSsl = true;
                            smtpClient.Credentials = new NetworkCredential(smtpUser, smptUserPwd);
                            MailMessage mailMessage = new MailMessage();
                            mailMessage.IsBodyHtml = true;
                            mailMessage.From = new MailAddress(smtpUser);
                            mailMessage.To.Add(toEmail);
                            mailMessage.Subject = subject;
                            mailMessage.Body = message;

                            await smtpClient.SendMailAsync(mailMessage);

                            isSend = true;
                        }

                    }
                }

            }

            catch
            {
                isSend = false;
            }

            // info.  
            return isSend;
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;
        }
        private void SetUserControlsVisibility()
        {

            var UIVisibilityList = new Dictionary<string, bool>
            {
                // *** Menus ***
                { "MenuVehicleManagement", _appRoleMenuAccessService.CanAccess(Parameters.MenuName.VEHICLE_MANAGEMENT, CurrentUserRole) },
                { "MenuAllocationManagement", _appRoleMenuAccessService.CanAccess(Parameters.MenuName.ALLOCATION_MANAGEMENT, CurrentUserRole) },
                { "MenuServiceManagement", _appRoleMenuAccessService.CanAccess(Parameters.MenuName.SERVICE_MANAGEMENT, CurrentUserRole) },
                { "MenuFuelManagement", _appRoleMenuAccessService.CanAccess(Parameters.MenuName.FUEL_MANAGEMENT, CurrentUserRole) },
                { "MenuIncidentManagement", _appRoleMenuAccessService.CanAccess(Parameters.MenuName.INCIDENT_MANAGEMENT, CurrentUserRole) },
                { "MenuComplianceManagement", _appRoleMenuAccessService.CanAccess(Parameters.MenuName.COMPLIANCE_MANAGEMENT, CurrentUserRole) },
                { "MenuOrganisation", _appRoleMenuAccessService.CanAccess(Parameters.MenuName.ORGANIZATION, CurrentUserRole) },
                { "MenuParameters", _appRoleMenuAccessService.CanAccess(Parameters.MenuName.PARAMETERS, CurrentUserRole) },
                { "MenuSecurity", _appRoleMenuAccessService.CanAccess(Parameters.MenuName.SECURITY, CurrentUserRole) },
                { "MenuReports", _appRoleMenuAccessService.CanAccess(Parameters.MenuName.REPORTS, CurrentUserRole) },

                // *** Interfaces ***

                //Fuel
                { "InterfaceFuelRegister", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.FUEL_REGISTER, CurrentUserRole) },
                { "InterfaceBowserDipReadings", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.BOWSER_DIP_READINGS, CurrentUserRole) },
                { "InterfaceBowserRefuel", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.BOWSER_REFUEL, CurrentUserRole) },
                { "InterfaceBowserStatusSetup", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.BOWSER_STATUS_SETUP, CurrentUserRole) },


                //Compliance
                { "InterfaceManageNotification", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.MANAGE_NOTIFICATION, CurrentUserRole) },
                { "InterfaceComplianceDashboard", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.COMPLIANCE_DASHBOARD, CurrentUserRole) },
                { "InterfaceComplianceEntries", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.COMPLIANCE_ENTRIES, CurrentUserRole) },
                { "InterfaceAlerts", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.ALERTS, CurrentUserRole) },
                //{ "InterfaceManageSafetySticker", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.MANAGE_SAFETY_STICKER, CurrentUserRole) },

                //Organisation
                { "InterfaceContacts", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.CONTACTS, CurrentUserRole) },
                { "InterfaceMechanics", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.MECHANICS, CurrentUserRole) },
                { "InterfaceBusinessUnits", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.BUSINESS_UNITS, CurrentUserRole) },
                { "InterfaceBusinessGroups", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.BUSINESS_GROUPS, CurrentUserRole) },
                { "InterfaceRegions", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.REGIONS, CurrentUserRole) },
                { "InterfaceCenters", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.CENTRES, CurrentUserRole) },
                { "InterfaceClientInformation", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.CLIENT_INFORMATION, CurrentUserRole) },

                //Parameters
                { "InterfaceUserDefinedCodes", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.USER_DEFINE_CODES, CurrentUserRole) },
                { "InterfaceVehicleTypes", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.VEHICLE_TYPES, CurrentUserRole) },
                { "InterfaceVehicleModels", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.VEHICLE_MODEL, CurrentUserRole) },

                //Security
                { "InterfaceManageUsers", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.MANAGE_USERS, CurrentUserRole) },
                { "InterfaceCenterSecurity", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.CENTRE_SECURITY, CurrentUserRole) },
                { "InterfaceAuditTrail", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.AUDIT_TRAIL, CurrentUserRole) },
                { "InterfaceRole", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.ROLE, CurrentUserRole) },
                { "InterfacePermission", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.PERMISSION, CurrentUserRole) },

                //Vehicle Management
                { "InterfaceVehicleRegister", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.VEHICLE_REGISTER, CurrentUserRole) },
                { "InterfaceViewBOSVehicles", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.VIEW_BOS_VEHICLES, CurrentUserRole) },
                { "InterfaceViewDisposedVehicles", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.VIEW_DISPOSED_VEHICLES, CurrentUserRole) },

                //Vehicle Allocation
                { "InterfaceAllocation", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.ALLOCATION, CurrentUserRole) },

                //Service
                { "InterfaceService", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.SERVICE, CurrentUserRole) },
                { "InterfaceScheduleService", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.SCHEDULE_SERVICE, CurrentUserRole) },

                //Incident
                { "InterfaceIncidents", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.INCIDENTS, CurrentUserRole) },

                //Reports
                { "InterfaceRegistryReports", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.REGISTRY_REPORTS, CurrentUserRole) },
                { "InterfaceServiceReports", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.SERVICE_REPORTS, CurrentUserRole) },
                { "InterfaceFuelReports", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.FUEL_REPORTS, CurrentUserRole) },
                { "InterfaceAllocationReports", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.ALLOCATION_REPORTS, CurrentUserRole) },
                { "InterfaceManagementReports", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.MANAGEMENT_REPORTS, CurrentUserRole) },
                { "InterfaceComplianceReports", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.COMPLIANCE_REPORTS, CurrentUserRole) },
                { "InterfaceIncidentReports", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.INCIDENT_REPORTS, CurrentUserRole) },
                { "InterfaceOrganisationReports", _appRoleInterfaceAccessService.CanAccess(Parameters.Interface.ORGANIZATION_REPORT, CurrentUserRole) },

                // *** Actions ***

                //Fuel
                { "ActionManageVehicleFuelRegister", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_VEHICLE_FUEL_REGISTER, CurrentUserRole) },
                { "ActionViewVehicleFuelRegister", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_VEHICLE_FUEL_REGISTER, CurrentUserRole) },
                { "ActionManageTankDailyDipReadings", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_BOWSER_DAILY_DIP_READINGS, CurrentUserRole) },
                { "ActionViewTankDailyDipReadings", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_BOWSER_DAILY_DIP_READINGS, CurrentUserRole) },
                { "ActionManageTankRefuel", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_BOWSER_REFUEL, CurrentUserRole) },
                { "ActionViewTankRefuel", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_BOWSER_REFUEL, CurrentUserRole) },
                { "ActionManageTankStatusSetup", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_BOWSER_STATUS_SETUP, CurrentUserRole) },
                { "ActionViewTankStatusSetup", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_BOWSER_STATUS_SETUP, CurrentUserRole) },
                { "ActionAcquitFuelVoucher", _appRoleActionAccessService.CanAccess(Parameters.Action.ACQUIT_FUEL_VOUCHER, CurrentUserRole) },

                //Compliance
                { "ActionManageNotifications", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_NOTIFICATIONS, CurrentUserRole) },
                { "ActionViewNotifications", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_NOTIFICATIONS, CurrentUserRole) },
                { "ActionManageComplianceDashboard", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_COMPLIANCE_DASHBOARD, CurrentUserRole) },
                { "ActionViewComplianceDashboard", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_COMPLIANCE_DASHBOARD, CurrentUserRole) },
                { "ActionManageComplianceEntries", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_COMPLICANCE_ENTRIES, CurrentUserRole) },
                { "ActionViewComplianceEntries", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_COMPLICANCE_ENTRIES, CurrentUserRole) },
                { "ActionManageAlerts", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_ALERTS, CurrentUserRole) },
                { "ActionViewAlerts", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_ALERTS, CurrentUserRole) },

                //Organisation
                { "ActionManageContacts", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_CONTACTS, CurrentUserRole) },
                { "ActionSearchContacts", _appRoleActionAccessService.CanAccess(Parameters.Action.SEARCH_CONTACTS, CurrentUserRole) },
                { "ActionViewContacts", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_CONTACTS, CurrentUserRole) },
                { "ActionManageMechanics", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_MECHANICS, CurrentUserRole) },
                { "ActionSearchMechanics", _appRoleActionAccessService.CanAccess(Parameters.Action.SEARCH_MECHANICS, CurrentUserRole) },
                { "ActionViewMechanics", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_MECHANICS, CurrentUserRole) },
                { "ActionManageBusinessUnits", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_BUSINESS_UNITS, CurrentUserRole) },
                { "ActionSearchBusinessUnits", _appRoleActionAccessService.CanAccess(Parameters.Action.SEARCH_BUSINESS_UNITS, CurrentUserRole) },
                { "ActionViewBusinessUnits", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_BUSINESS_UNITS, CurrentUserRole) },
                { "ActionManageBusinessGroups", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_BUSINESS_GROUPS, CurrentUserRole) },
                { "ActionViewBusinessGroups", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_BUSINESS_GROUPS, CurrentUserRole) },
                { "ActionSearchBusinessGroups", _appRoleActionAccessService.CanAccess(Parameters.Action.SEARCH_BUSINESS_GROUPS, CurrentUserRole) },
                { "ActionManageRegions", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_REGIONS, CurrentUserRole) },
                { "ActionSearchRegions", _appRoleActionAccessService.CanAccess(Parameters.Action.SEARCH_REGIONS, CurrentUserRole) },
                { "ActionViewRegions", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_REGIONS, CurrentUserRole) },
                { "ActionManageCenters", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_CENTRES, CurrentUserRole) },
                { "ActionSearchCenters", _appRoleActionAccessService.CanAccess(Parameters.Action.SEARCH_CENTRES, CurrentUserRole) },
                { "ActionViewCenters", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_CENTRES, CurrentUserRole) },
                { "ActionManageClientInformation", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_CLIENT_INFORMATION, CurrentUserRole) },

                //Parameters
                { "ActionManageUserDefinedCodes", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_USER_DEFINED_CODES, CurrentUserRole) },
                { "ActionViewUserDefinedCodes", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_USER_DEFINE_CODES, CurrentUserRole) },
                { "ActionManageVehicleTypes", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_VEHICLE_TYPES, CurrentUserRole) },
                { "ActionViewVehicleTypes", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_VEHICLE_TYPES, CurrentUserRole) },
                { "ActionSearchVehicleTypes", _appRoleActionAccessService.CanAccess(Parameters.Action.SEARCH_VEHICLE_TYPES, CurrentUserRole) },
                { "ActionManageVehicleModel", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_VEHICLE_MODEL, CurrentUserRole) },
                { "ActionViewVehicleModel", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_VEHICLE_MODEL, CurrentUserRole) },
                { "ActionSearchVehicleModel", _appRoleActionAccessService.CanAccess(Parameters.Action.SEARCH_VEHICLE_MODEL, CurrentUserRole) },

                //Security
                { "ActionManageUserInformation", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_USER_INFORMATION, CurrentUserRole) },
                { "ActionViewUserInformation", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_USER_INFORMATION, CurrentUserRole) },
                { "ActionManageCenterSecurity", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_CENTRE_SECURITY, CurrentUserRole) },
                { "ActionViewCenterSecurity", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_CENTRE_SECURITY, CurrentUserRole) },
                { "ActionManageAudit", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_AUDIT, CurrentUserRole) },
                { "ActionViewAudit", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_AUDIT, CurrentUserRole) },
                { "ActionSearchAudit", _appRoleActionAccessService.CanAccess(Parameters.Action.SEARCH_AUDIT, CurrentUserRole) },
                { "ActionManageRole", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_ROLE, CurrentUserRole) },
                { "ActionManagePermission", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_PERMISSION, CurrentUserRole) },

                //Vehicle Management
                { "ActionUpdateVehicleRegistry", _appRoleActionAccessService.CanAccess(Parameters.Action.UPDATE_VEHICLE_REGISTRY, CurrentUserRole) },
                { "ActionDisposeVehicle", _appRoleActionAccessService.CanAccess(Parameters.Action.DISPOSE_VEHICLE, CurrentUserRole) },
                { "ActionSetupNewVehicle", _appRoleActionAccessService.CanAccess(Parameters.Action.SETUP_NEW_VEHICLE, CurrentUserRole) },
                { "ActionSetVehicleExpiryDates", _appRoleActionAccessService.CanAccess(Parameters.Action.SET_VEHICLE_EXPIRY_DATES, CurrentUserRole) },
                { "ActionViewDisposedVehicles", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_DISPOSED_VEHICLES, CurrentUserRole) },
                { "ActionViewBOSVehicles", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_BOS_VEHICLES, CurrentUserRole) },
                { "ActionViewVehicles", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_VEHICLES, CurrentUserRole) },

                //Vehicle Allocation
                { "ActionManageVehicleAllocation", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_VEHICLE_ALLOCATION, CurrentUserRole) },
                { "ActionTransferVehicle", _appRoleActionAccessService.CanAccess(Parameters.Action.TRANSFER_VEHICLE, CurrentUserRole) },

                //Service
                { "ActionManageVehicleService", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_SERVICE_OF_VEHICLES, CurrentUserRole) },
                { "ActionViewVehicleService", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_SERVICE_OF_VEHICLES, CurrentUserRole) },
                { "ActionManageScheduleService", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_SCHEDULE_SERVICE, CurrentUserRole) },
                { "ActionViewScheduleService", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_SCHEDULE_SERVICE, CurrentUserRole) },

                //Incident
                { "ActionManageIncidents", _appRoleActionAccessService.CanAccess(Parameters.Action.MANAGE_INCIDENTS, CurrentUserRole) },
                { "ActionViewIncidents", _appRoleActionAccessService.CanAccess(Parameters.Action.VIEW_INCIDENTS, CurrentUserRole) },

                //Reports                 
                { "ActionRunVehicleInformationReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_VEHICLE_INFORMATION_REPORT, CurrentUserRole) },
                { "ActionRunVehicleAcquisitionReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_VEHICLE_ACQUISITION_REPORT, CurrentUserRole) },
                { "ActionRunDisposedVehicleListingReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_DISPOSED_VEHICLE_LISTING, CurrentUserRole) },
                { "ActionRunServiceDetailsReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_SERVICE_DETAILS_REPORT, CurrentUserRole) },
                { "ActionRunVehicleScheduleServiceReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_VEHICLE_SCHEDULE_SERVICE, CurrentUserRole) },
                { "ActionRunBowserDailyUsageReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_BOWSER_DAILY_USAGE, CurrentUserRole) },
                { "ActionRunBowserFuelStatusReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_BOWSER_FUEL_STATUS, CurrentUserRole) },
                { "ActionRunMonthlyVehicleFuelConsumptionReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_MONTHLY_VEHICLE_FUEL_CONSUMPTION, CurrentUserRole) },
                { "ActionRunAllocatedVehicleReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_ALLOCATED_VEHICLE_REPORT, CurrentUserRole) },
                { "ActionRunUnallocatedVehicleReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_UNALLOCATED_VEHICLE_REPORT, CurrentUserRole) },
                { "ActionRunVehicleHistoryDetailReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_VEHICLE_HISTORY_DETAIL_REPORT, CurrentUserRole) },
                { "ActionRunRegistrationExpiryReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_REGISTRATION_EXPIRY, CurrentUserRole) },
                { "ActionRunSafetyStickerExpiryReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_SAFETY_STICKER_EXPIRY, CurrentUserRole) },
                { "ActionRunScheduleServiceDueNoticeReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_SCHEDULE_SERVICE_DUE_NOTICE, CurrentUserRole) },
                { "ActionRunDriverServiceExpiryNoticeReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_DRIVER_SERVICE_EXPIRY_NOTICE, CurrentUserRole) },
                { "ActionRunIncidentStatusReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_INCIDENT_STATUS, CurrentUserRole) },
                { "ActionRunUserReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_USER_REPORT, CurrentUserRole) },
                { "ActionRunCenterReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_CENTRE_REPORT, CurrentUserRole) },
                { "ActionRunBusinessGroupReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_BUSINESS_GROUP_REPORT, CurrentUserRole) },
                { "ActionRunVehicleTypeReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_VEHICLE_TYPE_REPORT, CurrentUserRole) },
                { "ActionRunComplianceMonthlySummaryReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_COMPLIANCE_MONTHLY_SUMMARY, CurrentUserRole) },
                { "ActionRunServiceMonthlySummaryReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_SERVICE_MONTHLY_SUMMARY, CurrentUserRole) },
                { "ActionRunDriverInformationReport", _appRoleActionAccessService.CanAccess(Parameters.Action.RUN_DRIVER_INFORMATION_REPORT, CurrentUserRole) }
            };

            Session[CurrentUserRole + "UIVisibilityList"] = UIVisibilityList;

            Session["CurrentUserRole"] = CurrentUserRole;
           
        }
        #endregion

    }
}