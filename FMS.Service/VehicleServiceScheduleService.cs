
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using VehicleService = FMS.Model.Service;
using System;

namespace FMS.Service
{
    public class VehicleServiceScheduleService : IVehicleServiceScheduleService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public VehicleServiceScheduleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region CRUD Methods
        public void Create(ScheduleService scheduleService)
        {
            unitOfWork.ScheduleServiceRepository.Add(scheduleService);
        }

        public void Delete(ScheduleService scheduleService)
        {
            unitOfWork.ScheduleServiceRepository.Delete(scheduleService);
        }

        public void Update(ScheduleService scheduleService)
        {
            unitOfWork.ScheduleServiceRepository.Update(scheduleService);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }


        #endregion

        #region Get Methods
        public IEnumerable<ScheduleService> GetAll()
        {
            return unitOfWork.ScheduleServiceRepository.GetAll();
        }

        public IEnumerable<ScheduleService> GetAll(string registrationNumber, int groupNumber, int centerNumber)
        {
            var result = GetAll();

            if (!string.IsNullOrEmpty(registrationNumber))
            {
                result = result.Where(x => x.Vehicle != null && x.Vehicle.RegistrationNumber.ToUpper().Contains(registrationNumber.ToUpper()));
            }
            if (groupNumber != -1)
            {
                result = result.Where(x => x.Vehicle != null && x.Vehicle.BusinessGroupId == groupNumber);
            }

            if (centerNumber != -1)
            {
                result = result.Where(x => x.Vehicle != null && x.Vehicle.CenterId == centerNumber);
            }
            return result;
        }

        public IEnumerable<ScheduleService> GetFilterByCenterPermission(string currentUser, string registrationNumber, int groupNumber, int centerNumber)
        {
            var result = GetAll(registrationNumber, groupNumber, centerNumber);

            if (!string.IsNullOrEmpty(currentUser))
            {


                result = from a in result
                         where a.Vehicle != null
                         join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == currentUser)
                         on a.Vehicle.CenterId equals b.CenterId
                         select a;

            }
            return result.OrderByDescending(vss=>vss.Id);
        }

        public ScheduleService GetScheduleServiceById(int id)
        {
            if (id > 0)
                return GetAll().FirstOrDefault(x => x.Id == id);
            else
                return new ScheduleService { Id = -1 };
        }

        public IEnumerable<ScheduleService> GetVehicleListByScheduleServiceRenewal()
        {
            return GetAll().Where(x => x.ServiceAlertDate.HasValue 
                && x.ServiceAlertDate.Value.Date != DateTime.MinValue 
                && x.HasServiceBeenDone == false 
                && (int)(DateTime.Now.Date.Subtract(x.ServiceAlertDate.Value)).Days <= 30);
        }

        #endregion

    }
}
