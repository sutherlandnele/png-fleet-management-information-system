
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;


namespace FMS.Service
{
    public class VehicleTypeService : IVehicleTypeService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public VehicleTypeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        #endregion
        #region Get Methods


        public IEnumerable<VehicleType> GetAll()
        {
            return unitOfWork.VehicleTypeRepository.GetAll();
        }

        public IEnumerable<VehicleType> GetAll(string vehicleType)
        {
            var result = GetAll();
            if (!string.IsNullOrEmpty(vehicleType))
            {
                result = result.Where(x => x.Type != null && x.Type.ToUpper().Contains(vehicleType.ToUpper()));
            }
            return result.OrderByDescending(m=>m.Id);
        }

        public VehicleType GetVehicleTypeById(int id)
        {
            return unitOfWork.VehicleTypeRepository.GetById(id);
        }


        #endregion
        #region CRUD Methods

        public int Save()
        {
            return unitOfWork.Commit();
        }

        public void Update(VehicleType vehicleType)
        {
            unitOfWork.VehicleTypeRepository.Update(vehicleType);
        }

        public void Create(VehicleType vehicleType)
        {
            unitOfWork.VehicleTypeRepository.Add(vehicleType);
        }

        public void Delete(VehicleType vehicleType)
        {
            unitOfWork.VehicleTypeRepository.Delete(vehicleType);
        }

        #endregion


    }
}
