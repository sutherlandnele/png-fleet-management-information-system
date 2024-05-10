
using System.Collections.Generic;
using FMS.Model;

namespace FMS.Service
{
    public interface ICenterService
    {
        #region Get methods
        IEnumerable<Center> GetAll();
        Center GetByCenterNumber(int centernumber);
        IEnumerable<Center> GetAllCenterWithPermission(string UserName);
        IEnumerable<Center> GetAllCenterWithPermission(string userName, string centerName, int region);
        Center GetById(int id, string userName);
        Center GetCenterFromId(int centerId);
        Regional GetCenterRegion(int centerId); 
        bool IsInUse(int id);

        int GetNextServiceNumberForMonth(int centerId, string mm, string yy);
        int GetNextFuelVoucherNumberForMonth(int centerId, string mm, string yy);

        bool HasUnacquittedFuelVouchers(int centerId);

        #endregion

        #region CRUD Methods
        void Create(Center center);
        void Update(Center center);
        void Delete(Center center);       
        int Save();
        #endregion
     

    }
}
