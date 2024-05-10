using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;

namespace FMS.Data.Repositories
{
    public interface ISqlAuditRepository : IRepository<SqlAudit>
    {
        #region Get Public Methods
        IEnumerable<SqlAudit> GetAllAuditsDescending();
        SqlAudit GetSqlAuditById(int Id);
        
        

        #endregion
    }
}
