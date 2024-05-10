using System;
using System.Web.Mvc;
using FMS.Service;
using FMS.Model;
using FMS.Common;
using Microsoft.AspNet.Identity;
using FMS.Web.Identity;
using System.Web;
using System.Linq;
using System.Web.Routing;

namespace FMS.Web.CustomActionFilters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class UserActionAuthorizationAttribute : AuthorizeAttribute
    {
        private readonly Parameters.Action _actionName;


        //automatically initialized by Autofac DI ->> builder.RegisterFilterProvider();
        //Note: Needs to be a public property so that Autofac can access it
        public IAppRoleActionAccessService appRoleActionAccessService { get; set; }

        public UserManager<IdentityUser, Guid> _userManager { get; set; }


        public UserActionAuthorizationAttribute(Parameters.Action actionName)
        {

            _actionName = actionName;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var u = _userManager.Users.Where(m => m.UserName == httpContext.User.Identity.Name).FirstOrDefault();
            var roleName = _userManager.GetRoles(u.Id).FirstOrDefault();

            bool isAuthenticated = httpContext.Request.IsAuthenticated;

            bool isAuthorized = appRoleActionAccessService.CanAccess(_actionName, roleName);

            return isAuthenticated && isAuthorized;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {

                filterContext.HttpContext.Response.RedirectToRoute(new RouteValueDictionary
                {
                    {"controller","Security"},
                    {"action","AccessDenied" }
                });
            }
            else
            {

                filterContext.Result = new JsonResult { Data = new { message = "Access Denied! You do not have permission to perform this action.", isError = true } };
            }

        }
    }
  }

