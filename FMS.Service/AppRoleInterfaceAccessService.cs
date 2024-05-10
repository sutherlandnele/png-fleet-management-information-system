
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System;
using FMS.Common;

namespace FMS.Service
{
    public class AppRoleInterfaceAccessService : IAppRoleInterfaceAccessService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AppRoleInterfaceAccessService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Get Methods
        public AppRoleInterfaceAccess GetById(int id)
        {
            if (id == -1)
            {
                return new AppRoleInterfaceAccess { InterfaceId = -1 };
            }
            return GetAll().FirstOrDefault(x => x.InterfaceId == id);
        }

        public IEnumerable<AppRoleInterfaceAccess> GetAll()
        {
            return unitOfWork.AppRoleInterfaceAccessRepository.GetAll().OrderByDescending(m => m.InterfaceId);
        }

        public IEnumerable<AppRoleInterfaceAccess> GetAll(string role)
        {
            return GetAll().Where(x => x.RoleName == role);
        }

        public void ChangeStatus(int interfaceId, bool status, string role)
        {
            AppRoleInterfaceAccess item = GetAll(role).FirstOrDefault(x => x.InterfaceId == interfaceId);

            if (item != null)
            {
                Delete(item);
                Save();
            }
            if (status)
            {
                item = new AppRoleInterfaceAccess();
                item.InterfaceId = interfaceId;
                item.RoleName = role;

                Create(item);
                Save();
            }
        }

        public void RemoveRoleInterface(string roleName)
        {
            var _roleInterface = GetAll(roleName).ToList();
            foreach (var item in _roleInterface)
            {
                Delete(item);
                Save();
            }
        }

        public bool CanAccess(Parameters.Interface interfaceName, string role)
        {
            if (role == unitOfWork.RoleRepository.FindByName(Parameters.AppConstant.ADMIN_ROLE_NAME).Name)
            {
                return true;
            }
            return GetAll().Any(x => x.InterfaceId == Convert.ToInt32(interfaceName) && x.RoleName == role);
        }

        public bool CanAccess(int interfaceId, string role)
        {
            if (role == unitOfWork.RoleRepository.FindByName(Parameters.AppConstant.ADMIN_ROLE_NAME).Name)
            {
                return true;
            }
            return GetAll().Any(x => x.InterfaceId == interfaceId && x.RoleName == role);
        }


        #endregion

        #region CRUD Methods       

        public void Create(AppRoleInterfaceAccess appRoleInterfaceAccess)
        {
            unitOfWork.AppRoleInterfaceAccessRepository.Add(appRoleInterfaceAccess);
        }
        public void Delete(AppRoleInterfaceAccess appRoleInterfaceAccess)
        {
            unitOfWork.AppRoleInterfaceAccessRepository.Delete(appRoleInterfaceAccess);
        }
        public void Update(AppRoleInterfaceAccess appRoleInterfaceAccess)
        {
            unitOfWork.AppRoleInterfaceAccessRepository.Update(appRoleInterfaceAccess);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }
        #endregion


    }
}
