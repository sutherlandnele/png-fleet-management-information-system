
using System.Collections.Generic;
using FMS.Model;

namespace FMS.Service
{
    public interface IAppIssueService
    {
        #region Get methods
        IEnumerable<AppIssue> GetAll();
        AppIssue GetById(int id);

        #endregion

        #region CRUD Methods
        void Create(AppIssue appIssue);
        void Update(AppIssue appIssue);
        void Delete(AppIssue appIssue);
        int Save();
        #endregion    

    }
}
