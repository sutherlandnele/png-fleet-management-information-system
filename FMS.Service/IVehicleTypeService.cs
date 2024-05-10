
using System.Collections.Generic;
using FMS.Model;

namespace FMS.Service
{
    public interface IVehicleTypeService
    {
        #region Get methods

        IEnumerable<VehicleType> GetAll();
        VehicleType GetVehicleTypeById(int id);
        IEnumerable<VehicleType> GetAll(string vehicleType);
  
        #endregion

        #region CRUD Methods
        void Create(VehicleType vehicleType);
        void Update(VehicleType vehicleType);
        void Delete(VehicleType vehicleType);       
        int Save();
        #endregion
    }
}
