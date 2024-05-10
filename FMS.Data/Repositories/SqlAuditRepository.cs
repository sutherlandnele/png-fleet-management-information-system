using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System.Collections.Generic;

namespace FMS.Data.Repositories
{
    internal class SqlAuditRepository : RepositoryBase<SqlAudit>, ISqlAuditRepository
    {
        #region Constructor
        internal SqlAuditRepository(IDbFactory dbFactory): base(dbFactory) {

        }
        #endregion

        #region Get Public Methods
        public IEnumerable<SqlAudit> GetAllAuditsDescending()
        {
            return GetAll().OrderByDescending(x => x.Id);
        }
        public SqlAudit GetSqlAuditById(int id)
        {
            if (id > 0)
            {

                var sqlAudit = GetAll().FirstOrDefault(x => x.Id == id);
                if (sqlAudit != null)
                {
                    return sqlAudit;
                }
            }
            return new SqlAudit { Id = -1 };
        }

        #endregion
    }

}
