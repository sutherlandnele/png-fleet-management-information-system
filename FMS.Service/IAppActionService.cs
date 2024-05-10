
using System;
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IAppActionService
    {
        #region Get Methods
        AppAction GetById(int id);
        IEnumerable<AppAction> GetAll();

        #endregion

        #region CRUD Methods
        void Create(AppAction appAction);
        void Delete(AppAction appAction);
        void Update(AppAction appAction);
        int Save();
        #endregion




    }
}
