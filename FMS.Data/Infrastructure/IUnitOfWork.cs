
using System;
using System.Threading;
using System.Threading.Tasks;
using FMS.Data.Repositories;

namespace FMS.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        #region Properties
        IExternalLoginRepository ExternalLoginRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        ISqlAuditRepository SqlAuditRepository { get; }
        ICenterSecurityRepository CenterSecurityRepository { get; }
        IUserContactRepository UserContactRepository { get; }
        ICenterRepository CenterRepository { get; }
        IComplianceRepository ComplianceRepository { get; }
        IContactDetailRepository ContactDetailRepository { get; }
        IFuelVoucherRepository FuelVoucherRepository { get; }
        IIncidentRepository IncidentRepository { get; }
        IScheduleServiceRepository ScheduleServiceRepository { get; }
        IVehicleDisposalRepository VehicleDisposalRepository { get; }
        IVehicleRefuelRepository VehicleRefuelRepository { get; }
        IVehicleTransferRepository VehicleTransferRepository { get; }
        IVehicleAllocationRepository VehicleAllocationRepository { get; }
        IBusinessUnitRepository BusinessUnitRepository { get; }
        IBusinessGroupRepository BusinessGroupRepository { get; }
        IBusinessGroupSecurityRepository BusinessGroupSecurityRepository { get; }
        IOperatorRepository OperatorRepository { get; }
        IDepotTankRepository DepotTankRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IRegionRepository RegionRepository { get; }
        ISystemParameterRepository SystemParameterRepository { get; }
        IAlertRepository AlertRepository { get; }
        INotificationRepository NotificationRepository { get; }
        IModelRepository ModelRepository { get; }
        IDepotDailyMeasurementRepository DepotDailyMeasurementRepository { get; }
        IDepotRefuelRepository DepotRefuelRepository { get; }
        IVehicleTypeRepository VehicleTypeRepository { get; }
        IEmailTemplateRepository EmailTemplateRepository { get; }
        IDashboardRepository DashboardRepository { get; }
        IClientInformationRepository ClientInformationRepository { get; }
        ISystemParameterCodeRepository SystemParameterCodeRepository { get; }
        IAppMenuRepository AppMenuRepository { get; }
        IAppInterfaceRepository AppInterfaceRepository { get; }
        IAppActionRepository AppActionRepository { get; }
        IAppRoleMenuAccessRepository AppRoleMenuAccessRepository { get; }
        IAppRoleInterfaceAccessRepository AppRoleInterfaceAccessRepository { get; }
        IAppRoleActionAccessRepository AppRoleActionAccessRepository { get; }
        IAppIssueRepository AppIssueRepository { get; }






        #endregion

        #region Methods
        int Commit();
        Task<int> CommitAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken);
        #endregion
    }
}
