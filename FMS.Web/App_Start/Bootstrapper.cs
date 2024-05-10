using Autofac;
using Autofac.Integration.Mvc;
using System.Linq;
using System.Reflection;
using FMS.Service;
using FMS.Data.Infrastructure;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FMS.Web.Identity;
using System;
using FMS.Web.Mappings;
using FMS.Web.Hubs;
using Microsoft.AspNet.SignalR;


namespace FMS.Web
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            #region 1. AUTOFAC FOR MVC INTEGRATION REGISTRATION

            var builder = new ContainerBuilder();

            #region Register UoW Types
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();
            #endregion

            #region Register Service Types
            builder.RegisterAssemblyTypes(typeof(VehicleManagementService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();
            #endregion


            #region Register Custom Automapper Value Resolvers        
            builder.RegisterType<ScheduleServiceExistsResolver>().InstancePerLifetimeScope();
            builder.RegisterType<DepotTankMaximumCapacityResolver>().InstancePerLifetimeScope();
            builder.RegisterType<IsAgeBOSResolver>().InstancePerLifetimeScope();
            builder.RegisterType<IsMileageBOSResolver>().InstancePerLifetimeScope();
            #endregion

            #region Regisister Identity Types
            builder.RegisterType<UserManager<IdentityUser, Guid>>().InstancePerRequest();
            builder.RegisterType<RoleManager<IdentityRole, Guid>>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserStore<IdentityUser, Guid>>().InstancePerRequest();
            builder.RegisterType<RoleStore>().As<IRoleStore<IdentityRole, Guid>>().InstancePerRequest();
            #endregion

            #region Register Controllers             
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            #endregion


            #region Register Filter Attributes
            builder.RegisterFilterProvider();
            #endregion

      
            IContainer container = builder.Build();
            AutoMapperConfiguration.Configure(container);            
            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));

            #endregion

            #region 2. AUTOFAC FOR SIGNALR INTEGRATION REGISTRATION

            var signalRBuilder = new ContainerBuilder();
            signalRBuilder.RegisterType<ComsHub>().ExternallyOwned();



            #region Regisister UoW Types
            signalRBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().ExternallyOwned();
            signalRBuilder.RegisterType<DbFactory>().As<IDbFactory>().ExternallyOwned();
            #endregion


            #region Register Service Types
            signalRBuilder.RegisterAssemblyTypes(typeof(VehicleManagementService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces()
               .ExternallyOwned();
            #endregion


            #region Regisister Identity Types
            signalRBuilder.RegisterType<UserManager<IdentityUser, Guid>>().ExternallyOwned();
            signalRBuilder.RegisterType<RoleManager<IdentityRole, Guid>>().ExternallyOwned();
            signalRBuilder.RegisterType<UserStore>().As<IUserStore<IdentityUser, Guid>>().ExternallyOwned();
            signalRBuilder.RegisterType<RoleStore>().As<IRoleStore<IdentityRole, Guid>>().ExternallyOwned();
            #endregion

            IContainer signalRContainer = signalRBuilder.Build();
            GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(signalRContainer);
            #endregion




        }


    }
}
