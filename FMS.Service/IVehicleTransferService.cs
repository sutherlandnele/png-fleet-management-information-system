
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IVehicleTransferService
    {
        #region Get methods
        IEnumerable<VehicleTransfer> GetAll();
        IEnumerable<VehicleTransfer> GetfilterbyCenter(string userName, int registrationNumber);
        VehicleTransfer GetVehicleTransferById(int Id);

        #endregion

        #region CRUD Methods
        void Create(VehicleTransfer vehicleTransfer);
        void Update(VehicleTransfer vehicleTransfer);
        void Delete(VehicleTransfer vehicleTransfer);       
        int Save();
        #endregion


    }
}
