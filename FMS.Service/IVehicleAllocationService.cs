
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IVehicleAllocationService
    {
        #region Get methods
        IEnumerable<VehicleAllocation> GetAll();
        IEnumerable<VehicleAllocation> GetAll(int vehicleId);
        VehicleAllocation GetByVehicleAllocationId(int Id);
        IEnumerable<VehicleAllocation> GetFilterByCenterPermission(string currentUser, int vehicleId);
        IEnumerable<VehicleAllocation> GetHistory(string currentUser, int vehicleId);
        VehicleAllocation GetbyVehicleId(int VehicleId);
        bool IsVehicleExist(int VehicleId);
        #endregion

        #region CRUD Methods
        void Create(VehicleAllocation vehicleAllocation);
        void Update(VehicleAllocation vehicleAllocation);
        void Delete(VehicleAllocation vehicleAllocation);       
        int Save();
        #endregion


    }
}
