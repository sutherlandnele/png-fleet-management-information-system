
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using VehicleService = FMS.Model.Service;


namespace FMS.Service
{
    public class VehicleFuelManagementService : IVehicleFuelManagementService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion
        #region Constructors
        public VehicleFuelManagementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
        #region CRUD Methods
        public void Create(VehicleRefuel vehicleRefuel)
        {
            unitOfWork.VehicleRefuelRepository.Add(vehicleRefuel);
        }

        public void Delete(VehicleRefuel vehicleRefuel)
        {
            unitOfWork.VehicleRefuelRepository.Delete(vehicleRefuel);
        }

        public void Update(VehicleRefuel vehicleRefuel)
        {
            unitOfWork.VehicleRefuelRepository.Update(vehicleRefuel);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }
                     
        #endregion
        #region Get Methods

        public IEnumerable<VehicleRefuel> GetAll()
        {
            return unitOfWork.VehicleRefuelRepository.GetAll().OrderByDescending(x=>x.Id);
        }

        public IEnumerable<VehicleRefuel> GetFilterByCenterPermission(string currentUser, int centerId)
        {
            var result = GetAll();

            if (!string.IsNullOrEmpty(currentUser))
            {

                result = from a in result
                         join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == currentUser)
                         on a.CenterId equals b.CenterId
                         select a;
            }
            return result;
        }

        public IEnumerable<VehicleRefuel> GetAll(string bowserNumber, string fuelVoucherNumber, int fuelType, int centerId)
        {
            var result = GetAll();

            if (!string.IsNullOrEmpty(bowserNumber))
            {
                result = result.Where(x => x.BowserNumber != null && x.BowserNumber.ToLower().Contains(bowserNumber.ToLower()));
            }

            if (!string.IsNullOrEmpty(fuelVoucherNumber))
            {
                result = result.Where(x => x.VoucherNumber != null && x.VoucherNumber.ToUpper().Contains(fuelVoucherNumber.ToUpper()));
            }

            if (fuelType != -1)
            {
                result = result.Where(x => x.FuelTypeId == fuelType);
            }

            if (centerId != -1)
            {
                result = result.Where(x => x.Center != null && x.Center.CenterNumber == centerId);  
            }

            return result;
        }

        public VehicleRefuel GetVehicleRefuelById(int Id)
        {
            if (Id > 0)
            {
                var vehicleRefuel = GetAll().FirstOrDefault(x => x.Id == Id);
                if (vehicleRefuel != null)
                {
                    return vehicleRefuel;
                }
            }
            return new VehicleRefuel { Id = -1 };
        }

        public IEnumerable<VehicleRefuel> GetFilterByCenterPermission(string currentUser, string bowserNumber, string fuelVoucherNumber, int fuelType, int center, bool showVouchersNotAcquitted)
        {
            var result = GetAll(bowserNumber, fuelVoucherNumber, fuelType, center);
            
            if (!string.IsNullOrEmpty(currentUser))
            {

                result = from a in result
                         join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == currentUser)
                         on a.CenterId equals b.CenterId
                         select a;
            }

            if (showVouchersNotAcquitted == true)
            {
                result = result.Where(f => f.IsVoucherAcquitted != true);
            }
            return result;
        }

        #endregion

    }
}
