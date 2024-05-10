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
using FMS.Service;
using FMS.Model;

namespace FMS.Web.Controllers
{
   
    [Authorize]
    [NoDirectAccess]
    public class SecurityController : BaseController
    {
        #region 1. Private Members
        private readonly UserManager<IdentityUser, Guid> _userManager;
        private readonly RoleManager<IdentityRole,Guid> _roleManager;
        private readonly ICenterService _centerService;
        private readonly ICenterSecurityService _centerSecurityService;
        private readonly IAuditingService _auditingService;
        private readonly IAppMenuService _appMenuService;
        private readonly IAppInterfaceService _appInterfaceService;
        private readonly IAppActionService _appActionService;
        private readonly IAppRoleMenuAccessService _appRoleMenuAccessService;
        private readonly IAppRoleInterfaceAccessService _appRoleInterfaceAccessService;
        private readonly IAppRoleActionAccessService _appRoleActionAccessService;


        #endregion

        #region 2. Contructors


        public SecurityController(          
              RoleManager<IdentityRole, Guid> roleManager
            , IAppMenuService appMenuService
            , IAppInterfaceService appInterfaceService
            , IAppActionService appActionService
            , IAppRoleMenuAccessService appRoleMenuAccessService
            , IAppRoleInterfaceAccessService appRoleInterfaceAccessService
            , IAppRoleActionAccessService appRoleActionAccessService
            , ICenterSecurityService centerSecurityService           
            , IVehicleManagementService vehicleManagementService
            , IAuditingService auditingService            
            , IContactDetailService contactDetailService
            , UserManager<IdentityUser, Guid> userManager           
            , IVehicleServiceService vehicleServiceService
            , ICenterService centerService
            , IBusinessUnitService businessUnitService
            , IBusinessGroupService businessGroupService
            , IModelService modelService
            , IDepotTankService depotTankService
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
            _centerService = centerService;
            _centerSecurityService = centerSecurityService;
            _userManager = userManager;
            _roleManager = roleManager;
            _auditingService = auditingService;

            _appMenuService = appMenuService;
            _appInterfaceService = appInterfaceService;
            _appActionService = appActionService;
            _appRoleMenuAccessService = appRoleMenuAccessService;
            _appRoleInterfaceAccessService = appRoleInterfaceAccessService;
            _appRoleActionAccessService = appRoleActionAccessService;

            //enable lockouts
            _userManager.UserLockoutEnabledByDefault = true;
            _userManager.MaxFailedAccessAttemptsBeforeLockout = 5;
            _userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5); //wait 10 minutes and try again after account is locked out

            PopulateSelectListDataSources();

            //in a standard identity system the code below would be generated and sent to the user's email once
            //username is valid and confirmed by the system ->>> Two Factor Authentication
            var provider = new DpapiDataProtectionProvider("FMS");
            _userManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser, Guid>(provider.Create("FMSToken"));


        }

        #endregion

        #region 3. Actions

        #region 3.a. Get View Related Actions

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
           
