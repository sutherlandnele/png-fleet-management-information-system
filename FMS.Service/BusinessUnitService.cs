
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class BusinessUnitService : IBusinessUnitService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public BusinessUnitService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region CRUD Methods
        public void Create(BusinessUnit businessUnit)
        {
            unitOfWork.BusinessUnitRepository.Add(businessUnit);
        }
        public void Update(BusinessUnit businessUnit)
        {
            unitOfWork.BusinessUnitRepository.Update(businessUnit);
        }
        public void Delete(BusinessUnit businessUnit)
        {
            unitOfWork.BusinessUnitRepository.Delete(businessUnit);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }
        #endregion

        #region Get Methods
        public IEnumerable<BusinessUnit> GetAll()
        {
            return unitOfWork.BusinessUnitRepository.GetAll();
        }
        public IEnumerable<BusinessUnit> GetAll(string name, int manager)
        {
            var result = GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(x => x.Name != null && x.Name.ToLower().Contains(name.ToLower()) || x.Manager != null && x.Manager.ToLower().Contains(name.ToLower()));
            }

            if (manager != -1)
            {

                result = result.Where(x => x.ContactDetailId == manager);
            }
            return result.OrderByDescending(m=>m.UnitNumber);
        }
        public BusinessUnit GetBusinessUnitById(int unitNumber)
        {
            if (unitNumber > 0)
            {
                var businessUnit = GetAll().FirstOrDefault(x => x.UnitNumber == unitNumber);
                if (businessUnit != null)
                {
                    return businessUnit;

                }
            }
            return new BusinessUnit { UnitNumber = -1 };
        }
        public bool IsInUse(int unitNumber)
        {
            return unitOfWork.BusinessGroupRepository.GetAll().Any(x => x.BusinessUnitId == unitNumber);
        }
        #endregion

    }
}
