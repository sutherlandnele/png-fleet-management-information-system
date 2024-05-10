
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IBusinessUnitService
    {
        #region Get methods
        IEnumerable<BusinessUnit> GetAll();
        IEnumerable<BusinessUnit> GetAll(string name, int manager);
        BusinessUnit GetBusinessUnitById(int unitNumber);
        bool IsInUse(int id);
        #endregion

        #region CRUD Methods
        void Create(BusinessUnit businessUnit);
        void Update(BusinessUnit businessUnit);
        void Delete(BusinessUnit businessUnit);       
        int Save();
        #endregion
     

    }
}
