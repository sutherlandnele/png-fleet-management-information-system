using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;


namespace FMS.Service
{
    public class VehicleTransferService : IVehicleTransferService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public VehicleTransferService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region CRUD Methods
        public void Create(VehicleTransfer vehicleTransfer)
        {
            unitOfWork.VehicleTransferRepository.Add(vehicleTransfer);
        }

        public void Update(VehicleTransfer vehicleTransfer)
        {
            unitOfWork.VehicleTransferRepository.Update(vehicleTransfer);
        }

        public void Delete(VehicleTransfer vehicleTransfer)
        {
            unitOfWork.VehicleTransferRepository.Delete(vehicleTransfer);
        }

        public int Save()
        {
            return unitOfWork.Commit();

        }

        #endregion

        #region Get Methods

        public IEnumerable<VehicleTransfer> GetAll()
        {
            return unitOfWork.VehicleTransferRepository.GetAll().OrderByDescending(x => x.Id);
        }
        public IEnumerable<VehicleTransfer> GetfilterbyCenter(string userName, int registrationNumber)
        {
            var result = GetAll();
            if (registrationNumber > 0)
            {
                result = result.Where(x => x.VehicleId == registrationNumber);
            }

            return result.OrderByDescending(v => v.Id);
        }

        public VehicleTransfer GetVehicleTransferById(int Id)
        {
            if (Id > 0)
            {
                var vehicleTransfer = GetAll().FirstOrDefault(x => x.Id == Id);
                if (vehicleTransfer != null)
                {
                    return vehicleTransfer;
                }
            }
            return new VehicleTransfer { Id = -1 };
        }


        #endregion

        #region private methods

        #endregion

    }
}
