
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System;
using FMS.Common;

namespace FMS.Service
{
    public class AppRoleMenuAccessService : IAppRoleMenuAccessService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AppRoleMenuAccessService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Get Methods

        public AppRoleMenuAccess GetById(int id)
        { 
            if (id > 0)
            {
                var appRoleMenuAccess = GetAll().FirstOrDefault(x => x.MenuId == id);

                if (appRoleMenuAccess != null)
                {
                    return appRoleMenuAccess;
                }
}
            return new AppRoleMenuAccess { MenuId = -1 };
        }

        public IEnumerable<AppRoleMenuAccess> GetAll()
        {
            return unitOfWork.AppRoleMenuAccessRepository.GetAll().OrderByDescending(m => m.MenuId);
        }

        public IEnumerable<AppRoleMenuAccess> GetAll(string role)
        {
            return GetAll().Where(x => x.RoleName == role);
        }

        public void ChangeStatus(int menuId, bool status, string role)
        {
            AppRoleMenuAccess item = GetAll(role).FirstOrDefault(x => x.MenuId == menuId);

            if (item != null)
            {
                Delete(item);
                Save();
            }
            if (status)
            {
                item = new AppRoleMenuAccess();
                item.MenuId = menuId;
                item.RoleName = role;

                Create(item);
                Save();
            }
        }

        public bool CanAccess(Parameters.MenuName item, string role)
        {
            if (role == unitOfWork.RoleRepository.FindByName(Parameters.AppConstant.ADMIN_ROLE_NAME).Name)
                return true;
            return GetAll().Any(x => x.MenuId == Convert.ToInt32(item) && x.RoleName == role);
        }

        public bool CanAccess(int menuId, string role)
        {
            if (role == unitOfWork.RoleRepository.FindByName(Parameters.AppConstant.ADMIN_ROLE_NAME).Name)
                return true;
            return GetAll().Any(x => x.MenuId == menuId && x.RoleName == role);
        }


        public void RemoveRoleMenu(string roleName)
        {
            var _roleMenu = GetAll(roleName).ToList();

            foreach (var item in _roleMenu)
            {
                Delete(item);
                Save();
            }
        }

        #endregion

        #region CRUD Methods       

        public void Create(AppRoleMenuAccess appRoleMenuAccess)
        {
            unitOfWork.AppRoleMenuAccessRepository.Add(appRoleMenuAccess);
        }
        public void Delete(AppRoleMenuAccess appRoleMenuAccess)
        {
            unitOfWork.AppRoleMenuAccessRepository.Delete(appRoleMenuAccess);
        }
        public void Update(AppRoleMenuAccess appRoleMenuAccess)
        {
            unitOfWork.AppRoleMenuAccessRepository.Update(appRoleMenuAccess);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }




        #endregion


    }
}
