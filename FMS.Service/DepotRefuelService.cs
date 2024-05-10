
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System;

namespace FMS.Service
{
    public class DepotRefuelService : IDepotRefuelService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion
        #region Constructors
        public DepotRefuelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
        #region Get Methods
        public IEnumerable<DepotRefuel> GetAll()
        {
            return unitOfWork.DepotRefuelRepository.GetAll();
        }

        public DepotRefuel GetDepotRefuelById(int id)
        {
            if (id > 0)
            {
                var depotRefuel = GetAll().FirstOrDefault(x => x.Id == id);
                if (depotRefuel != null)
                {
                    return depotRefuel;
                }
            }
            return new DepotRefuel { Id = -1 };
        }

        public IEnumerable<DepotRefuel> GetFilterByCenterPermission(string currentUser, string bowserNumber, int center)
        {
            var result = GetAll();
            
            result = from a in GetAll()
                     where a.DepotTank != null
                     join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == currentUser)
                     on a.DepotTank.CenterId equals b.CenterId
                     select a;


            if (!string.IsNullOrEmpty(bowserNumber))
            {                
                result = result.Where(x => x.BowserNumber.ToLower().Contains(bowserNumber.ToLower()));
            }
            if (center > 0)
            {
                result = result.Where(x => x.CenterId == center);
            }
            return result.OrderByDescending(r=>r.Id);
        }

        public DepotTank GetPreviousVolume(string bowserNumeber)
        {
            return unitOfWork.DepotTankRepository.GetAll().Where(x => x.BowserNumber == bowserNumeber).FirstOrDefault();
        }
        
        #endregion
        #region CRUD Methods
        public void Create(DepotRefuel depotRefuel)
        {
            unitOfWork.DepotRefuelRepository.Add(depotRefuel);
        }

        public void Delete(DepotRefuel depotRefuel)
        {
            unitOfWork.DepotRefuelRepository.Delete(depotRefuel);
        }

        public void Update(DepotRefuel depotRefuel)
        {
            unitOfWork.DepotRefuelRepository.Update(depotRefuel);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }      


        #endregion


    }
}
