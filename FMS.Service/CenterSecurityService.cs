
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class CenterSecurityService : ICenterSecurityService
    {

        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public CenterSecurityService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
        
        #region CRUD Methods
        public void Create(CenterSecurity centerSecurity)
        {
            unitOfWork.CenterSecurityRepository.Add(centerSecurity);
        }
        public void Delete(CenterSecurity centerSecurity)
        {
            unitOfWork.CenterSecurityRepository.Delete(centerSecurity);
        }
        public void Update(CenterSecurity centerSecurity)
        {
            unitOfWork.CenterSecurityRepository.Update(centerSecurity);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }

        #endregion

        #region Get methods

        public IEnumerable<CenterSecurity> GetAll()
        {
            return unitOfWork.CenterSecurityRepository.GetAll().OrderByDescending(m=>m.Id);
        }

        public CenterSecurity GetByUserName(string username, int centerNumber)
        {
            return GetAll().FirstOrDefault(x => x.UserId == username && x.CenterId == centerNumber);
        }

        public IEnumerable<CenterSecurity> GetByUserName(string username)
        {
            return GetAll().Where(x => x.UserId == username); 
        }

        public bool UserExists(string userName)
        {
            return GetAll().Any(x => x.UserId == userName);
        }

        public bool CenterSecurityExists(string userName, int centerId)
        {
            return GetAll().Any(x => x.UserId == userName && x.CenterId == centerId);
        }
        #endregion

        #region Private Methods

        #endregion

    }
}
