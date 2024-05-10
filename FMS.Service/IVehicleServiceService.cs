
using System.Collections.Generic;
using VehicleService = FMS.Model.Service;

namespace FMS.Service
{
    public interface IVehicleServiceService
    {
        #region Get methods

        IEnumerable<VehicleService> GetAll();
        IEnumerable<VehicleService> GetFilterByCenterPermission(string userName, string serviceJobNumber, string registrationNumber, int groupNumber, int center, bool isInComplete, bool isCompleted);
        IEnumerable<VehicleService> GetFilterWithCenterPermission(string registrationNumber, int groupNumber, int center, bool isInComplete, bool isCompleted);
        VehicleService GetServiceById(int id);      

        #endregion

        #region CRUD Methods
        void Create(VehicleService vehicleService);
        void Update(VehicleService vehicleService);
        void Delete(VehicleService vehicleService);
        int Save();
        #endregion


    }
}
