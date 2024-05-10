
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;

namespace FMS.Service
{
    public class IncidentService : IIncidentService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public IncidentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion


        #region CRUD Methods
        public void Create(Incident incident)
        {
            unitOfWork.IncidentRepository.Add(incident);
        }

        public void Delete(Incident incident)
        {
            unitOfWork.IncidentRepository.Delete(incident);
        }

        public void Update(Incident incident)
        {
            unitOfWork.IncidentRepository.Update(incident);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }

        #endregion

        #region Get Methods
        public bool CanDelete(int id)
        {
            return  !(unitOfWork.ServiceRepository.GetAll().Any(x => x.IncidentId == id));
        }

        public IEnumerable<Incident> GetAll()
        {
            return unitOfWork.IncidentRepository.GetAll().OrderByDescending(i => i.DateAndTime);
        }

        public IEnumerable<Incident> GetAll(string regNum, string fileNumber, int incidentStatus, int incidentType, int center, int groupNumber)
        {
            var result = GetAll();

            if (!string.IsNullOrEmpty(regNum))
            {       
                result = result.Where(x => x.Vehicle.RegistrationNumber.Contains(regNum));
            }
            if (!string.IsNullOrEmpty(fileNumber))
            {
                result = result.Where(x => x.IncidentFileNumber.Contains(fileNumber));
            }
            if (incidentStatus != -1)
            {
                result = result.Where(x => x.IncidentStatusId == incidentStatus);
            }
            if (incidentType != -1)
            {
                result = result.Where(x => x.IncidentTypeId == incidentType);
            }

            return result;
        }

        public IEnumerable<Incident> GetFilterByCenterPermission(string currentUser)
        {
            
            var result = GetAll();
            return result;
        }

        public IEnumerable<Incident> GetFilterByCenterPermission(string currentUser, string regNum, string fileNumber, int incidentStatus, int incidentType, int center, int groupNumber)
        {
            var result = GetAll(regNum, fileNumber, incidentStatus, incidentType, center, groupNumber);

            var ContactDetails = unitOfWork.ContactDetailRepository.GetAll();

            if (!string.IsNullOrEmpty(currentUser))
            {           
                result = from a in result
                         join b in ContactDetails
                         on a.OperatorId equals b.Id
                         select a;
            }

            return result;
        }


        public IEnumerable<Incident> GetFilterByCenterPermission(string currentUser, int vehicleId, string fileNumber, int incidentType)
        {
            var result = GetAll();

            if (vehicleId > 0)
            {
                result = result.Where(m => m.Vehicle != null && m.Vehicle.Id == vehicleId);
            }

            if (!string.IsNullOrEmpty(fileNumber))
            {
                result = result.Where(x => x.IncidentFileNumber.Contains(fileNumber));
            }

            if (incidentType > 0)
            {
                result = result.Where(x => x.IncidentTypeId == incidentType);
            }

            if (!string.IsNullOrEmpty(currentUser))
            {
                result = from a in result.Where(m=>m.Vehicle != null)
                         join b in unitOfWork.CenterSecurityRepository.GetAll().Where(x => x.UserId == currentUser)
                         on a.Vehicle.Center.CenterNumber equals b.CenterId
                         select a;
            }

            return result.OrderByDescending(m=>m.Id);
        }


        public Incident GetIncidentById(int id)
        {
            if (id > 0)
            {
                var incident = GetAll().FirstOrDefault(x => x.Id == id);
                if (incident != null)
                {
                    return incident;
                }
            }
            return new Incident { Id = -1 };
        }


        #endregion





    }
}
