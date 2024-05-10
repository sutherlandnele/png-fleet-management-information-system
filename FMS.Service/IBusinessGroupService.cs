
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IBusinessGroupService
    {
        #region Get methods
        IEnumerable<BusinessGroup> GetAll();
        IEnumerable<BusinessGroup> GetAll(string name, int manager, int businessUnit);
        BusinessGroup GetBusinessGroupById(int groupNumber);        
        IEnumerable<BusinessGroup> GetBusinessGroupByBusinessUnit(int businessUnitId);
        IEnumerable<BusinessGroupSecurity> GetBusinessGroupSecurityForUser(string userId);
        IEnumerable<BusinessGroup> GetBusinessGroup(string Username);
        BusinessUnit GetBusinessGroupBusinessUnit(int id);
        bool IsInUse(int groupNumber);
        #endregion

        #region CRUD Methods
        void Create(BusinessGroup businessGroup);
        void Update(BusinessGroup businessGroup);
        void Delete(BusinessGroup businessGroup);       
        int Save();
        #endregion
     

    }
}
