
using System;
using System.Collections.Generic;
using FMS.Model;

namespace FMS.Service
{
    public interface IAlertService
    {
        #region Get methods
        IEnumerable<Alert> GetAll();
        Alert GetById(int id);

        #endregion

        #region CRUD Methods
        void Create(Alert alert);
        void Update(Alert alert);
        void Delete(Alert alert);
        int Save();
        #endregion
     

    }
}
