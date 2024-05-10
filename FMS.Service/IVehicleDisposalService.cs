
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IVehicleDisposalService
    {
        #region Get methods
        IEnumerable<VehicleDisposal> GetAll();
        VehicleDisposal GetVehicleDisposalByVehicleId(int vehicleId);

        #endregion

        #region CRUD Methods
        void Create(VehicleDisposal vehicleDeposal);
        void Update(VehicleDisposal vehicleDeposal);
        void Delete(VehicleDisposal vehicleDeposal);       
        int Save();
        #endregion


    }
}
