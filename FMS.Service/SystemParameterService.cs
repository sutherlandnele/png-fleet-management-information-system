
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class SystemParameterService : ISystemParameterService
    {

        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public SystemParameterService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
 
        #endregion

        #region CRUD Methods
        public void Create(SystemParameter systemParameter)
        {
            unitOfWork.SystemParameterRepository.Add(systemParameter);
        }
        public void Delete(SystemParameter systemParameter)
        {
            unitOfWork.SystemParameterRepository.Delete(systemParameter);
        }
        public void Update(SystemParameter systemParameter)
        {
            unitOfWork.SystemParameterRepository.Update(systemParameter);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }
        #endregion

        #region Public Get methods
        public IEnumerable<SystemParameter> GetAll()
        {
            return unitOfWork.SystemParameterRepository.GetAll();
        }                      
      
       

        public bool IsInUse(int id)
        {
            return unitOfWork.ContactDetailRepository.GetAll().Any(x => x.Contacttype == id || x.SupplierType == id) 
                || unitOfWork.NotificationRepository.GetAll().Any(x => x.NotificationTypeId == id || x.WhenAppearId == id || x.SeverityId == id) 
                || unitOfWork.ModelRepository.GetAll().Any(x => x.MakeId == id) 
                || unitOfWork.ComplianceRepository.GetAll().Any(x => x.ComplianceType == id) 
                || unitOfWork.DepotTankRepository.GetAll().Any(x => x.FuelTypeId == id) 
                || unitOfWork.FuelVoucherRepository.GetAll().Any(x => x.FueltypeId == id) 
                || unitOfWork.IncidentRepository.GetAll().Any(x => x.IncidentTypeId == id || x.IncidentStatusId == id) 
                || unitOfWork.ScheduleServiceRepository.GetAll().Any(x => x.ScheduleServiceTypeId == id) 
                || unitOfWork.ServiceRepository.GetAll().Any(x => x.ScheduleServiceTypeId == id || x.ServiceTypeId == id) 
                || unitOfWork.VehicleRepository.GetAll().Any(x => x.FuelTypeId == id || x.TransmissionId == id || x.StatusId == id || x.ConditionId == id || x.NextServiceId == id || x.NextServiceTypeId == id || x.LastServiceId == id) 
                || unitOfWork.VehicleRefuelRepository.GetAll().Any(x => x.FuelTypeId == id) 
                || unitOfWork.AlertRepository.GetAll().Any(x => x.AlertTypeId == id);

        }
        #endregion

        #region Can Delete
        public bool CanDeleteFuel(int id)
        {
            return(!unitOfWork.VehicleRepository.GetAll().Any(x => x.FuelTypeId == id));
        }

        public bool CanDeleteAcquisition(int id)
        {
            return (!unitOfWork.VehicleRepository.GetAll().Any(x => x.AcquisitionTypeId == id));
        }

        public bool CanDeleteStatus(int id)
        {
            return (!unitOfWork.VehicleRepository.GetAll().Any(x => x.StatusId == id));
        }

        public bool CanDeleteCondition(int id)
        {
            return (!unitOfWork.VehicleRepository.GetAll().Any(x => x.ConditionId == id));
        }

        public bool CanDeleteService(int id)
        {
            return (!unitOfWork.VehicleRepository.GetAll().Any(x => x.NextServiceId == id)) &&  (!unitOfWork.ServiceRepository.GetAll().Any(x => x.ServiceTypeId == id));
        }

        public bool CanDeleteOperator(int id)
        {
            return (!unitOfWork.OperatorRepository.GetAll().Any(x => x.OperatorTypeId == id));
        }

        public bool CanDeleteTransmission(int id)
        {
            return (!unitOfWork.VehicleRepository.GetAll().Any(x => x.TransmissionId == id));
        }

        public bool CanDeleteVehicleType(int id)
        {
            return (!unitOfWork.VehicleRepository.GetAll().Any(x => x.VehicleTypeId == id));
        }

        public bool CanDeleteCenter(int id)
        {
            return (!unitOfWork.OperatorRepository.GetAll().Any(x => x.CenterId == id))
                    && (!unitOfWork.VehicleRepository.GetAll().Any(x => x.CenterId == id))
                    && (!unitOfWork.ServiceRepository.GetAll().Any(x => x.CenterId == id))
                    && (!unitOfWork.IncidentRepository.GetAll().Any(x => x.CenterId == id))
                    && (!unitOfWork.DepotDailyMeasurementRepository.GetAll().Any(x => x.CenterId == id))
                    && (!unitOfWork.DepotRefuelRepository.GetAll().Any(x => x.CenterId == id))
                    && (!unitOfWork.DepotTankRepository.GetAll().Any(x => x.CenterId == id))
                    && (!unitOfWork.VehicleRefuelRepository.GetAll().Any(x => x.CenterId == id));
        }

        public bool CanDeleteIncidentType(int id)
        {
            return (!unitOfWork.IncidentRepository.GetAll().Any(x => x.IncidentTypeId == id));
        }

        public bool CanDeleteServiceProvider(int id)
        {
            return (!unitOfWork.ServiceRepository.GetAll().Any(x => x.ProviderId == id));
        }

        public bool CanDeleteNotificationType(int id)
        {
            return (!unitOfWork.NotificationRepository.GetAll().Any(x => x.NotificationTypeId == id));
        }

        public bool CanDeleteSeverity(int id)
        {
            return (!unitOfWork.NotificationRepository.GetAll().Any(x => x.SeverityId == id));
        }

        public bool CanDeleteWhenAppear(int id)
        {
            return (!unitOfWork.NotificationRepository.GetAll().Any(x => x.WhenAppearId == id));
        }

        public bool CanDeleteGender(int id)
        {
            return (!unitOfWork.OperatorRepository.GetAll().Any(x => x.OperatorTypeId == id));
        }

        public bool CanDeleteContactType(int id)
        {
            return (!unitOfWork.CenterRepository.GetAll().Any(x => x.ContactDetailId == id));
        }

        public bool CanDeleteServiceType(int id)
        {
            return (!unitOfWork.ServiceRepository.GetAll().Any(x => x.ServiceTypeId == id));
        }

        public IEnumerable<SystemParameter> GetAllFilterByParameterType(int parameterType)
        {
            return unitOfWork.SystemParameterRepository.GetAllFilterByParameterType(parameterType);
        }

        public string GetSystemParameterNameByCodeId(int code)
        {
            return GetAllFilterByParameterType(code).FirstOrDefault().ParameterName;            
        }
        #endregion

        #region Private methods
        #endregion

    }
}
