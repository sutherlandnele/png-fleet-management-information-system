
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System;

namespace FMS.Service
{
    public class DepotDailyMeasurementService : IDepotDailyMeasurementService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public DepotDailyMeasurementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
        #region Get Methods
        public IEnumerable<DepotDailyMeasurement> GetAll()
        {
            return unitOfWork.DepotDailyMeasurementRepository.GetAll();
        }

        public IEnumerable<DepotDailyMeasurement> GetAll(int centerId, DateTime? date, string bowserNo)
        {
            var result = GetAll();

            if (centerId != -1)
            {
                result = result.Where(x => x.Center != null && x.Center.CenterNumber == centerId);
            }
            if (date != null)
            {
                result = result.Where(x => x.Date == date);
            }
            if (bowserNo != string.Empty)
            {
                result = result.Where(x => string.Compare(x.DepotTank.BowserNumber, bowserNo, true) == 0);

            }

            return result;
        }

        public IEnumerable<DepotDailyMeasurement> GetFilterByCenterPermission(string currentUser, int centerId, DateTime? date, string bowserNo)
        {
            var result = GetAll(centerId, date, bowserNo);
           
            if (!string.IsNullOrEmpty(currentUser))
            {
                result = from a in GetAll()
                         where a.DepotTank != null
                         join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == currentUser)
                         on a.DepotTank.CenterId equals b.CenterId
                         select a;

                if (centerId > 0)
                {
                    result = result.Where(x => x.CenterId == centerId);
                }
                if (date != null)
                {
                    result = result.Where(x => x.Date == date);
                }
                if (!string.IsNullOrEmpty(bowserNo))
                {                   
                    result = result.Where(x => x.DepotTank.BowserNumber.ToLower().Contains(bowserNo.ToLower()));
                }
            }
            return result.OrderByDescending(m=>m.Id);
        }

        public DepotDailyMeasurement GetDepotDailyMeasurementById(int id)
        {
            if (id > 0)
            {
                var depotDailyMeasurement = GetAll().FirstOrDefault(x => x.Id == id);
                if (depotDailyMeasurement != null)
                {
                    return depotDailyMeasurement;
                }
            }
            return new DepotDailyMeasurement { Id = -1 };
        }


        #endregion
        #region CRUD Methods
        public void Create(DepotDailyMeasurement depotDailyMeasurement)
        {
            unitOfWork.DepotDailyMeasurementRepository.Add(depotDailyMeasurement);
        }

        public void Delete(DepotDailyMeasurement depotDailyMeasurement)
        {
            unitOfWork.DepotDailyMeasurementRepository.Delete(depotDailyMeasurement);
        }

        public void Update(DepotDailyMeasurement depotDailyMeasurement)
        {
            unitOfWork.DepotDailyMeasurementRepository.Update(depotDailyMeasurement);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }



        #endregion


    }
}
