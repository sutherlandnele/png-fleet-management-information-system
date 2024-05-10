
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System;

namespace FMS.Service
{
    public class DepotTankService : IDepotTankService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion
        #region Constructors
        public DepotTankService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
        #region Get Methods
        public IEnumerable<DepotTank> GetAll()
        {
            return unitOfWork.DepotTankRepository.GetAll();
        }
               
        public IEnumerable<DepotTank> GetAll(string bowserNumber, string name, decimal currentVol, decimal maxCap)
        {
            var result = GetAll();

            if (!string.IsNullOrEmpty(bowserNumber))
            {
                result = result.Where(x => x.BowserNumber.ToLower().Contains(bowserNumber.ToLower()));
            }
            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(x => x.Name != null && x.Name.ToLower().Contains(name.ToLower()));                
            }
            if (currentVol != 0)
            {
                result = result.Where(x => x.CurrentVolume == currentVol);
            }

            if (maxCap != 0)
            {
                result = result.Where(x => x.MaximumCapacity == maxCap);
            }

            return result;
        }

        public IEnumerable<DepotTank> GetFilterByCenterPermission(string userName, string bowserNumber, string name, decimal currentVol, decimal maxCap)
        {
            if (!string.IsNullOrEmpty(userName))
            {

                return from a in GetAll(bowserNumber, name, currentVol, maxCap)
                       join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == userName) 
                       on a.CenterId equals b.CenterId select a;

            }
            return GetAll(bowserNumber, name, currentVol, maxCap);
        }

        public IEnumerable<DepotTank> GetTankListByPermission(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                return from a in GetAll()
                       join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == userName)
                       on a.CenterId equals b.CenterId select a;

            }
            return GetAll();
        }

        public DepotTank GetDepotTankById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var depotTank = GetAll().FirstOrDefault(x => x.BowserNumber == id);
                if (depotTank != null)
                {
                    return depotTank;
                }
            }
            return new DepotTank { BowserNumber = id };
        }

        public bool IsInUse(string id)
        {
            return unitOfWork.DepotTankRepository.GetAll().Any(x => x.BowserNumber == id);
        }

        public bool IsBrowserNumberExist(string browserNumber)
        {
            bool value = unitOfWork.DepotTankRepository.GetAll().Any(x => x.BowserNumber == browserNumber);
            return value;
        }


        #endregion
        #region CRUD Methods
        public void Create(DepotTank depotTank)
        {
            unitOfWork.DepotTankRepository.Add(depotTank);
        }

        public void Delete(DepotTank depotTank)
        {
            unitOfWork.DepotTankRepository.Delete(depotTank);
        }

        public void Update(DepotTank depotTank)
        {
            unitOfWork.DepotTankRepository.Update(depotTank);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }



        #endregion


    }
}
