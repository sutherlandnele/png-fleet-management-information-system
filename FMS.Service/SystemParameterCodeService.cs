
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class SystemParameterCodeService : ISystemParameterCodeService
    {

        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public SystemParameterCodeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
 
        #endregion

        #region CRUD Methods
        public void Create(SystemParameterCode systemParameterCode)
        {
            unitOfWork.SystemParameterCodeRepository.Add(systemParameterCode);
        }
        public void Delete(SystemParameterCode systemParameterCode)
        {
            unitOfWork.SystemParameterCodeRepository.Delete(systemParameterCode);
        }
        public void Update(SystemParameterCode systemParameterCode)
        {
            unitOfWork.SystemParameterCodeRepository.Update(systemParameterCode);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }
        #endregion

        #region Public Get methods
        public IEnumerable<SystemParameterCode> GetAll()
        {
            return unitOfWork.SystemParameterCodeRepository.GetAll().OrderBy(m=>m.ParameterCode);
        }

        public int? GetSystemParameterCodeIdByCodeText(string code)
        {
            var result = GetAll().Where(m => m.ParameterCode.Contains(code)).FirstOrDefault();
            return result != null ? (int?)result.Id : null;
        }

        #endregion

    }
}