            return View();
        }


        [AllowAnonymous]
        public ActionResult ResetPassword(Guid userId, string code)
        {
            var m = new PublicResetPasswordViewModel { UserId = userId, Code = code };
            return (code == null && Guid.Empty == userId) ? View("Error") : View();
        }


        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MyResetPassword(string username)
        {
            var userWithRole = (from user in _userManager.Users
                                select new
                                {
                                    Username = user.UserName,
                                    Role = (from userRole in _userManager.GetRoles(user.Id)
                                            select userRole).FirstOrDefault()
                                }).ToList().Select(p => new UserViewModel()
                                {

                                    Email = p.Username,
                                    Role = p.Role
                                }).Where(u => u.Email == username).FirstOrDefault();


            ResetPasswordViewModel vm = new ResetPasswordViewModel();
            vm.Email = userWithRole.Email;
            vm.Role = userWithRole.Role;

            return View(vm);
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.ROLE)]
        public ActionResult Roles()
        {
            return View();
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.MANAGE_USERS)]
        public ActionResult Users()
        {
            return View();
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.CENTRE_SECURITY)]
        public ActionResult CenterSecurity()
        {
            return View();
        }

    
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.AUDIT_TRAIL)]
        public ActionResult AuditTrails()
        {
            return View();
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.PERMISSION)]
        public ActionResult RolePermissions()
        {
            PopulateSelectListDataSources();

            //clear all previously store session variables
            ClearPermissionsTreeViewRoleSessions();

            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [UserInterfaceAuthorization(Parameters.Interface.PERMISSION)]
        public JsonResult GetRolePermissions(string roleName, int? id)
        {

            //initially load and store in session state to optimize performance (reduce server data request round trips)

            var tData = new List<TreeViewRolePermissionDisplayViewModel>();

            if (Session[roleName] != null)
            {
                tData = Session[roleName] as List<TreeViewRolePermissionDisplayViewModel>;                

            }
            else
            {
                tData = GetRolePermissionTreeViewData(roleName).ToList();

                Session[roleName] = tData;
            }


            var rolePermissionTreeViewModel = from t in tData
                                              where (id.HasValue ? t.ParentId == id : t.ParentId == null)
                                                select new TreeViewRolePermissionDisplayViewModel
                                                {
                                                    /* Important to have the name as "id", "hasChildren" and "@checked" as they are properties of the hieararchical model 
                                                    * and need to have these exact names so that they map correctly to the kendoTreeView widget */
                                                    id = t.id, 
                                                    Name = t.Name,
                                                    hasChildren = t.hasChildren,
                                                    @checked = t.@checked,
                                                    RolePermissionType = t.RolePermissionType,
                                                    RoleName = t.RoleName,
                                                    ParentId = t.ParentId
                                                };

                return Json(rolePermissionTreeViewModel, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region 3.b. Get List of Values Related Actions
        #endregion

        #region 3.c. Grid Related Actions

        #region 3.c.1 Role
        public ActionResult GetRolesList([DataSourceRequest] DataSourceRequest request)
        {
            var roles = _roleManager.Roles.ToList();

            var vm = Mapper.Map<IEnumerable<IdentityRole>, IEnumerable<RoleViewModel>>(roles);

            return Json(vm.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateRoleDetails([DataSourceRequest] DataSourceRequest request, RoleViewModel roleViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_ROLE))
            {
                if (roleViewModel != null && ModelState.IsValid)
                {
                    var role = new IdentityRole() { Name = roleViewModel.Name };
                    var result = _roleManager.Create(role);

                    if (!result.Succeeded)
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { roleViewModel }.ToDataSourceResult(request, ModelState));

        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditRoleDetails([DataSourceRequest] DataSourceRequest request, RoleViewModel roleViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_ROLE))
            {

                if (roleViewModel != null && ModelState.IsValid)
                {

                    var role = _roleManager.FindById(roleViewModel.Id);

                    var result = _roleManager.Update(role);

                    if (!result.Succeeded)
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { roleViewModel }.ToDataSourceResult(request, ModelState));

        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteRoleDetails([DataSourceRequest] DataSourceRequest request, RoleViewModel roleViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_ROLE))
            {
                if (roleViewModel != null && ModelState.IsValid)
                {
                    var role = _roleManager.FindById(roleViewModel.Id);
                    bool canDelete = true;

                    foreach (var u in _userManager.Users)
                    {
                        if (_userManager.IsInRole(u.Id, roleViewModel.Name))
                        {
                            canDelete = false;
                            break;
                        }
                    }

                    if (canDelete)
                    {
                        var result = _roleManager.Delete(role);

                        if (!result.Succeeded)
                        {
                            AddErrors(result);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "There are existing users in this role. Role cannot be deleted.");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { roleViewModel }.ToDataSourceResult(request, ModelState));

        }

        #endregion

        #region 3.c.2 User

        public ActionResult Users_Grid_Read([DataSourceRequest] DataSourceRequest request, string username)
        {           

           ///Note: Inital application design is such that one user is mapped to only one identity role so this is followed, instead of the 
           ///the standard design where one user can have many identity roles. This is becasue initial application design has it's own internal 
           ///authorization scheme through permissable app interfaces, menu and actions

            var usersWithRoles = (from user in _userManager.Users
                                  select new
                                  {                                     
                                      Username = user.UserName,                                      
                                      Role = (from userRole in _userManager.GetRoles(user.Id)                                                  
                                                   select userRole).FirstOrDefault(),
                                      LastLoginTime = user.LastLoginTime,
                                      LockOutEndDateUtc = user.LockoutEndDateUtc
                                  }).ToList().Select(p => new UserViewModel()
                                  {                                  
     
                                      Email = p.Username,
                                      Role  =  p.Role,
                                      LastLoginTime = p.LastLoginTime,
                                      IsLockedOut = (DateTime.Compare((p.LockOutEndDateUtc??DateTime.UtcNow.AddDays(-1)),DateTime.UtcNow) > 0)
                                      
                                  });
            
            if (!string.IsNullOrEmpty(username))
            {
                usersWithRoles = usersWithRoles.Where(u => u.Email.ToUpper().Contains(username.ToUpper()));
            } 

            return Json(usersWithRoles.ToDataSourceResult(request));
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Grid_Update([DataSourceRequest] DataSourceRequest request, UserViewModel userViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_USER_INFORMATION))
            {
                //remove these from ModelState because when the password reset option is not performed, these values would be null and make
                //thus render the ModelState invalid
                ModelState.Remove("Password");
                ModelState.Remove("ConfirmPassword");

                if (userViewModel != null && ModelState.IsValid)
                {
                    var user = _userManager.FindByName(userViewModel.Email);

                    if (user != null)
                    {
                        //1. Check and Update user role
                        if (!string.IsNullOrEmpty(userViewModel.Role))
                        {
                            //remove all existing roles and add new role
                            var resultRemoveRoles = _userManager.RemoveFromRoles(user.Id, _userManager.GetRoles(user.Id).ToArray());

                            var resultAddRole = _userManager.AddToRole(user.Id, userViewModel.Role);

                            if (!resultRemoveRoles.Succeeded)
                            {
                                AddErrors(resultRemoveRoles);
                            }

                            if (!resultAddRole.Succeeded)
                            {
                                AddErrors(resultAddRole);
                            }

                        }


                        //2. check if password reset is required and reset password
                        if (!string.IsNullOrEmpty(userViewModel.Password))
                        {
                            ////in a standard identity system the code below would be generated and sent to the user's email once
                            ////username is valid and confirmed by the system ->>> Two Factor Authentication
                            //var provider = new DpapiDataProtectionProvider("FMS");
                            //_userManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser, Guid>(provider.Create("FMSToken"));

                            string code = _userManager.GeneratePasswordResetToken(user.Id);

                            var resultResetPwd = _userManager.ResetPassword(user.Id, code, userViewModel.Password);

                            if (!resultResetPwd.Succeeded)
                            {
                                AddErrors(resultResetPwd);
                            }

                        }
                    }


                }

                userViewModel.Password = "";
                userViewModel.ConfirmPassword = "";
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { userViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Grid_Create([DataSourceRequest] DataSourceRequest request, UserViewModel userViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_USER_INFORMATION))
            {
                if (userViewModel != null && ModelState.IsValid)
                {

                    //1. Create new user
                    var user = new IdentityUser() { UserName = userViewModel.Email, RegistrationDate = DateTime.Now };

                    var result = _userManager.Create(user, userViewModel.Password);



                    if (!result.Succeeded)
                    {
                        AddErrors(result);
                    }
                    else
                    {
                        //2. Add role for new user
                        var createdUser = _userManager.FindByName(userViewModel.Email);

                        if (!string.IsNullOrEmpty(userViewModel.Role))
                        {
                            var resultAddRole = _userManager.AddToRole(createdUser.Id, userViewModel.Role);

                            if (!resultAddRole.Succeeded)
                            {
                                AddErrors(resultAddRole);
                            }

                            var callbackUrl = string.Format("{0}://{1}", Request.Url.Scheme, Request.Url.Authority);

                       
                            var r = SendNewUserCreatedEmail(createdUser.UserName, userViewModel.Password, userViewModel.Role, callbackUrl);
                           

                        }
                    }

                }

                userViewModel.Password = "";
                userViewModel.ConfirmPassword = "";
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { userViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult User_Grid_Destroy([DataSourceRequest] DataSourceRequest request, UserViewModel userViewModel)
        {
            if (UserIsAuthorizedForGridAction(Parameters.Action.MANAGE_USER_INFORMATION))
            {
                ModelState.Remove("Password");
                ModelState.Remove("ConfirmPassword");

                if (userViewModel != null && ModelState.IsValid)
                {
                    var user = _userManager.FindByName(userViewModel.Email);

                    if (user != null)
                    {
                        var result = _userManager.Delete(user);

                        if (!result.Succeeded)
                        {
                            AddErrors(result);
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Access Denied! You do not have permission to perform this action.");
            }

            return Json(new[] { userViewModel }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region 3.c.3 Center Security
        public ActionResult GetCenterSecurityList([DataSourceRequest] DataSourceRequest request, string username)
        {
            var centers = _centerService.GetAll();

            var userCenterSecurities = (from  c in centers
                                      select new CenterSecurityViewModel
                                      {
                                          Center = c.Name,
                                          CenterId = c.CenterNumber,
                                          UserId = username,
                                          HasAccess = _centerSecurityService.CenterSecurityExists(username,c.CenterNumber)
                                      }).OrderBy(v=>v.Center);

            return Json(userCenterSecurities.ToDataSourceResult(request));
        }

        #endregion

        #region 3.c.4 Audit Trail
        public ActionResult GetSqlAuditList([DataSourceRequest] DataSourceRequest request, DateTime? startDate, DateTime? endDate)
        {
            var m = _auditingService.GetAll(startDate,endDate);
            var v = Mapper.Map<IEnumerable<SqlAudit>, IEnumerable<SqlAuditViewModel>>(m);

            return Json(v.ToDataSourceResult(request));
        }

        #endregion


        #endregion

        #region 3.d. Form CRUD Post Related Actions

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_AUDIT)]
        public ActionResult PurgeAll(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var m = _auditingService.GetAll(startDate, endDate);

                foreach (var a in m)
                {
                    _auditingService.Delete(a);
                    _auditingService.Save();
                }

                return Json(new { message = "All audit trails purged successfully.", isError = false });

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

        #region 3.e. Other Post Related Actions

        #region 3.e.1 User Account Related
        [HttpPost]        
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MyResetPassword(ResetPasswordViewModel entityViewModel)
        {

            if (entityViewModel != null && ModelState.IsValid)
            {
                try
                {
                    var user = _userManager.FindByName(entityViewModel.Email);
                    
                    if (user != null)
                    {

                        //in a standard identity system the code below would be generated and sent to the user's email once
                        //username is valid and confirmed by the system ->>> Two Factor Authentication
                        //var provider = new DpapiDataProtectionProvider("FMS");
                        //_userManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser, Guid>(provider.Create("FMSToken"));

                        string code = _userManager.GeneratePasswordResetToken(user.Id);
                        IdentityResult resultResetPwd = await _userManager.ResetPasswordAsync(user.Id, code, entityViewModel.Password);

                        if (!resultResetPwd.Succeeded)
                        {

                            string errors = string.Join(", ", resultResetPwd.Errors);
                            return Json(new { message = errors, isError = true });
                        }

                        return Json(new { message = "Password reset successful.", isError = false });
                    }
                    else
                    {

                        return Json(new { message = "User does not exist.", isError = true });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { message = ex.Message , isError = true });
                }
            }
            else
            {
                return Json(new { message = "The ModelState is invalid or the ViewModel is null.", isError = true });
            }

          
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_USER_INFORMATION)]
        public async Task<ActionResult> UnlockUser(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                try
                {
                    var user = _userManager.FindByName(username);

                    if (user != null)
                    {
                        
                        if(_userManager.IsLockedOut(user.Id))
                        {
                            //set the lockout end utc end date 1 minute in the past to unlock the account
                           

                            var lockOutResult = await _userManager.SetLockoutEndDateAsync(user.Id, DateTimeOffset.Now.AddMinutes(-1));

                            if(lockOutResult.Succeeded)
                            {
                                //reset the failed access count back to 0
                                var resetFailedAccessCount = await _userManager.ResetAccessFailedCountAsync(user.Id);

                                if (!resetFailedAccessCount.Succeeded)
                                {
                                    AddErrors(resetFailedAccessCount);
                                }

                                return Json(new { message = "Account unlocked successfully.", isError = false });
                            }
                            else
                            {
                                AddErrors(lockOutResult);
                                return Json(new { message = "Account could not be unlocked.", isError = true });
                            }


                        }
                        else
                        {
                            return Json(new { message = "User is no longer locked out.", isError = false });
                        }             


                    }
                    else
                    {

                        return Json(new { message = "User does not exist.", isError = true });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { message = ex.Message, isError = true });
                }
            }
            else
            {
                return Json(new { message = "Username is null or empty.", isError = true });
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_USER_INFORMATION)]
        public async Task<ActionResult> DisableUser(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                try
                {
                    var user = _userManager.FindByName(username);

                    if (user != null)
                    {
                            
                            var lockOutResult = await _userManager.SetLockoutEndDateAsync(user.Id, DateTimeOffset.Now.AddYears(200));

                            if (lockOutResult.Succeeded)
                            {
                                //reset the failed access count back to 0
                                var resetFailedAccessCount = await _userManager.ResetAccessFailedCountAsync(user.Id);

                                if (!resetFailedAccessCount.Succeeded)
                                {
                                    AddErrors(resetFailedAccessCount);
                                }

                                return Json(new { message = "Account disabled successfully.", isError = false });
                            }
                            else
                            {
                                AddErrors(lockOutResult);
                                return Json(new { message = "Account could not be disabled.", isError = true });
                            }
                    }
                    else
                    {

                        return Json(new { message = "User does not exist.", isError = true });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { message = ex.Message, isError = true });
                }
            }
            else
            {
                return Json(new { message = "Username is null or empty.", isError = true });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(model.Email);

                if (user != null)
                {

                    if (_userManager.IsLockedOut(user.Id)) //...check if user account is locked/disabled
                    {
                        var minutes = Math.Round(((DateTime)user.LockoutEndDateUtc).Subtract(DateTime.UtcNow).TotalMinutes, 2);

                        if (minutes <= _userManager.DefaultAccountLockoutTimeSpan.TotalMinutes)
                        {
                            ModelState.AddModelError("", "Your account is currently locked out. Please contact the system admin or wait " + minutes + " minutes and try again.");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Your account is currently disabled. Please contact the system admin to enable it.");
                        }
                    }
                    else //...account is not disabled. carrying on authenticating user
                    {
                        user = await _userManager.FindAsync(model.Email, model.Password);

                        if (user != null) //...valid username and password combination provided - user exists
                        {

                            await SignInAsync(user, model.RememberMe);

                            //reset the failed count
                            var resultResetAccessFailedCount = _userManager.ResetAccessFailedCount(user.Id);

                            if (!resultResetAccessFailedCount.Succeeded)
                            {
                                AddErrors(resultResetAccessFailedCount);
                            }

                            //update last login date
                            user.LastLoginTime = DateTime.Now;
                            var result = await _userManager.UpdateAsync(user);

                            if (!result.Succeeded)
                            {
                                AddErrors(result);
                            }

                            //add SignalR authentication
                            //FormsAuthentication.SetAuthCookie(user.UserName, true);

                            if (string.IsNullOrEmpty(returnUrl) || returnUrl.ToUpper().Contains("LOGOFF"))
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                return RedirectToLocal(returnUrl);
                            }
                        }
                        else
                        {
                            //get the failed login user
                            var failedUser = await _userManager.FindByNameAsync(model.Email);

                            //increment access failed count of failed login user
                            var result = await _userManager.AccessFailedAsync(failedUser.Id);

                            if (!result.Succeeded)
                            {
                                AddErrors(result);
                            }

                            ModelState.AddModelError("", "Invalid username or password.");
                        }
                    }
                }


            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = model.Email, LastLoginTime = DateTime.Now };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    await SignInAsync(user, isPersistent: false);

                    var userToUpdate = await _userManager.FindByNameAsync(user.UserName);

                    //update last login date
                    userToUpdate.LastLoginTime = DateTime.Now;
                    var resultLastLogin = await _userManager.UpdateAsync(user);

                    if (resultLastLogin.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        AddErrors(result);
                    }
                   
                    
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            Session.Clear();

            return RedirectToAction("Login", "Security");
        }

        #endregion

        #region 3.e.2 Center Security
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_CENTRE_SECURITY)]
        public ActionResult GrantCenterAccess(string username, int centerId)
        {
            if (!string.IsNullOrEmpty(username) && centerId > 0)
            {
                try
                {

                    if (_centerSecurityService.CenterSecurityExists(username,centerId))
                    {
                        return Json(new { message = "User already has access to center", isError = true });
                    }
                    else
                    {
                        var centerSecurity = new CenterSecurity {Id=0, CenterId = centerId, UserId = username };

                        _centerSecurityService.Create(centerSecurity);
                        _centerSecurityService.Save();

                        CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.Center, Parameters.Table.CenterSecurity);


                        return Json(new { message = "Center access granted to user successfully.", isError = false });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { message = ex.Message, isError = true });
                }
            }
            else
            {
                return Json(new { message = "Username or Center Id is null or empty.", isError = true });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_CENTRE_SECURITY)]
        public ActionResult GrantAllCenterAccess(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                try
                {

                    foreach(var c in _centerService.GetAll())
                    {
                        if (!_centerSecurityService.CenterSecurityExists(username, c.CenterNumber))
                        {
                            var centerSecurity = new CenterSecurity { Id = 0, CenterId = c.CenterNumber, UserId = username };

                            _centerSecurityService.Create(centerSecurity);
                            _centerSecurityService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.Center, Parameters.Table.CenterSecurity);
                        }

                    }                    


                    return Json(new { message = "Access to all centers granted to user successfully.", isError = false });

                }
                catch (Exception ex)
                {
                    return Json(new { message = ex.Message, isError = true });
                }
            }
            else
            {
                return Json(new { message = "Username is null or empty.", isError = true });
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_CENTRE_SECURITY)]
        public ActionResult RevokeCenterAccess(string username, int centerId)
        {
            if (!string.IsNullOrEmpty(username) && centerId > 0)
            {
                try
                {

                    if (!_centerSecurityService.CenterSecurityExists(username, centerId))
                    {
                        return Json(new { message = "Center access for user does not exist", isError = true });
                    }
                    else
                    {
                        var centerSecurity = _centerSecurityService.GetByUserName(username,centerId);

                        _centerSecurityService.Delete(centerSecurity);
                        _centerSecurityService.Save();

                        CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.Center, Parameters.Table.CenterSecurity);


                        return Json(new { message = "Center access for user revoked successfully.", isError = false });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { message = ex.Message, isError = true });
                }
            }
            else
            {
                return Json(new { message = "Username or Center Id is null or empty.", isError = true });
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_CENTRE_SECURITY)]
        public ActionResult RevokeAllCenterAccess(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                try
                {

                    foreach (var c in _centerService.GetAll())
                    {
                        if (_centerSecurityService.CenterSecurityExists(username, c.CenterNumber))
                        {
                            var centerSecurity = _centerSecurityService.GetByUserName(username, c.CenterNumber);

                            _centerSecurityService.Delete(centerSecurity);
                            _centerSecurityService.Save();

                            CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.Center, Parameters.Table.CenterSecurity);
                        }

                    }


                    return Json(new { message = "Access to all centers for user revoked successfully.", isError = false });

                }
                catch (Exception ex)
                {
                    return Json(new { message = ex.Message, isError = true });
                }
            }
            else
            {
                return Json(new { message = "Username is null or empty.", isError = true });
            }
        }


        #endregion

        #region 3.e.3 Role Permissions
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserActionAuthorization(Parameters.Action.MANAGE_PERMISSION)]
        public ActionResult UpdateRolePermissions(IEnumerable<TreeViewRolePermissionDisplayViewModel> rolePermissions)
        {
            if (rolePermissions != null)
            {
                try
                {

                    foreach(var r in rolePermissions)
                    {
                        if (r.id > 0)
                        {
                            switch (r.RolePermissionType)
                            {
                                case Parameters.RolePermissionType.Menu:
                                    _appRoleMenuAccessService.ChangeStatus((int)r.id - 1000, (bool)r.@checked, r.RoleName);
                                    CreatePermissionsUpdateAuditTrail((bool)r.@checked);
                                    break;

                                case Parameters.RolePermissionType.Interface:
                                    _appRoleInterfaceAccessService.ChangeStatus((int)r.id - 2000, (bool)r.@checked, r.RoleName);
                                    CreatePermissionsUpdateAuditTrail((bool)r.@checked);
                                    break;
                                case Parameters.RolePermissionType.Action:
                                    _appRoleActionAccessService.ChangeStatus((int)r.id - 3000, (bool)r.@checked, r.RoleName);
                                    CreatePermissionsUpdateAuditTrail((bool)r.@checked);
                                    break;
                                default:
                                    break;
                            }
                        }

                    }

                    //Clear stored permissions session data for role
                    if (Session[rolePermissions.ToList()[0].RoleName] != null)
                    {
                        Session.Remove(rolePermissions.ToList()[0].RoleName);

                    }
                    
                    if (Session[rolePermissions.ToList()[0].RoleName + "UIVisibilityList"] != null)
                    {
                        Session.Remove(rolePermissions.ToList()[0].RoleName + "UIVisibilityList");                       
                    }

                    return Json(new { message = "Role permissions modified successfully.", isError = false });

                }
                catch (Exception ex)
                {
                    return Json(new { message = ex.Message, isError = true });
                }
            }
            else
            {
                return Json(new { message = "View model is null.", isError = true });
            }
        }
        #endregion

        #region 3.e.4 Forgot Password


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(PublicResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Security");
            }
            var result = await _userManager.ResetPasswordAsync(user.Id, model.Code, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Security");
            }

            AddErrors(result);
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);

                //if (user == null || !(await _userManager.IsEmailConfirmedAsync(user.Id)))
                //NB: If you using two-step authentication you need to confirm the email address. Since this is strictly
                //and on-primise system we don't need to confirm the email address
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // Send an email with this link
                 string code = await _userManager.GeneratePasswordResetTokenAsync(user.Id);
                 var callbackUrl = Url.Action("ResetPassword", "Security", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);


                //await _userManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                 await SendPasswordResetEmailAsync(model.Email,callbackUrl);
                 return RedirectToAction("ForgotPasswordConfirmation", "Security");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        #endregion

        #endregion

        #endregion

        #region 4. Protected Members

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
            }

            if (disposing && _roleManager != null)
            {
                _roleManager.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        #region 5. Private Members

        private bool SendNewUserCreatedEmail(string userEmail, string password, string role, string callBackURl)
        {
            var mailSubject = "New User Account Created";

            var logoPath = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~/Content/images/menu/app-logo.png"));

            var emailLinkButtonMarkUp = "<div>" +
                        "<!--[if mso]>" +
                        "<v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns: w='urn:schemas-microsoft-com:office:word' href='" + callBackURl + "' style='height:40px;v-text-anchor:middle;width:300px;' arcsize='10%' stroke ='f' fillcolor='#d62828'>" +
                        "<w:anchorlock />" +
                        "<center style='color:#ffffff;font-family:sans-serif;font-size:16px;font-weight:bold;'>" +
                        "Login to FMS" +
                         "</center>" +
                         "</v:roundrect>" +
                         "<![endif]-->" +
                         "<![if !mso]>" +
                         "<table cellspacing='0' cellpadding='0'><tr>" +
                         "<td align='center' width='300' height='40' bgcolor='#d62828' style ='-webkit-border-radius:5px;-moz-border-radius:5px; border-radius:5px;color:#ffffff;display:block;'>" +
                         "<a href='" + callBackURl + "' style='font-size:16px;font-weight:bold;font-family:sans-serif; text-decoration: none; line-height:40px; width:100%; display:inline-block'>" +
                         "<span style = 'color:#ffffff;'>" +
                         "Login to FMS" +
                         "</span>" +
                         "</a>" +
                         "</td>" +
                         "</tr>" +
                         "</table>" +
                         "<![endif]>" +
                         "</div>";


            var mailMessage = "<p style='background-color:#666699;padding:10px;'><img style='display: block; margin-left: auto; margin-right: auto;' src='" + logoPath + "' /></p>" +
                      "<p>Hi " + userEmail + ",</p>" +
                      "<p>Your user account has been created.</p>" +
                      "<p>Your login details are as follows:</p>"+
                      "<p>Username: <strong>" + userEmail + "</strong><br/>" + "Password: <strong>" + password + "</strong><br/>" + "Role: <strong>" + role + "</strong></p>" +
                      "Please click the button below to login to FMS.</p><br/>" + emailLinkButtonMarkUp +
                      "<p>Kind Regards,</p>" +
                      "<p>Fleet Management Team</p>";

            var result = SendUserEmail(userEmail, mailSubject, mailMessage);

            return result;
        }

        private async Task<bool> SendPasswordResetEmailAsync(string userEmail, string callBackURl)
        {
            var mailSubject = "Reset Password";

            var logoPath = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~/Content/images/menu/app-logo.png"));
      
            var emailLinkButtonMarkUp = "<div>" +
                        "<!--[if mso]>" +
                        "<v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns: w='urn:schemas-microsoft-com:office:word' href='" + callBackURl + "' style='height:40px;v-text-anchor:middle;width:300px;' arcsize='10%' stroke ='f' fillcolor='#d62828'>" +
                        "<w:anchorlock />" +
                        "<center style='color:#ffffff;font-family:sans-serif;font-size:16px;font-weight:bold;'>" +
                        "Reset Password" +
                         "</center>" +
                         "</v:roundrect>" +
                         "<![endif]-->" +
                         "<![if !mso]>" +
                         "<table cellspacing='0' cellpadding='0'><tr>" +
                         "<td align='center' width='300' height='40' bgcolor='#d62828' style ='-webkit-border-radius:5px;-moz-border-radius:5px; border-radius:5px;color:#ffffff;display:block;'>" +
                         "<a href='" + callBackURl + "' style='font-size:16px;font-weight:bold;font-family:sans-serif; text-decoration: none; line-height:40px; width:100%; display:inline-block'>" +
                         "<span style = 'color:#ffffff;'>" +
                         "Reset Password" +
                         "</span>" +
                         "</a>" +
                         "</td>" +
                         "</tr>" +
                         "</table>" +
                         "<![endif]>" +
                         "</div>";


            var mailMessage = "<p style='background-color:#666699;padding:10px;'><img style='display: block; margin-left: auto; margin-right: auto;' src='" + logoPath + "' /></p>" +
                      "<p>Hi " + userEmail + ",</p>" +
                      "<p>Please reset your password by clicking the button below.</p>" + emailLinkButtonMarkUp +
                      "<p>Kind Regards,</p>" +
                      "<p>Fleet Management Team</p>";

            var result = await SendUserEmailAsync(userEmail, mailSubject, mailMessage);

            return result;
        }

        private void PopulateSelectListDataSources()
        {
            ViewBag.Roles = _roleManager.Roles.Select(t => new { Value = t.Name, Text = t.Name }).OrderBy(m=>m.Text);
            ViewBag.Users = _userManager.Users.Select(u => new { Value = u.UserName, Text = u.UserName }).OrderBy(m => m.Text);
        }

        private void ClearPermissionsTreeViewRoleSessions()
        {
            foreach (var r in _roleManager.Roles)
            {
                if (Session[r.Name] != null)
                {
                    Session.Remove(r.Name);
                }
            }
        }

        private IEnumerable<TreeViewRolePermissionDisplayViewModel> GetRolePermissionTreeViewData(string roleName)
        {

            var allMenuItems = _appMenuService.GetAll();
            var allInterfaceItems = _appInterfaceService.GetAll();
            var allActionItems = _appActionService.GetAll();

            //var rootNode = new TreeViewRolePermissionDisplayViewModel { id = 0, RoleName = roleName, ParentId = null, Name = "SELECT ALL", hasChildren = true };
            var rolePermissionTreeView = new List<TreeViewRolePermissionDisplayViewModel>();

            foreach (var m in allMenuItems)
            {
                rolePermissionTreeView.Add(new TreeViewRolePermissionDisplayViewModel { id = m.MenuId + 1000
                    , Name = m.Description
                    , ParentId = null
                    , @checked = _appRoleMenuAccessService.CanAccess(m.MenuId,roleName)
                    , hasChildren = _appInterfaceService.GetAll().Any(x=>x.MenuId == m.MenuId)
                    , RolePermissionType = Parameters.RolePermissionType.Menu
                    , RoleName = roleName});

                foreach (var i in allInterfaceItems.Where(x=>x.MenuId == m.MenuId))
                {
                    rolePermissionTreeView.Add(new TreeViewRolePermissionDisplayViewModel { id = i.InterfaceId + 2000
                        , Name = i.Description
                        , ParentId = m.MenuId + 1000
                        , @checked = _appRoleInterfaceAccessService.CanAccess(i.InterfaceId, roleName)
                        , hasChildren = _appActionService.GetAll().Any(x => x.InterfaceId == i.InterfaceId)
                        , RolePermissionType = Parameters.RolePermissionType.Interface
                        , RoleName = roleName
                    });

                    foreach (var a in allActionItems.Where(x=>x.InterfaceId == i.InterfaceId))
                    {
                        rolePermissionTreeView.Add(new TreeViewRolePermissionDisplayViewModel { id = a.ActionId + 3000
                            , Name = a.Description
                            , ParentId = i.InterfaceId + 2000
                            , @checked = _appRoleActionAccessService.CanAccess(a.ActionId, roleName)
                            , hasChildren = false
                            , RolePermissionType = Parameters.RolePermissionType.Action
                            , RoleName = roleName
                        });
                    }

                }
            }

            return rolePermissionTreeView;
        }

        #endregion  

        #region 6. Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(IdentityUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            
            var user = _userManager.FindById(GetGuid(User.Identity.GetUserId()));
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private void CreatePermissionsUpdateAuditTrail(bool isInsert)
        {
            if (isInsert)
            {
                CreateAuditTrail(Parameters.DatabaseAction.Insert, Parameters.SubSystem.SystemParameters, Parameters.Table.RoleFunctions);
            }
            else
            {
                CreateAuditTrail(Parameters.DatabaseAction.Delete, Parameters.SubSystem.SystemParameters, Parameters.Table.RoleFunctions);
            }
        }

        private Guid GetGuid(string value)
        {
            var result = default(Guid);
            Guid.TryParse(value, out result);
            return result;
        }
        #endregion
    }
}