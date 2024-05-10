
using System.Collections.Generic;
using FMS.Model;
using FMS.Common;



namespace FMS.Service
{
    public interface ISystemParameterService
    {
        #region Get methods
        IEnumerable<SystemParameter> GetAll();       
        IEnumerable<SystemParameter> GetAllFilterByParameterType(int parameterType);
        string GetSystemParameterNameByCodeId(int code);
        bool IsInUse(int id);

        #endregion


        #region CanDelete
        bool CanDeleteFuel(int id);
        bool CanDeleteAcquisition(int id);
        bool CanDeleteStatus(int id);
        bool CanDeleteCondition(int id);
        bool CanDeleteService(int id);
        bool CanDeleteOperator(int id);
        bool CanDeleteTransmission(int id);
        bool CanDeleteVehicleType(int id);
        bool CanDeleteCenter(int id);
        bool CanDeleteIncidentType(int id);
        bool CanDeleteServiceProvider(int id);
        bool CanDeleteNotificationType(int id);
        bool CanDeleteSeverity(int id);
        bool CanDeleteWhenAppear(int id);
        bool CanDeleteGender(int id);
        bool CanDeleteContactType(int id);
        bool CanDeleteServiceType(int id);
        #endregion

        #region CRUD Methods
        void Create(SystemParameter systemParameter);
        void Update(SystemParameter systemParameter);
        void Delete(SystemParameter systemParameter);
        int Save();
        #endregion


    }
}
