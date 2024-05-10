using System;
using System.Threading.Tasks;
using FMS.Data.Repositories;


namespace FMS.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {


        #region Fields
        private readonly IDbFactory _dbFactory;
        private readonly FMSEntities _appDbContext;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private IVehicleRepository _vehicleRepository;
        private ISqlAuditRepository _sqlAuditRepository;
        private ICenterSecurityRepository _centerSecurityRepository;
        private IUserContactRepository _userContactRepository;
        private ICenterRepository _centerRepository;
        private IComplianceRepository _complianceRepository;
        private IFuelVoucherRepository _fuelVoucherRepository;
        private IIncidentRepository _incidentRepository;
        private IScheduleServiceRepository _scheduleServiceRepository;
        private IVehicleDisposalRepository _vehicleDisposalRepository;
        private IVehicleRefuelRepository _vehicleRefuelRepository;
        private IVehicleTransferRepository _vehicleTransferRepository;
        private IVehicleAllocationRepository _vehicleAllocationRepository;
        private IBusinessUnitRepository _businessUnitRepository;
        private IBusinessGroupRepository _businessGroupRepository;
        private IBusinessGroupSecurityRepository _businessGroupSecurityRepository;
        private IOperatorRepository _operatorRepository;
        private IDepotTankRepository _depotTankRepository;
        private IContactDetailRepository _contactDetailRepository;
        private IServiceRepository _serviceRepository;
        private IRegionRepository _regionRepository;
        private ISystemParameterRepository _systemParameterRepository;
        private IAlertRepository _alertRepository;
        private INotificationRepository _notificationRepository;
        private IModelRepository _modelRepository;
        private IDepotDailyMeasurementRepository _depotDailyMeasurementRepository;
        private IDepotRefuelRepository _depotRefuelRepository;
        private IVehicleTypeRepository _vehicleTypeRepository;
        private IEmailTemplateRepository _emailTemplateRepository;
        private IDashboardRepository _dashboardRepository;
        private IClientInformationRepository _clientInformationRepository;
        private ISystemParameterCodeRepository _systemParameterCodeRepository;
        private IAppMenuRepository _appMenuRepository;
        private IAppInterfaceRepository _appInterfaceRepository;
        private IAppActionRepository _appActionRepository;
        private IAppRoleMenuAccessRepository _appRoleMenuAccessRepository;
        private IAppRoleInterfaceAccessRepository _appRoleInterfaceAccessRepository;
        private IAppRoleActionAccessRepository _appRoleActionAccessRepository;
        private IAppIssueRepository _appIssueRepository;


        #endregion

