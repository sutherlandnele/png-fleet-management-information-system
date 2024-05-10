
using System.Collections.Generic;
using FMS.Model;

namespace FMS.Service
{
    public interface ICenterSecurityService
    {
        #region Get methods
        IEnumerable<CenterSecurity> GetAll();
        CenterSecurity GetByUserName(string username, int centerNumber);

        IEnumerable<CenterSecurity> GetByUserName(string username);

        bool UserExists(string userName);

        bool CenterSecurityExists(string userName, int centerId);

        #endregion

        #region CRUD Methods
        void Create(CenterSecurity centerSecurity);
        void Update(CenterSecurity centerSecurity);
        void Delete(CenterSecurity centerSecurity);       
        int Save();
        #endregion
     

    }
}
