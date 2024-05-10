
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System;

namespace FMS.Service
{
    public class AppInterfaceService : IAppInterfaceService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AppInterfaceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Get Methods

        public AppInterface GetById(int id)
        {
            if (id == -1)
            {
                return new AppInterface { InterfaceId = -1 };
            }
            return unitOfWork.AppInterfaceRepository.GetAll().FirstOrDefault(x => x.InterfaceId == id);
        }

        public IEnumerable<AppInterface> GetAll()
        {
            return unitOfWork.AppInterfaceRepository.GetAll().OrderByDescending(m => m.InterfaceId);
        }

        #endregion

        #region CRUD Methods       

        public void Create(AppInterface appInterface)
        {
            unitOfWork.AppInterfaceRepository.Add(appInterface);
        }
        public void Delete(AppInterface appInterface)
        {
            unitOfWork.AppInterfaceRepository.Delete(appInterface);
        }
        public void Update(AppInterface appInterface)
        {
            unitOfWork.AppInterfaceRepository.Update(appInterface);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }


        #endregion


    }
}
