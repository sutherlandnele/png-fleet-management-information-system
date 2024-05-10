
using System.Collections.Generic;
using FMS.Model;
using FMS.Common;



namespace FMS.Service
{
    public interface ISystemParameterCodeService
    {
        #region Get methods
        IEnumerable<SystemParameterCode> GetAll();
        int? GetSystemParameterCodeIdByCodeText(string code);

        #endregion

        #region CRUD Methods
        void Create(SystemParameterCode systemParameterCode);
        void Update(SystemParameterCode systemParameterCode);
        void Delete(SystemParameterCode systemParameterCode);
        int Save();
        #endregion


    }
}
