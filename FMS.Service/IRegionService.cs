
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IRegionService
    {
        #region Get methods

        IEnumerable<Regional> GetAll();
        Regional GetRegionalById(int regionNumber);

        IEnumerable<Regional> GetRegionFilterByCenterPermission(string userName);
        #endregion

        #region CRUD Methods
        void Create(Regional regional);
        void Update(Regional regional);
        void Delete(Regional regional);       
        int Save();
        #endregion
    }
}
