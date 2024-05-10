using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;


namespace FMS.Service
{
    public class VehicleAllocationService : IVehicleAllocationService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public VehicleAllocationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region CRUD Methods
        public void Create(VehicleAllocation vehicleAllocation)
        {
            unitOfWork.VehicleAllocationRepository.Add(vehicleAllocation);
        }

        public void Update(VehicleAllocation vehicleAllocation)
        {
            unitOfWork.VehicleAllocationRepository.Update(vehicleAllocation);
        }

        public void Delete(VehicleAllocation vehicleAllocation)
        {
            unitOfWork.VehicleAllocationRepository.Delete(vehicleAllocation);
        }

        public int Save()
        {
            return unitOfWork.Commit();

        }
        #endregion

        #region Get Methods
        public IEnumerable<VehicleAllocation> GetAll()
        {
            return unitOfWork.VehicleAllocationRepository.GetAll().OrderByDescending(x => x.Id);
        }
        public IEnumerable<VehicleAllocation> GetAll(int vehicleId)
        {
            var result = GetAll();

            if (vehicleId > 0)
            {
                result = result.Where(x => x.Vehicle.Id == vehicleId);
            }
            return result.OrderByDescending(v => v.Id);            
        }
        public VehicleAllocation GetByVehicleAllocationId(int Id)
        {
            if (Id > 0)
            {
                var vehicleAllocation = GetAll().FirstOrDefault(x => x.Id == Id);
                if (vehicleAllocation != null)
                {
                    return vehicleAllocation;
                }
            }
            return new VehicleAllocation { Id = -1 };
        }
        public IEnumerable<VehicleAllocation> GetFilterByCenterPermission(string currentUser, int vehicleId)
        {
            var result = GetAll(vehicleId);          

            return result.Where(x => !x.EndDate.HasValue).OrderByDescending(a=>a.StartDate);
        }
        public IEnumerable<VehicleAllocation> GetHistory(string currentUser, int vehicleId)
        {
            var result = GetAll().Where(x => x.EndDate.HasValue);

            if (vehicleId > 0)
            {
                result = result.Where(x => x.Vehicle.Id == vehicleId);
            }
            if (!string.IsNullOrEmpty(currentUser))
            {
                result = from a in result
                         where a.Vehicle != null
                         join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == currentUser)
                         on a.Vehicle.CenterId equals b.CenterId
                         select a;
            }

            return result.OrderByDescending(x=>x.Id);
        }
        public VehicleAllocation GetbyVehicleId(int VehicleId)
        {
            return GetAll().FirstOrDefault(x => x.VehicleId == VehicleId);
        }
        public bool IsVehicleExist(int VehicleId)
        {
            return GetAll().Any(x => x.VehicleId == VehicleId && !x.EndDate.HasValue);
        }               

        #endregion

        #region private methods

        #endregion


    }
}
