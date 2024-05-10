
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IIncidentService
    {
        #region Get methods
        bool CanDelete(int id);
        IEnumerable<Incident> GetAll();
        IEnumerable<Incident> GetAll(string regNum, string fileNumber, int incidentStatus, int incidentType, int center, int groupNumber);
        IEnumerable<Incident> GetFilterByCenterPermission(string currentUser);

        IEnumerable<Incident> GetFilterByCenterPermission(string currentUser, int vehicleId, string fileNumber, int incidentType);

        IEnumerable<Incident> GetFilterByCenterPermission(string currentUser, string regNum, string fileNumber, int incidentStatus, int incidentType, int center, int groupNumber);
        Incident GetIncidentById(int id);
        #endregion

        #region CRUD Methods
        void Create(Incident incident);
        void Update(Incident incident);
        void Delete(Incident incident);       
        int Save();
        #endregion


    }
}
