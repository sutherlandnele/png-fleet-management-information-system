
using FMS.Model;
using System.Collections.Generic;


namespace FMS.Service
{
    public interface IVehicleFuelManagementService
    {
        #region Get methods
        IEnumerable<VehicleRefuel> GetAll();
        IEnumerable<VehicleRefuel> GetFilterByCenterPermission(string currentUser, int centerId);
        IEnumerable<VehicleRefuel> GetAll(string bowserNumber, string fuelVoucherNumber, int fuelType, int centerId);
        IEnumerable<VehicleRefuel> GetFilterByCenterPermission(string currentUser, string bowserNumber, string fuelVoucherNumber, int fuelType, int center, bool showVouchersNotAcquitted);
        VehicleRefuel GetVehicleRefuelById(int Id);
        #endregion

        #region CRUD Methods
        void Create(VehicleRefuel vehicleRefuel);
        void Update(VehicleRefuel vehicleRefuel);
        void Delete(VehicleRefuel vehicleRefuel);
        int Save();
        #endregion


    }
}
