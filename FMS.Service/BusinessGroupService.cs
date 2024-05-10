
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class BusinessGroupService : IBusinessGroupService
    {

        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public BusinessGroupService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region CRUD Methods
        public void Create(BusinessGroup businessGroup)
        {
            unitOfWork.BusinessGroupRepository.Add(businessGroup);
        }

        public void Delete(BusinessGroup businessGroup)
        {
            unitOfWork.BusinessGroupRepository.Delete(businessGroup);
        }
        public void Update(BusinessGroup businessGroup)
        {
            unitOfWork.BusinessGroupRepository.Update(businessGroup);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }
        #endregion

        #region Get methods

        public BusinessUnit GetBusinessGroupBusinessUnit(int id)
        {
            return GetAll().Where(g => g.GroupNumber == id).Select(g => g.BusinessUnit).FirstOrDefault();
        }
        public IEnumerable<BusinessGroup> GetAll()
        {
            return unitOfWork.BusinessGroupRepository.GetAll();
        }

        public IEnumerable<BusinessGroup> GetAll(string name, int manager, int businessUnit)
        {
           return  unitOfWork.BusinessGroupRepository.GetAll( name,  manager,  businessUnit);
        }

        public IEnumerable<BusinessGroup> GetBusinessGroup(string Username)
        {
            var result = from bsGroup in GetAll()
                         join security in unitOfWork.BusinessGroupSecurityRepository.GetAll()
                         on bsGroup.GroupNumber equals security.BusinessGroupId
                         where security.UserId == Username
                         select bsGroup;
            return result;
        }

        public IEnumerable<BusinessGroup> GetBusinessGroupByBusinessUnit(int businessUnitId)
        {
            return unitOfWork.BusinessGroupRepository.GetAll().Where(x => x.BusinessUnitId == businessUnitId);
        }

        public BusinessGroup GetBusinessGroupById(int groupNumber)
        {
            if (groupNumber > 0)
            {
                return unitOfWork.BusinessGroupRepository.GetById(groupNumber);
            }
            return new BusinessGroup { GroupNumber = -1 };
        }

        public IEnumerable<BusinessGroupSecurity> GetBusinessGroupSecurityForUser(string userId)
        {
            return unitOfWork.BusinessGroupSecurityRepository.GetAll().Where(x => x.UserId == userId);
        }

        public bool IsInUse(int groupNumber)
        {
            return unitOfWork.OperatorRepository.GetAll().Any(x => x.BusinessGroupId == groupNumber) || unitOfWork.VehicleRepository.GetAll().Any(x => x.BusinessGroupId == groupNumber);
        }
        #endregion


    }
}
