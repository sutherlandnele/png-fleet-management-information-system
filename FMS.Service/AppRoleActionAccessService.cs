
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System;
using FMS.Common;

namespace FMS.Service
{
    public class AppRoleActionAccessService : IAppRoleActionAccessService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AppRoleActionAccessService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Get Methods
        public AppRoleActionAccess GetById(int id)
        {
            if (id == -1)
            {
                return new AppRoleActionAccess { ActionId = -1 };
            }
            return GetAll().FirstOrDefault(x => x.ActionId == id);
        }

        public IEnumerable<AppRoleActionAccess> GetAll()
        {
            return unitOfWork.AppRoleActionAccessRepository.GetAll().OrderByDescending(m => m.ActionId);
        }

        public IEnumerable<AppRoleActionAccess> GetAll(string role)
        {
            return GetAll().Where(x => x.RoleName == role);
        }

        public void ChangeStatus(int actionId, bool status, string role)
        {
            AppRoleActionAccess item = GetAll(role).FirstOrDefault(x => x.ActionId == actionId);

            if (item != null)
            {
                Delete(item);
                Save();
            }
            if (status)
            {
                item = new AppRoleActionAccess();
                item.ActionId = actionId;
                item.RoleName = role;

                Create(item);
                Save();
            }
        }

        public void RemoveRoleAction(string roleName)
        {
            var m = GetAll(roleName).ToList();
            foreach (var item in m)
            {
                Delete(item);
                Save();
            }
        }

        public bool CanAccess(Parameters.Action action, string role)
        {
            if (role == unitOfWork.RoleRepository.FindByName(Parameters.AppConstant.ADMIN_ROLE_NAME).Name)
            {
                return true;
            }
            return GetAll().Any(x => x.ActionId == Convert.ToInt32(action) && x.RoleName == role);
        }

        public bool CanAccess(int actionId, string role)
        {
            if (role == unitOfWork.RoleRepository.FindByName(Parameters.AppConstant.ADMIN_ROLE_NAME).Name)
            {
                return true;
            }
            return GetAll().Any(x => x.ActionId == actionId && x.RoleName == role);
        }



        #endregion

        #region CRUD Methods       

        public void Create(AppRoleActionAccess appRoleActionAccess)
        {
            unitOfWork.AppRoleActionAccessRepository.Add(appRoleActionAccess);
        }
        public void Delete(AppRoleActionAccess appRoleActionAccess)
        {
            unitOfWork.AppRoleActionAccessRepository.Delete(appRoleActionAccess);
        }
        public void Update(AppRoleActionAccess appRoleActionAccess)
        {
            unitOfWork.AppRoleActionAccessRepository.Update(appRoleActionAccess);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }
        #endregion


    }
}
