
using System.Collections.Generic;
using FMS.Common;
using FMS.Model;



namespace FMS.Service
{
    public interface IOperatorService
    {
        #region Get methods
        IEnumerable<Operator> GetAll();
        IEnumerable<Operator> GetAll(int center, string driverName, int groupNumber, bool custodian);
        IEnumerable<Operator> GetFilterByCenterPermission(string userName, int center, string driverName, int groupNumber, bool custodian);
        Operator GetOperatorById(int id);
        bool CanDelete(int id);

        #endregion

        #region CRUD Methods
        void Create(Operator op);
        void Update(Operator op);
        void Delete(Operator op);       
        int Save();
        #endregion
     

    }
}
