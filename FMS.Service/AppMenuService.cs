
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System;

namespace FMS.Service
{
    public class AppMenuService : IAppMenuService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AppMenuService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Get Methods

        public AppMenu GetById(int id)
        {
            if (id == -1)
            {
                return new AppMenu { MenuId = -1 };
            }
            return unitOfWork.AppMenuRepository.GetAll().FirstOrDefault(x => x.MenuId == id);
        }

        public IEnumerable<AppMenu> GetAll()
        {
            return unitOfWork.AppMenuRepository.GetAll().OrderByDescending(m => m.MenuId);
        }

        #endregion

        #region CRUD Methods       

        public void Create(AppMenu appMenu)
        {
            unitOfWork.AppMenuRepository.Add(appMenu);
        }
        public void Delete(AppMenu appMenu)
        {
            unitOfWork.AppMenuRepository.Delete(appMenu);
        }
        public void Update(AppMenu appMenu)
        {
            unitOfWork.AppMenuRepository.Update(appMenu);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }


        #endregion


    }
}
