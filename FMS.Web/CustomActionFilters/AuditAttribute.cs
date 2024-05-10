using System;
using System.Web.Mvc;
using FMS.Service;
using FMS.Model;
using FMS.Common;
using Microsoft.AspNet.Identity;
using FMS.Web.Identity;


namespace FMS.Web.CustomActionFilters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class AuditAttribute : ActionFilterAttribute
    {
        private readonly Parameters.Action _databaseAction;
        private readonly Parameters.SubSystem _subSystem;
        private readonly Parameters.Table _table;

        //automatically initialized by Autofac DI ->> builder.RegisterFilterProvider();
        public IAuditingService _auditingService { get; set; }
        public UserManager<IdentityUser, Guid> _userManager { get; set; }
               
        public AuditAttribute(Parameters.Action action
            ,Parameters.SubSystem subSystem
            ,Parameters.Table table)
        {
            
            _databaseAction = action;
            _subSystem = subSystem;
            _table = table;
        }


        /// OnActionExecuted -->> Occurs after action execution
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Stores the Request in an Accessible object  
            var request = filterContext.HttpContext.Request;
            var username = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous";

            var user = _userManager.FindByName(username);

            SqlAudit audit = new SqlAudit()
            {
                ComputerName = request.UserHostAddress,
                Username = username,
                DateAndTime = DateTime.Now,
                Role = username=="Anonymous" ? "" : string.Join(", ", _userManager.GetRoles(user.Id)),
                DatabaseAction = _databaseAction.ToString(),
                SqlStatement = "",
                SubSystem = _subSystem.ToString(),
                DatabaseTable = _table.ToString()
            };

            _auditingService.Create(audit);
            _auditingService.Save();
        }






    }
}