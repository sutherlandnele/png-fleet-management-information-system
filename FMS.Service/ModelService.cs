
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using VehicleModel = FMS.Model.Model;
namespace FMS.Service
{
    public class ModelService : IModelService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public ModelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region CRUD Methods
        public void Create(VehicleModel vehicleModel)
        {
            unitOfWork.ModelRepository.Add(vehicleModel);
        }

        public void Delete(VehicleModel vehicleModel)
        {
            unitOfWork.ModelRepository.Delete(vehicleModel);
        }
               
        public int Save()
        {
            return unitOfWork.Commit();
        }

        public void Update(VehicleModel vehicleModel)
        {
            unitOfWork.ModelRepository.Update(vehicleModel);
        }
        #endregion

        #region Get Methods
        public IEnumerable<VehicleModel> GetAll()
        {
            return unitOfWork.ModelRepository.GetAll();
        }

        public IEnumerable<VehicleModel> GetAll(string modelName, int makeId)
        {
            var result = GetAll();

            if (!string.IsNullOrEmpty(modelName))
            {
                result = result.Where(x => x.Name != null && x.Name.ToUpper().Contains(modelName.ToUpper()));
            }
            if (makeId != -1)
            {
                result = result.Where(x => x.MakeId == makeId);
            }

            return result.OrderByDescending(m=>m.Id);
        }

        public VehicleModel GetModelById(int id)
        {
            return unitOfWork.ModelRepository.GetById(id);
        }

        public IEnumerable<VehicleModel> GetModelByMakeId(int makeId)
        {
            return unitOfWork.ModelRepository.GetAll().Where(x => x.MakeId == makeId);
        }

        #endregion

    }
}
