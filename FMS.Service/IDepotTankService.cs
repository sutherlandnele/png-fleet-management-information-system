
using System;
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IDepotTankService
    {
        #region Get methods

        IEnumerable<DepotTank> GetAll();
        IEnumerable<DepotTank> GetAll(string bowserNumber, string name, decimal currentVol, decimal maxCap);

        IEnumerable<DepotTank> GetFilterByCenterPermission(string userName, string bowserNumber, string name, decimal currentVol, decimal maxCap);

        IEnumerable<DepotTank> GetTankListByPermission(string userName);

        DepotTank GetDepotTankById(string id);

        bool IsInUse(string id);

        bool IsBrowserNumberExist(string browserNumber);

        #endregion

        #region CRUD Methods
        void Create(DepotTank depotTank);
        void Update(DepotTank depotTank);
        void Delete(DepotTank depotTank);       
        int Save();
        #endregion
    }
}
