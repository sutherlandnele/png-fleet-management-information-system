
using System;
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IAppInterfaceService
    {
        #region Get Methods
        AppInterface GetById(int id);
        IEnumerable<AppInterface> GetAll();

        #endregion

        #region CRUD Methods
        void Create(AppInterface appInterface);
        void Delete(AppInterface appInterface);
        void Update(AppInterface appInterface);
        int Save();
        #endregion




    }
}
