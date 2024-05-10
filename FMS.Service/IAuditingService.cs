
using System;
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IAuditingService
    {
        #region Get Methods
        IEnumerable<SqlAudit> GetAll();

        IEnumerable<SqlAudit> GetAll(DateTime? startDate, DateTime? endDate);

        SqlAudit GetSqlAuditById(int Id);

        #endregion
        #region CRUD Methods
        bool DeleteAll();
        void Clear(IEnumerable<SqlAudit> sqlAudits);
        void Create(SqlAudit sqlAudit);
        void Delete(SqlAudit sqlAudit);
        void Update(SqlAudit sqlAudit);
        int Save();
        #endregion




    }
}
