
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class ComplianceService : IComplianceService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public ComplianceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region CRUD Methods
        public void Create(Compliance compliance)
        { 
            unitOfWork.ComplianceRepository.Add(compliance);
        }

        public void Delete(Compliance compliance)
        {
            unitOfWork.ComplianceRepository.Delete(compliance);
        }

        public void Update(Compliance compliance)
        {
            unitOfWork.ComplianceRepository.Update(compliance);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }


        #endregion

        #region Get Methods


        public IEnumerable<Compliance> GetAll()
        {
            return unitOfWork.ComplianceRepository.GetAll().OrderByDescending(m => m.ComplianceDate);
        }
        
        public IEnumerable<Compliance> GetAllRegistryByCenterPermission(string userName, int regNumber)
        {
            var result = GetAllRegistry(regNumber);

            if (!string.IsNullOrEmpty(userName))
            {
                return from a in result
                       where a.Vehicle != null
                       join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == userName) 
                       on a.Vehicle.CenterId equals b.CenterId select a;
            }

            return result.OrderByDescending(m=>m.ComplianceNumber);
        }

        public IEnumerable<Compliance> GetAllRegistry(int regNumber)
        {
            int registryType = Convert.ToInt32((Parameters.SystemParameterCode.Registration));

            var result = GetAll().Where(x => x.ComplianceType == registryType);

            if (regNumber > 0)
            {
                result = result.Where(x => x.Vehicle != null && x.RegistrationNumber == regNumber);
            }
            return result;
        }

        public IEnumerable<Compliance> GetSafetyStickerRegistry(int regNumber)
        {
            int safetyStickerType = Convert.ToInt32((Parameters.SystemParameterCode.SafetySticker));

            var result = GetAll().Where(x => x.ComplianceType == safetyStickerType);

            if (regNumber > 0)
            {
                result = result.Where(x => x.Vehicle != null && x.RegistrationNumber == regNumber);
            }
            return result;
        }

        public IEnumerable<Compliance> GetSafetyStickerRegistryByCenterPermission(string userName, int regNumber)
        {

            var result = GetSafetyStickerRegistry(regNumber);

            if (!string.IsNullOrEmpty(userName))
            {
                return from a in result
                       where a.Vehicle != null
                       join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == userName)
                       on a.Vehicle.CenterId equals b.CenterId
                       select a;
            }
            return result;
        }

        public Compliance GetComplianceById(int complianceNumber)
        {
            if (complianceNumber > 0)
            {
                var compliance = GetAll().FirstOrDefault(x => x.ComplianceNumber == complianceNumber);
                if (compliance != null)
                {
                    return compliance;
                }
            }
            return new Compliance { ComplianceNumber = -1 };
        }

        #endregion
    }
}
