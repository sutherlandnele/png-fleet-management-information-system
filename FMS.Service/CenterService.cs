
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class CenterService : ICenterService
    {

        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public CenterService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
        
        #region CRUD Methods
        public void Create(Center center)
        {
            unitOfWork.CenterRepository.Add(center);
        }
        public void Delete(Center center)
        {
            unitOfWork.CenterRepository.Delete(center);
        }
        public void Update(Center center)
        {
            unitOfWork.CenterRepository.Update(center);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }
        #endregion

        #region Get methods
        public int GetNextServiceNumberForMonth(int centerId, string mm, string yy)
        {

            //pre-condition: the service number is strictly stored as a string of 10 characters following the format: SCCXXXMMYY
            var center = unitOfWork.CenterRepository.GetAll().FirstOrDefault(c => c.CenterNumber == centerId);

            int maxVehicleServiceCapacityPerMonth = (int)center.MaxVehicleServiceCapacityPerMonth;


            string cc = center.CenterCode.PadLeft(2,'0');

            string prevNum = unitOfWork.ServiceRepository.GetAll()
                                .Where(s => s.ServiceJobNumber != null
                                            && s.ServiceJobNumber.Length == 10
                                            && s.ServiceJobNumber.Substring(1, 2) == cc
                                            && s.ServiceJobNumber.Substring(6, 2) == mm
                                            && s.ServiceJobNumber.Substring(8, 2) == yy)
                                .Select(s => s.ServiceJobNumber.Substring(3, 3))
                                .DefaultIfEmpty()
                                .Max();

            int nextNum = 1; //generate 1st service number

            if (!string.IsNullOrEmpty(prevNum)) 
            {
                nextNum = Int32.Parse(prevNum) + 1 ;
            }

            return nextNum > maxVehicleServiceCapacityPerMonth ? 0: nextNum;
        }

        public bool HasUnacquittedFuelVouchers(int centerId)
        {
            var count = unitOfWork.VehicleRefuelRepository.GetAll().Where(r => r.IsVoucherAcquitted != true 
                && r.CenterId == centerId 
                && r.Date != null 
                && (((DateTime)(r.Date)).ToString("yyyy") != DateTime.Today.ToString("yyyy") || ((DateTime)(r.Date)).ToString("MM") != DateTime.Today.ToString("MM"))).Count();

            return count > 0;
        }

        public int GetNextFuelVoucherNumberForMonth(int centerId, string mm, string yy)
        {

            //pre-condition: the service number is strictly stored as a string of 12 characters following the format: SCCXXXMMYY
            var center = unitOfWork.CenterRepository.GetAll().FirstOrDefault(c => c.CenterNumber == centerId);

            int maxFuelVoucherCapacityPerMonth = (int)center.MaxVehicleFuelVoucherCapacityPerMonth;

            string centerCode = center.CenterCode;


            string cc= centerCode.PadLeft(2, '0');

            string prevNum = unitOfWork.VehicleRefuelRepository.GetAll()
                                .Where(s => s.VoucherNumber != null
                                            && s.VoucherNumber.Length == 10
                                            && s.VoucherNumber.Substring(1, 2) == cc
                                            && s.VoucherNumber.Substring(6, 2) == mm
                                            && s.VoucherNumber.Substring(8, 2) == yy)
                                .Select(s => s.VoucherNumber.Substring(3, 3))
                                .DefaultIfEmpty()
                                .Max();

            int nextNum = 1; //generate 1st service number

            if (!string.IsNullOrEmpty(prevNum))
            {
                nextNum = Int32.Parse(prevNum) + 1;
            }

            return nextNum > maxFuelVoucherCapacityPerMonth ? 0 : nextNum;
        }

        public Regional GetCenterRegion(int centerId)
        {
            return GetAll().Where(c => c.CenterNumber == centerId).Select(c => c.Regional).FirstOrDefault();
        }
        public IEnumerable<Center> GetAll()
        {
            return unitOfWork.CenterRepository.GetAll();
        }

        public IEnumerable<Center> GetAllCenterWithPermission(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                return from a in GetAll() join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId.ToLower() == userName.ToLower()) on a.CenterNumber equals b.CenterId select a;
            }
            return GetAll();
        }

        public IEnumerable<Center> GetAllCenterWithPermission(string userName, string centerName, int region)
        {
            var result = GetAllCenterWithPermission(userName);

            if (!string.IsNullOrEmpty(centerName))
            {
                result = result.Where(x => x.Name != null && x.Name.ToUpper().Contains(centerName.ToUpper()) || x.Regional != null && x.Regional.ToString().Contains(centerName.ToString()));
            }
            if (region != -1)
            {
                result = result.Where(x => x.RegionaNumberId == region);
            }

            return result.OrderByDescending(m=>m.CenterNumber);
        }

        public Center GetByCenterNumber(int centerNumber)
        {
            if (centerNumber > 0)
            {
                var center = unitOfWork.CenterRepository.GetById(centerNumber);
                if (center != null)
                {
                    return center;
                }
            }
            return new Center { CenterNumber = -1 };
        }

        public Center GetById(int id, string userName)
        {
            return GetAllCenterWithPermission(userName).FirstOrDefault(x => x.CenterNumber == id);
        }

        public Center GetCenterFromId(int centerId)
        {
            return unitOfWork.CenterRepository.GetAll().FirstOrDefault(x => x.CenterNumber == centerId);
        }

        public bool IsInUse(int id)
        {
            return unitOfWork.DepotTankRepository.GetAll().Any(x => x.CenterId == id)
                || unitOfWork.DepotRefuelRepository.GetAll().Any(x => x.CenterId == id)
                || unitOfWork.DepotDailyMeasurementRepository.GetAll().Any(x => x.CenterId == id)
                || unitOfWork.VehicleRefuelRepository.GetAll().Any(x => x.CenterId == id)
                || unitOfWork.ServiceRepository.GetAll().Any(x => x.CenterId == id)
                || unitOfWork.CenterSecurityRepository.GetAll().Any(x => x.CenterId == id)
                || unitOfWork.ContactDetailRepository.GetAll().Any(x => x.CenterId == id)
                || unitOfWork.OperatorRepository.GetAll().Any(x => x.CenterId == id) 
                || unitOfWork.VehicleRepository.GetAll().Any(x => x.CenterId == id);
        }
        #endregion
        #region Private Methods

        #endregion

    }
}
