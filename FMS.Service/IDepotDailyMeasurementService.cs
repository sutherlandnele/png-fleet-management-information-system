
using System;
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IDepotDailyMeasurementService
    {
        #region Get methods

        IEnumerable<DepotDailyMeasurement> GetAll();

        IEnumerable<DepotDailyMeasurement> GetAll(int centerId, DateTime? date, string bowserNo);

        IEnumerable<DepotDailyMeasurement> GetFilterByCenterPermission(string currentUser, int centerId, DateTime? date, string bowserNo);

        DepotDailyMeasurement GetDepotDailyMeasurementById(int id);

        #endregion

        #region CRUD Methods
        void Create(DepotDailyMeasurement depotDailyMeasurement);
        void Update(DepotDailyMeasurement depotDailyMeasurement);
        void Delete(DepotDailyMeasurement depotDailyMeasurement);       
        int Save();
        #endregion
    }
}
