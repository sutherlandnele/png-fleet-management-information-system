using FMS.Data.Configuration;
using System.Data.Entity;
using FMS.Model;

namespace FMS.Data
{
    //public class FMSEntities : IdentityDbContext<AppUser>
    public class FMSEntities : DbContext

    {
        public FMSEntities()
              : base()
        {
        }


        #region EF Dbset defintions
        public DbSet<AppAction> AppActions { get; set; }
        public DbSet<AppInterface> AppInterfaces { get; set; }
        public DbSet<AppMenu> AppMenus { get; set; }
        public DbSet<AppRoleActionAccess> AppRoleActionAccesses { get; set; }
        public DbSet<AppRoleInterfaceAccess> AppRoleInterfaceAccesses { get; set; }
        public DbSet<AppRoleMenuAccess> AppRoleMenuAccesses { get; set; }
        public DbSet<BusinessGroup> BusinessGroups { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<ClientInformation> ClientInformations { get; set; }
        public DbSet<Compliance> Compliances { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<DepotRefuel> DepotRefuels { get; set; }
        public DbSet<DepotTank> DepotTanks { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<FuelVoucher> FuelVouchers { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentFileUpload> IncidentFileUploads { get; set; }
        public DbSet<FMS.Model.Model> Models { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Regional> Regionals { get; set; }
        public DbSet<ScheduleService> ScheduleServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SqlAudit> SqlAudits { get; set; }
        public DbSet<SystemParameterCode> SystemParameterCodes { get; set; }
        public DbSet<SystemParameter> SystemParameters { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDisposal> VehicleDisposals { get; set; }
        public DbSet<VehicleRefuel> VehicleRefuels { get; set; }
        public DbSet<VehicleTransfer> MVehicleTransfers { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<AppLock> AppLock { get; set; }
        public DbSet<AppObject> AppObject { get; set; }
        public DbSet<AppSet> AppSet { get; set; }
        public DbSet<AppString> AppString { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<AppIssue> AppIssues { get; set; }
        public DbSet<BusinessGroupSecurity> BusinessGroupSecurities { get; set; }
        public DbSet<CenterSecurity> CenterSecurities { get; set; }
        public DbSet<DepotDailyMeasurement> DepotDailyMeasurements { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<VehicleAllocation> VehicleAllocations { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ExternalLogin> Logins { get; set; }
        public DbSet<Claim> Claims { get; set; }

        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());
            modelBuilder.Configurations.Add(new AppActionConfiguration());
            modelBuilder.Configurations.Add(new AppIssueConfiguration());
            modelBuilder.Configurations.Add(new AppInterfaceConfiguration());
            modelBuilder.Configurations.Add(new AppMenuConfiguration());
            modelBuilder.Configurations.Add(new AppRoleActionAccessConfiguration());
            modelBuilder.Configurations.Add(new AppRoleInterfaceAccessConfiguration());
            modelBuilder.Configurations.Add(new AppRoleMenuAccessConfiguration());
            modelBuilder.Configurations.Add(new BusinessGroupConfiguration());
            modelBuilder.Configurations.Add(new BusinessUnitConfiguration());
            modelBuilder.Configurations.Add(new CenterConfiguration());
            modelBuilder.Configurations.Add(new ClientInformationConfiguration());
            modelBuilder.Configurations.Add(new ComplianceConfiguration());
            modelBuilder.Configurations.Add(new ContactDetailConfiguration());
            modelBuilder.Configurations.Add(new DashboardConfiguration());
            modelBuilder.Configurations.Add(new DepotRefuelConfiguration());
            modelBuilder.Configurations.Add(new DepotTankConfiguration());
            modelBuilder.Configurations.Add(new EmailTemplateConfiguration());
            modelBuilder.Configurations.Add(new FuelVoucherConfiguration());
            modelBuilder.Configurations.Add(new IncidentConfiguration());
            modelBuilder.Configurations.Add(new IncidentFileUploadConfiguration());
            modelBuilder.Configurations.Add(new ModelConfiguration());
            modelBuilder.Configurations.Add(new OperatorConfiguration());
            modelBuilder.Configurations.Add(new RegionalConfiguration());
            modelBuilder.Configurations.Add(new ScheduleServiceConfiguration());
            modelBuilder.Configurations.Add(new ServiceConfiguration());
            modelBuilder.Configurations.Add(new SqlAuditConfiguration());
            modelBuilder.Configurations.Add(new SystemParameterCodeConfiguration());
            modelBuilder.Configurations.Add(new SystemParameterConfiguration());
            modelBuilder.Configurations.Add(new VehicleConfiguration());
            modelBuilder.Configurations.Add(new VehicleDisposalConfiguration());
            modelBuilder.Configurations.Add(new VehicleRefuelConfiguration());
            modelBuilder.Configurations.Add(new VehicleTransferConfiguration());
            modelBuilder.Configurations.Add(new VehicleTypeConfiguration());
            modelBuilder.Configurations.Add(new AlertConfiguration());
            modelBuilder.Configurations.Add(new BusinessGroupSecurityConfiguration());
            modelBuilder.Configurations.Add(new CenterSecurityConfiguration());
            modelBuilder.Configurations.Add(new DepotDailyMeasurementConfiguration());
            modelBuilder.Configurations.Add(new NotificationConfiguration());
            modelBuilder.Configurations.Add(new VehicleAllocationConfiguration());
            modelBuilder.Configurations.Add(new AppLockConfiguration());
            modelBuilder.Configurations.Add(new AppObjectConfiguration());
            modelBuilder.Configurations.Add(new AppSetConfiguration());
            modelBuilder.Configurations.Add(new AppStringConfiguration());
            modelBuilder.Configurations.Add(new UserContactConfiguration());

        }

        
    }
}
