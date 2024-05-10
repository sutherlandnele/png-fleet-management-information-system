
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System;

namespace FMS.Service
{
    public class AppActionService : IAppActionService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AppActionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Get Methods

        public AppAction GetById(int id)
        {
            if (id == -1)
            {
                return new AppAction { ActionId = -1 };
            }
            return unitOfWork.AppActionRepository.GetAll().FirstOrDefault(x => x.ActionId == id);
        }

        public IEnumerable<AppAction> GetAll()
        {
            return unitOfWork.AppActionRepository.GetAll().OrderByDescending(m => m.ActionId);
        }

        #endregion

        #region CRUD Methods       

        public void Create(AppAction appAction)
        {
            unitOfWork.AppActionRepository.Add(appAction);
        }
        public void Delete(AppAction appAction)
        {
            unitOfWork.AppActionRepository.Delete(appAction);
        }
        public void Update(AppAction appAction)
        {
            unitOfWork.AppActionRepository.Update(appAction);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }


        #endregion


    }
}
