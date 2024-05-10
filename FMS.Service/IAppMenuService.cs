
using System;
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IAppMenuService
    {
        #region Get Methods
        AppMenu GetById(int id);
        IEnumerable<AppMenu> GetAll();

        #endregion

        #region CRUD Methods
        void Create(AppMenu appMenu);
        void Delete(AppMenu appMenu);
        void Update(AppMenu appMenu);
        int Save();
        #endregion




    }
}
