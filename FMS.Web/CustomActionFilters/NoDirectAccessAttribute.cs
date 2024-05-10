using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace FMS.Web.CustomActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NoDirectAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.HttpContext.Request.RequestContext.RouteData.Values["Controller"].ToString();
            string actionName = filterContext.HttpContext.Request.RequestContext.RouteData.Values["Action"].ToString();

            if (!(controllerName.ToUpper() == "SECURITY" && actionName.ToUpper() == "LOGIN") && !(controllerName.ToUpper() == "SECURITY" && actionName.ToUpper() == "RESETPASSWORD"))
            { //prevent redirect looping

                if (filterContext.HttpContext.Request.UrlReferrer == null ||
                            filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
                {
                    filterContext.Result = new RedirectToRouteResult(new
                                   RouteValueDictionary(new { controller = "Security", action = "Login", area = "" }));
                }
            }
        }

    }
}