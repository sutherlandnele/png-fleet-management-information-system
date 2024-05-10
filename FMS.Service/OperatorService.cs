
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;


namespace FMS.Service
{
    public class OperatorService : IOperatorService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public OperatorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Get Methods
        public bool CanDelete(int id)
        {
            return (!unitOfWork.IncidentRepository.GetAll().Any(x => x.VehicleId == id)) 
                    && (!unitOfWork.VehicleAllocationRepository.GetAll().Any(x => x.VehicleId == id)) 
                    && (!unitOfWork.VehicleRefuelRepository.GetAll().Any(x => x.VehicleId == id));

        }

        public IEnumerable<Operator> GetAll()
        {
            return unitOfWork.OperatorRepository.GetAll().OrderByDescending(x => x.Id);
        }

        public IEnumerable<Operator> GetAll(int center, string driverName, int groupNumber, bool custodian)
        {
            var result = GetAll();


            if (center != -1)
            {
                result = result.Where(x => x.CenterId == center);
            }

            if (!string.IsNullOrEmpty(driverName))
            {
                result = result.Where(x => x.DriverName != null && x.DriverName.ToUpper().Contains(driverName.ToUpper()));
            }
            if (groupNumber != -1)
            {
                result = result.Where(x => x.BusinessGroupId == groupNumber);
            }

            if (custodian != false)
            {
                result = result.Where(x => x.IsCustodian == custodian);
            }


            return result;
        }

        public IEnumerable<Operator> GetFilterByCenterPermission(string userName, int center, string driverName, int groupNumber, bool custodian)
        {
            if (!string.IsNullOrEmpty(userName))
            {

                return from a in GetAll(center, driverName, groupNumber, custodian) join b 
                       in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == userName) on a.CenterId equals b.CenterId select a;

            }
            return GetAll(center, driverName, groupNumber, custodian);
        }

        public Operator GetOperatorById(int id)
        {
            if (id > 0)
            {
                var operatr = GetAll().FirstOrDefault(x => x.Id == id);
                if (operatr != null)
                {
                    return operatr;
                }
            }
            return new Operator { Id = -1 };
        }

        #endregion

        #region CRUD Methods
        public void Create(Operator op)
        {
            unitOfWork.OperatorRepository.Add(op);
        }

        public void Delete(Operator op)
        {
            unitOfWork.OperatorRepository.Delete(op);
        }    

        public int Save()
        {
            return unitOfWork.Commit();
        }

        public void Update(Operator op)
        {
            unitOfWork.OperatorRepository.Update(op);
        }
        #endregion
        
    }
}
