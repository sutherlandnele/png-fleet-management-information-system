
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using VehicleService = FMS.Model.Service;


namespace FMS.Service
{
    public class VehicleServiceService : IVehicleServiceService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public VehicleServiceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
        #region CRUD Methods
        public void Create(VehicleService vehicleService)
        {
            unitOfWork.ServiceRepository.Add(vehicleService);
        }

        public void Delete(VehicleService vehicleService)
        {
            unitOfWork.ServiceRepository.Delete(vehicleService);
        }

        public void Update(VehicleService vehicleService)
        {
            unitOfWork.ServiceRepository.Update(vehicleService);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }
                     
        #endregion

        #region Get Methods

        public IEnumerable<VehicleService> GetAll()
        {
            return unitOfWork.ServiceRepository.GetAll().OrderByDescending(s=>s.StartDate);                
        }

        public IEnumerable<VehicleService> GetFilterByCenterPermission(string userName, string serviceJobNumber, string registrationNumber, int groupNumber, int center, bool isInComplete, bool isCompleted)
        {
            var result = GetFilterWithCenterPermission(registrationNumber, groupNumber, center, isInComplete, isCompleted);


            if (!string.IsNullOrEmpty(serviceJobNumber))
            {
                result = result.Where(x => x.ServiceJobNumber != null && x.ServiceJobNumber.ToUpper().Contains(serviceJobNumber.ToUpper()));
            }

            if (!string.IsNullOrEmpty(userName))
            {
                return from a in result where a.Vehicle != null
                       join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == userName) 
                       on a.Vehicle.CenterId equals b.CenterId
                       select a;
            }
            return result;
        }

        public IEnumerable<VehicleService> GetFilterWithCenterPermission(string registrationNumber, int groupNumber, int center, bool isInComplete, bool isCompleted)
        {
            var result = GetAll();

            if (!string.IsNullOrEmpty(registrationNumber))
            {
                result = result.Where(x => x.Vehicle != null && x.Vehicle.RegistrationNumber.ToUpper().Contains(registrationNumber.ToUpper()));
            }

            if (groupNumber > 0)
            {
                result = result.Where(x => x.Vehicle != null && x.Vehicle.BusinessGroupId == groupNumber);
            }
            if (center > 0)
            {
                result = result.Where(x => x.Center != null && x.CenterId == center);
            }

            if (!(isInComplete && isCompleted))
            {
                if (isInComplete)
                {
                    result = result.Where(x => !x.EndDate.HasValue);
                }
                if (isCompleted)
                {
                    result = result.Where(x => x.EndDate.HasValue);
                }
            }


            return result;
        }

        public VehicleService GetServiceById(int id)
        {
            if (id > 0)
            {
                var service = GetAll().FirstOrDefault(x => x.Id == id);
                if (service != null)
                {
                    return service;
                }
            }
            return new VehicleService { Id = -1 };
        }

        #endregion

    }
}
