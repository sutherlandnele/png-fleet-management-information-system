
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class AlertService : IAlertService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AlertService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region CRUD Methods
        public void Create(Alert alert)
        { 
            unitOfWork.AlertRepository.Add(alert);
        }

        public void Delete(Alert alert)
        {
            unitOfWork.AlertRepository.Delete(alert);
        }

        public void Update(Alert alert)
        {
            unitOfWork.AlertRepository.Update(alert);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }



        #endregion

        #region Get Methods
        public IEnumerable<Alert> GetAll()
        {
            return unitOfWork.AlertRepository.GetAll().OrderByDescending(m => m.Id);
        }

        public Alert GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }


        #endregion
    }
}
