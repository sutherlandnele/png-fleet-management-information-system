
using System;
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IDepotRefuelService
    {
        #region Get methods
        IEnumerable<DepotRefuel> GetAll();

        DepotRefuel GetDepotRefuelById(int id);

        IEnumerable<DepotRefuel> GetFilterByCenterPermission(string currentUser, string bowserNumber, int center);

        DepotTank GetPreviousVolume(string bowserNumeber);

        #endregion

        #region CRUD Methods
        void Create(DepotRefuel depotRefuel);
        void Update(DepotRefuel depotRefuel);
        void Delete(DepotRefuel depotRefuel);
        int Save();
        #endregion
    }
}
