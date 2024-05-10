
using System;
using System.Collections.Generic;
using FMS.Model;

namespace FMS.Service
{
    public interface IComplianceService
    {
        #region Get methods
        IEnumerable<Compliance> GetAll();
        IEnumerable<Compliance> GetAllRegistryByCenterPermission(string userName, int regNumber);
        IEnumerable<Compliance> GetAllRegistry(int regNumber);
        IEnumerable<Compliance> GetSafetyStickerRegistry(int regNumber);
        IEnumerable<Compliance> GetSafetyStickerRegistryByCenterPermission(string userName, int regNumber);
        Compliance GetComplianceById(int complianceNumber);

        #endregion

        #region CRUD Methods
        void Create(Compliance compliance);
        void Update(Compliance compliance);
        void Delete(Compliance compliance);
        int Save();
        #endregion
     

    }
}
