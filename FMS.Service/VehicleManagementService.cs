
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;
using System.Text;

namespace FMS.Service
{
    public class VehicleManagementService : IVehicleManagementService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public VehicleManagementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region CRUD Methods
        public void Create(Vehicle vehicle)
        {
            unitOfWork.VehicleRepository.Add(vehicle);

        }

        public void Update(Vehicle vehicle)
        {
            unitOfWork.VehicleRepository.Update(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            unitOfWork.VehicleRepository.Delete(vehicle);
        }

        public int Save()
        {
            return unitOfWork.Commit();

        }
        #endregion

        #region Get Methods



        public IEnumerable<Vehicle> GetVehicleListBySafetyStickerRenewl()
        {
            return GetAll().Where(x => x.SafetyStickyExpiry.HasValue && x.SafetyStickyExpiry.Value != DateTime.MinValue && (x.SafetyStickyExpiry.Value.Subtract(DateTime.Now.Date)).Days <= 30);
        }
        public IEnumerable<Vehicle> GetVehicleSafetyStickerExpiryByCenterPermission(string userName)
        {
            var result = (from a in GetVehicleListBySafetyStickerRenewl()
                          join b in unitOfWork.CenterSecurityRepository.GetAll().Where(m => m.UserId == userName) on a.CenterId equals b.CenterId
                          select a).OrderBy(x => x.SafetyStickyExpiry).ThenBy(x => x.Center.Name);
            return result;
        }

        public IEnumerable<Vehicle> GetVehicleRegistrationExpiryByCenterPermission(string userName)
        {
            var result = (from a in GetVehicleListByRegisterationRenewl()
                          join b in unitOfWork.CenterSecurityRepository.GetAll().Where(m => m.UserId == userName) on a.CenterId equals b.CenterId
                          select a).OrderBy(x => x.RegistrationExpiry).ThenBy(x => x.Center.Name);
            return result;
        }


        public bool IsInUse(int id)
        {
            return (unitOfWork.ComplianceRepository.GetAll().Any(x => x.RegistrationNumber == id)
                || unitOfWork.FuelVoucherRepository.GetAll().Any(x => x.RegistrationNumber == id)
                || unitOfWork.IncidentRepository.GetAll().Any(x => x.VehicleId == id)
                || unitOfWork.ScheduleServiceRepository.GetAll().Any(x => x.VehicleId == id)
                || unitOfWork.VehicleDisposalRepository.GetAll().Any(x => x.VehicleId == id)
                || unitOfWork.VehicleRefuelRepository.GetAll().Any(x => x.VehicleId == id)
                || unitOfWork.VehicleTransferRepository.GetAll().Any(x => x.VehicleId == id)
                || unitOfWork.VehicleAllocationRepository.GetAll().Any(x => x.VehicleId == id));
        }
        public IEnumerable<Vehicle> SearchVehicle(string regNumber, string userName)
        {
            var listvehicle = GetVehiclelist(userName);

            return listvehicle.Where(x => x.RegistrationNumber.ToLower().Contains(regNumber.ToLower())).ToList();
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return unitOfWork.VehicleRepository.GetAll();
        }

        public IEnumerable<Vehicle> GetAll(string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int centerNumber)
        {
            return unitOfWork.VehicleRepository.GetAll( assetNumber,  registrationNumber,  unitNumber,  groupNumber,  centerNumber);
        }
               
        public IEnumerable<Vehicle> GetAllVehiclesAscending()
        {
            return unitOfWork.VehicleRepository.GetAllVehiclesAscending();
        }

        public IEnumerable<Vehicle> GetDisposedVehicles(string userName, string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int centerNumber)
        {
            var result = GetAll(assetNumber, registrationNumber, unitNumber, groupNumber, centerNumber);

            if (!string.IsNullOrEmpty(userName))
            {

                result = from a in result join b in unitOfWork.CenterSecurityRepository.GetAll()
                         .Where(x => x.UserId == userName) on a.CenterId equals b.CenterId select a;

            }
            return result.Where(x => x.StatusId == (int)Parameters.VehicleFinancialStatus.Disposed);
        }

        public IEnumerable<Vehicle> GetFilterByCenterPermission(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                 return (from a in GetAll()
                         join b in unitOfWork.CenterSecurityRepository.GetAll()
                            .Where(x => x.UserId == userName) 
                                on a.CenterId equals b.CenterId select a)
                            .OrderBy(x => x.RegistrationNumber);

            }
            return GetAll();
        }
        public IEnumerable<Vehicle> GetUnallocatedVehicles(string currentUser, int registrationNumber)
        {
            var data = GetAll().Where(x => !x.IsAllocated.HasValue || x.IsAllocated == false);
            if (registrationNumber > 0)
            {
                data = data.Where(x => x.Id == registrationNumber);
            }
            if (!string.IsNullOrEmpty(currentUser))
            {
                UserContact user = unitOfWork.UserContactRepository.GetAll().FirstOrDefault(x => x.UserId == currentUser);

                if (user != null)
                {
                    data = from a in data
                           join security in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == user.UserId) on a.CenterId equals security.CenterId select a;
                }
            }
            return data.Where(x => x.StatusId == (int)Parameters.VehicleFinancialStatus.Disposed).OrderByDescending(v=>v.Id);
        }
        public Vehicle GetVehicleById(int id)
        {
            return unitOfWork.VehicleRepository.GetById(id);
        }
        public IEnumerable<Vehicle> GetVehiclelist(string userName)
        {

            var allItems = GetAll();
          
            var getCenter = GetAllCenterWithPermission(userName);
           
            var finalList = (from Vehiclelist in allItems
                             where Vehiclelist.Center != null
                             join center in getCenter
                             on Vehiclelist.Center.CenterNumber equals center.CenterNumber
                             where Vehiclelist.StatusId != (int) Parameters.VehicleFinancialStatus.Disposed
                             select Vehiclelist).ToList();
            return finalList;
        }
        public IEnumerable<Vehicle> GetVehicleListByRegisterationRenewl()
        {
            return GetAll().Where(x => x.RegistrationExpiry.HasValue && x.RegistrationExpiry.Value != DateTime.MinValue && (x.RegistrationExpiry.Value.Subtract(DateTime.Now.Date)).Days <= 30);

        }
        public IEnumerable<Vehicle> GetFilterByCenterPermission(string userName, string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int centerNumber)
        {
            var result = GetAll(assetNumber, registrationNumber, unitNumber, groupNumber, centerNumber);

            if (!string.IsNullOrEmpty(userName))
            {

                result = from a in result join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == userName) on a.CenterId equals b.CenterId select a;

            }
            return result.Where(x => x.StatusId != (int)Parameters.VehicleFinancialStatus.Disposed);

        }

        public IEnumerable<Vehicle> GetFilterByCenterPermissionBOS(string userName, string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int centerNumber)
        {
            var result = GetAll(assetNumber, registrationNumber, unitNumber, groupNumber, centerNumber);

            if (!string.IsNullOrEmpty(userName))
            {

                result = from a in result join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == userName) 
                         on a.CenterId equals b.CenterId select a;

            }

            result = from c in result
                     join d in unitOfWork.VehicleTypeRepository.GetAll()
                     on c.VehicleTypeId equals d.Id
                     where (
                        ((c.AcquisitionDate != null) && ((DateTime.Today.Year - ((DateTime)(c.AcquisitionDate)).Year) > (int)d.LifeSpan)) ||
                        ((c.CurrentMileage != null) && (int)c.CurrentMileage > (int)d.MileageSpan)  ||
                        ((c.StatusId != null) && (int)c.StatusId == (int)Parameters.VehicleOperationalStatus.Accident) ||
                        ((c.ConditionId != null) && (int)c.ConditionId == (int)Parameters.VehicleConditionStatus.BeyondRepair)
                     )
                     select c;

            return result.Where(x => x.StatusId != (int)Parameters.VehicleFinancialStatus.Disposed);

        }
        public string GetVehicleCustodianDriver(int id)
        {
            var contactNames = from veh in unitOfWork.VehicleRepository.GetAll()
                                join all in unitOfWork.VehicleAllocationRepository.GetAll()
                                    on veh.Id equals all.VehicleId
                                join ope in unitOfWork.OperatorRepository.GetAll()
                                    on all.OperatorId equals ope.Id
                                join con in unitOfWork.ContactDetailRepository.GetAll()
                                    on ope.ContactDetailId equals con.Id
                               where veh.Id == id
                                select con.ContactName;

            StringBuilder contactName = new StringBuilder();

            contactName.Append("");

            foreach (var name in contactNames)
            {
                contactName.Append("*" + name + "*");
            }

            return contactName.ToString();
        }
        public string GetVehicleBusinessUnit(int id)
        {
            var bu = (from veh in unitOfWork.VehicleRepository.GetAll()
                          join bg in unitOfWork.BusinessGroupRepository.GetAll()
                             on veh.BusinessGroupId equals bg.GroupNumber
                          join bsu in unitOfWork.BusinessUnitRepository.GetAll()
                             on bg.BusinessUnitId equals bsu.UnitNumber
                          where veh.Id == id
                          select bsu.Name).FirstOrDefault();

            return bu;

        }
        public string GetVehicleRegion(int id)
        {
            var region = (from veh in unitOfWork.VehicleRepository.GetAll()
                     join cnt in unitOfWork.CenterRepository.GetAll()
                        on veh.CenterId equals cnt.CenterNumber
                     join reg in unitOfWork.RegionRepository.GetAll()
                        on cnt.RegionaNumberId equals reg.RegionNumber
                     where veh.Id == id
                     select reg.Name).FirstOrDefault();

            return region;
        }
        public decimal? GetTotalFuelConsumptionCostToDate(int id)
        {
            var total = (from veh in unitOfWork.VehicleRepository.GetAll()
                         join fuel in unitOfWork.FuelVoucherRepository.GetAll()
                             on veh.Id equals fuel.RegistrationNumber
                         where veh.Id == id
                        select fuel.FuelAmount).Sum();

            return total;
        }
        public decimal? GetTotalServiceCostToDate(int id)
        {
            var total = (from veh in unitOfWork.VehicleRepository.GetAll()
                         join svc in unitOfWork.ServiceRepository.GetAll()
                             on veh.Id equals svc.VehicleId
                         where veh.Id == id && svc.IsAmountPaid == true
                         select svc.Cost).Sum();

            return total;
        }
        #endregion

        #region private methods
        private int WhenAppear(string expiryType)
        {
            throw new System.NotImplementedException();
        }
        private IEnumerable<Center> GetAllCenterWithPermission(string UserName)
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                return from a in unitOfWork.CenterRepository.GetAll()
                       join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId.ToLower() == UserName.ToLower()) 
                       on a.CenterNumber equals b.CenterId select a;
            }
            return unitOfWork.CenterRepository.GetAll();
        }
        #endregion
    }
}
