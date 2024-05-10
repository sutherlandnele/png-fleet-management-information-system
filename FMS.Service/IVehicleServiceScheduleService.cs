
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IVehicleServiceScheduleService
    {
        #region Get methods

        IEnumerable<ScheduleService> GetAll();
        IEnumerable<ScheduleService> GetAll(string registrationNumber, int groupNumber, int centerNumber);
        IEnumerable<ScheduleService> GetFilterByCenterPermission(string currentUser, string registrationNumber, int groupNumber, int centerNumber);
        ScheduleService GetScheduleServiceById(int id);
        IEnumerable<ScheduleService> GetVehicleListByScheduleServiceRenewal();

        #endregion

        #region CRUD Methods
        void Create(ScheduleService scheduleService);
        void Update(ScheduleService scheduleService);
        void Delete(ScheduleService scheduleService);
        int Save();
        #endregion


    }
}
