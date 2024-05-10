
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using System;

namespace FMS.Service
{
    public class AuditingService : IAuditingService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AuditingService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Get Methods
        public IEnumerable<SqlAudit> GetAll()
        {
            return unitOfWork.SqlAuditRepository.GetAll().OrderByDescending(m => m.Id);
        }

        public IEnumerable<SqlAudit> GetAll(DateTime? startDate, DateTime? endDate)
        {
            if(startDate != null && endDate !=null)
            {
                return GetAll().Where(x => x.DateAndTime.Value.Date >= startDate && x.DateAndTime.Value.Date <= endDate);
            }
            else if(startDate != null && endDate == null)
            {
                return GetAll().Where(x => x.DateAndTime.Value.Date >= startDate);
            }
            else if (startDate == null && endDate != null)
            {
                return GetAll().Where(x => x.DateAndTime.Value.Date <= endDate);
            }
            else
            {
                return GetAll();
            }            
        }

        public SqlAudit GetSqlAuditById(int Id)
        {
            if (Id > 0)
            {
                var sqlAudit = GetAll().FirstOrDefault(x => x.Id == Id);
                if (sqlAudit != null)
                {
                    return sqlAudit;
                }
            }
            return new SqlAudit { Id = -1 };
        }

        #endregion

        #region CRUD Methods
        public bool DeleteAll()
        {
            try
            {
                List<SqlAudit> sqlAuditList = unitOfWork.SqlAuditRepository.GetAll();
                foreach (var item in sqlAuditList)
                {
                    Delete(item);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Clear(IEnumerable<SqlAudit> sqlAudits)
        {
            unitOfWork.SqlAuditRepository.Clear(sqlAudits);
        }

        public void Create(SqlAudit sqlAudit)
        {
            unitOfWork.SqlAuditRepository.Add(sqlAudit);
        }
        public void Delete(SqlAudit sqlAudit)
        {
            unitOfWork.SqlAuditRepository.Delete(sqlAudit);
        }
        public void Update(SqlAudit sqlAudit)
        {
            unitOfWork.SqlAuditRepository.Update(sqlAudit);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }


        #endregion


    }
}
