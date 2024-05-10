
using System;
using System.Collections.Generic;
using FMS.Common;
using FMS.Model;



namespace FMS.Service
{
    public interface IAppRoleActionAccessService
    {
        #region Get Methods
        AppRoleActionAccess GetById(int id);
        IEnumerable<AppRoleActionAccess> GetAll();
        IEnumerable<AppRoleActionAccess> GetAll(string role);
        void ChangeStatus(int actionId, bool status, string role);
        void RemoveRoleAction(string roleName);
        bool CanAccess(Parameters.Action action, string role);

        bool CanAccess(int actionId, string role);

        #endregion

        #region CRUD Methods
        void Create(AppRoleActionAccess appRoleActionAccess);
        void Delete(AppRoleActionAccess appRoleActionAccess);
        void Update(AppRoleActionAccess appRoleActionAccess);
        int Save();
        #endregion




    }
}