        #region Constructors
        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
            _appDbContext = _appDbContext ?? (_appDbContext = dbFactory.Init());
        }
        #endregion

        #region IUnitOfWork Members

        public IAppIssueRepository AppIssueRepository
        {
            get { return _appIssueRepository ?? (_appIssueRepository = new AppIssueRepository(_dbFactory)); }
        }

        public IAppMenuRepository AppMenuRepository
        {
            get { return _appMenuRepository ?? (_appMenuRepository = new AppMenuRepository(_dbFactory)); }
        }
        public IAppInterfaceRepository AppInterfaceRepository
        {
            get { return _appInterfaceRepository ?? (_appInterfaceRepository = new AppInterfaceRepository(_dbFactory)); }
        }
        public IAppActionRepository AppActionRepository
        {
            get { return _appActionRepository ?? (_appActionRepository = new AppActionRepository(_dbFactory)); }
        }
        public IAppRoleMenuAccessRepository AppRoleMenuAccessRepository
        {
            get { return _appRoleMenuAccessRepository ?? (_appRoleMenuAccessRepository = new AppRoleMenuAccessRepository(_dbFactory)); }
        }
        public IAppRoleInterfaceAccessRepository AppRoleInterfaceAccessRepository
        {
            get { return _appRoleInterfaceAccessRepository ?? (_appRoleInterfaceAccessRepository = new AppRoleInterfaceAccessRepository(_dbFactory)); }
        }
        public IAppRoleActionAccessRepository AppRoleActionAccessRepository
        {
            get { return _appRoleActionAccessRepository ?? (_appRoleActionAccessRepository = new AppRoleActionAccessRepository(_dbFactory)); }
        }
        public ISystemParameterCodeRepository SystemParameterCodeRepository
        {
            get { return _systemParameterCodeRepository ?? (_systemParameterCodeRepository = new SystemParameterCodeRepository(_dbFactory)); }
        }
        public IClientInformationRepository ClientInformationRepository 
        {
            get { return _clientInformationRepository ?? (_clientInformationRepository = new ClientInformationRepository(_dbFactory)); }
        }
        public IDashboardRepository DashboardRepository
        {
            get { return _dashboardRepository ?? (_dashboardRepository = new DashboardRepository(_dbFactory)); }
        }
        public IEmailTemplateRepository EmailTemplateRepository
        {
            get { return _emailTemplateRepository ?? (_emailTemplateRepository = new EmailTemplateRepository(_dbFactory)); }
        }
        public IVehicleTypeRepository VehicleTypeRepository {
            get { return _vehicleTypeRepository ?? (_vehicleTypeRepository = new VehicleTypeRepository(_dbFactory)); }
        }
        public IDepotDailyMeasurementRepository DepotDailyMeasurementRepository {
            get { return _depotDailyMeasurementRepository ?? (_depotDailyMeasurementRepository = new DepotDailyMeasurementRepository(_dbFactory)); }
        }
        public IDepotRefuelRepository DepotRefuelRepository {
            get { return _depotRefuelRepository ?? (_depotRefuelRepository = new DepotRefuelRepository(_dbFactory)); }
        }

        public IModelRepository ModelRepository {
            get { return _modelRepository ?? (_modelRepository = new ModelRepository(_dbFactory)); }
        }
        public INotificationRepository NotificationRepository
        {
            get { return _notificationRepository ?? (_notificationRepository = new NotificationRepository(_dbFactory)); }

        }
        public IAlertRepository AlertRepository {
            get { return _alertRepository ?? (_alertRepository = new AlertRepository(_dbFactory)); }
        }
        public ISystemParameterRepository SystemParameterRepository {
            get { return _systemParameterRepository ?? (_systemParameterRepository = new SystemParameterRepository(_dbFactory)); }
        }
        public IRegionRepository RegionRepository
        {
            get { return _regionRepository ?? (_regionRepository = new RegionRepository(_dbFactory)); }
        }
        public IServiceRepository ServiceRepository {
            get { return _serviceRepository ?? (_serviceRepository = new ServiceRepository(_dbFactory)); 
            }

        }
        public IContactDetailRepository ContactDetailRepository {
            get { return _contactDetailRepository ?? (_contactDetailRepository = new ContactDetailRepository(_dbFactory)); }

        }
        public IDepotTankRepository DepotTankRepository {
            get { return _depotTankRepository ?? (_depotTankRepository = new DepotTankRepository(_dbFactory)); }
        }
        public IBusinessGroupSecurityRepository BusinessGroupSecurityRepository {
            get { return _businessGroupSecurityRepository ?? (_businessGroupSecurityRepository = new BusinessGroupSecurityRepository(_dbFactory)); }

        }
        public IOperatorRepository OperatorRepository {
            get { return _operatorRepository ?? (_operatorRepository = new OperatorRepository(_dbFactory)); }

        }

        public IBusinessGroupRepository BusinessGroupRepository {
            get { return _businessGroupRepository ?? (_businessGroupRepository = new BusinessGroupRepository(_dbFactory)); }
        }
        public IBusinessUnitRepository BusinessUnitRepository {
            get { return _businessUnitRepository ?? (_businessUnitRepository = new BusinessUnitRepository(_dbFactory)); }
        }
        public IComplianceRepository ComplianceRepository {
            get { return _complianceRepository ?? (_complianceRepository = new ComplianceRepository(_dbFactory)); }

        }
        public IFuelVoucherRepository FuelVoucherRepository {
            get { return _fuelVoucherRepository ?? (_fuelVoucherRepository = new FuelVoucherRepository(_dbFactory)); }

        }
        public IIncidentRepository IncidentRepository {
            get { return _incidentRepository ?? (_incidentRepository = new IncidentRepository(_dbFactory)); }

        }
        public IScheduleServiceRepository ScheduleServiceRepository {
            get { return _scheduleServiceRepository ?? (_scheduleServiceRepository = new ScheduleServiceRepository(_dbFactory)); }

        }
        public IVehicleDisposalRepository VehicleDisposalRepository {

            get { return _vehicleDisposalRepository ?? (_vehicleDisposalRepository = new VehicleDisposalRepository(_dbFactory)); }

        }
        public IVehicleRefuelRepository VehicleRefuelRepository {
            get { return _vehicleRefuelRepository ?? (_vehicleRefuelRepository = new VehicleRefuelRepository(_dbFactory)); }

        }
        public IVehicleTransferRepository VehicleTransferRepository {
            get { return _vehicleTransferRepository ?? (_vehicleTransferRepository = new VehicleTransferRepository(_dbFactory)); }

        }
        public IVehicleAllocationRepository VehicleAllocationRepository {
            get { return _vehicleAllocationRepository ?? (_vehicleAllocationRepository = new VehicleAllocationRepository(_dbFactory)); }

        }
        public ICenterRepository CenterRepository {
            get { return _centerRepository ?? (_centerRepository = new CenterRepository(_dbFactory)); }

        }
        public IUserContactRepository UserContactRepository {
            get { return _userContactRepository ?? (_userContactRepository = new UserContactRepository(_dbFactory)); }

        }
        public ICenterSecurityRepository CenterSecurityRepository
        {
            get { return _centerSecurityRepository ?? (_centerSecurityRepository = new CenterSecurityRepository(_dbFactory)); }

        }
          
        public ISqlAuditRepository SqlAuditRepository {
            get { return _sqlAuditRepository ?? (_sqlAuditRepository = new SqlAuditRepository(_dbFactory)); }

        }

        public IVehicleRepository VehicleRepository
        {
            get { return _vehicleRepository ?? (_vehicleRepository = new VehicleRepository(_dbFactory)); }
        }

        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_dbFactory)); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_dbFactory)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_dbFactory)); }
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        public Task<int> CommitAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _appDbContext.SaveChangesAsync(cancellationToken);
        }
        #endregion
 
    }
}
