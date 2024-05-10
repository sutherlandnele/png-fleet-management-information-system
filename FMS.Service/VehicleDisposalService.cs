
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;
using System.Text;

namespace FMS.Service
{
    public class VehicleDisposalService : IVehicleDisposalService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public VehicleDisposalService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region CRUD Methods
        public void Create(VehicleDisposal vehicleDeposal)
        {
            unitOfWork.VehicleDisposalRepository.Add(vehicleDeposal);
        }

        public void Update(VehicleDisposal vehicleDeposal)
        {
            unitOfWork.VehicleDisposalRepository.Update(vehicleDeposal);
        }

        public void Delete(VehicleDisposal vehicleDeposal)
        {
            unitOfWork.VehicleDisposalRepository.Delete(vehicleDeposal);
        }

        public int Save()
        {
            return unitOfWork.Commit();

        }
        #endregion

        #region Get Methods

        public IEnumerable<VehicleDisposal> GetAll()
        {
            return unitOfWork.VehicleDisposalRepository.GetAll().OrderByDescending(x => x.Id);
        }
        public VehicleDisposal GetVehicleDisposalByVehicleId(int vehicleId)
        {
            return unitOfWork.VehicleDisposalRepository.GetAll().FirstOrDefault(x => x.VehicleId == vehicleId);
        }

        #endregion

        #region private methods

        #endregion
    }
}
