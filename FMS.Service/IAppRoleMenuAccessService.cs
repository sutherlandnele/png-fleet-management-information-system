
using System;
using System.Collections.Generic;
using FMS.Common;
using FMS.Model;



namespace FMS.Service
{
    public interface IAppRoleMenuAccessService
    {
        #region Get Methods
        AppRoleMenuAccess GetById(int id);
        IEnumerable<AppRoleMenuAccess> GetAll();

        IEnumerable<AppRoleMenuAccess> GetAll(string role);

        void ChangeStatus(int menuId, bool status, string role);

        bool CanAccess(Parameters.MenuName item, string role);

        bool CanAccess(int menuId, string role);

        void RemoveRoleMenu(string roleName);

        #endregion

        #region CRUD Methods
        void Create(AppRoleMenuAccess appRoleMenuAccess);
        void Delete(AppRoleMenuAccess appRoleMenuAccess);
        void Update(AppRoleMenuAccess appRoleMenuAccess);
        int Save();
        #endregion




    }
}
