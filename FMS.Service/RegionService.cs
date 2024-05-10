
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;


namespace FMS.Service
{
    public class RegionService : IRegionService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public RegionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
        #region Get Methods
        public IEnumerable<Regional> GetAll()
        {
            return unitOfWork.RegionRepository.GetAll();
        }

        public Regional GetRegionalById(int regionNumber) {
            return unitOfWork.RegionRepository.GetById(regionNumber);
        }

        public IEnumerable<Regional> GetRegionFilterByCenterPermission(string userName)
        {
            var regions = from c in unitOfWork.CenterRepository.GetAll()
                          join s in unitOfWork.CenterSecurityRepository.GetAll(userName)
                          on c.CenterNumber equals s.CenterId
                          join r in unitOfWork.RegionRepository.GetAll()
                          on c.RegionaNumberId equals r.RegionNumber
                          select r;

            return regions;
        }

        #endregion
        #region CRUD Methods
        public void Create(Regional regional)
        {
            unitOfWork.RegionRepository.Add(regional);
        }

        public void Delete(Regional regional)
        {
            unitOfWork.RegionRepository.Delete(regional);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }

        public void Update(Regional regional)
        {
            unitOfWork.RegionRepository.Update(regional);
        }


        #endregion


    }
}
