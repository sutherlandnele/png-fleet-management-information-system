using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;

namespace FMS.Data.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        #region Get methods
        
        IEnumerable<Vehicle> GetAllVehiclesAscending();
  
        IEnumerable<Vehicle> GetAll(string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int centerNumber);
        IEnumerable<Vehicle> GetVehicleListByRegisterationRenewl();
  

        #endregion
    }
}
