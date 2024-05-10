
using System.Collections.Generic;
using FMS.Model;
using VehicleModel = FMS.Model.Model;

namespace FMS.Service
{
    public interface IModelService
    {
        #region Get methods
        IEnumerable<VehicleModel> GetAll();
        IEnumerable<VehicleModel> GetAll(string modelName, int makeId);
        VehicleModel GetModelById(int id);
        IEnumerable<VehicleModel> GetModelByMakeId(int makeId);

        #endregion

        #region CRUD Methods
        void Create(VehicleModel vehicleModel);
        void Update(VehicleModel vehicleModel);
        void Delete(VehicleModel vehicleModel);       
        int Save();
        #endregion
     

    }
}
