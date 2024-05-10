
using System;
using System.Collections.Generic;
using FMS.Common;
using FMS.Model;



namespace FMS.Service
{
    public interface IAppRoleInterfaceAccessService
    {
        #region Get Methods
        AppRoleInterfaceAccess GetById(int id);
        IEnumerable<AppRoleInterfaceAccess> GetAll();
        IEnumerable<AppRoleInterfaceAccess> GetAll(string role);
        void ChangeStatus(int interfaceId, bool status, string role);
        void RemoveRoleInterface(string roleName);
        bool CanAccess(Parameters.Interface interfaceName, string role);
        bool CanAccess(int interfaceId, string role);

        #endregion

        #region CRUD Methods
        void Create(AppRoleInterfaceAccess appRoleInterfaceAccess);
        void Delete(AppRoleInterfaceAccess appRoleInterfaceAccess);
        void Update(AppRoleInterfaceAccess appRoleInterfaceAccess);
        int Save();
        #endregion




    }
}
