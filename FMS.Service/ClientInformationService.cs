
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class ClientInformationService : IClientInformationService
    {

        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public ClientInformationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
        
        #region CRUD Methods
        public void Create(ClientInformation clientInformation)
        {
            unitOfWork.ClientInformationRepository.Add(clientInformation);
        }
        public void Delete(ClientInformation clientInformation)
        {
            unitOfWork.ClientInformationRepository.Delete(clientInformation);
        }
        public void Update(ClientInformation clientInformation)
        {
            unitOfWork.ClientInformationRepository.Update(clientInformation);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }


        #endregion

        #region Get Methods
        public IEnumerable<ClientInformation> GetAll()
        {
            return unitOfWork.ClientInformationRepository.GetAll().OrderByDescending(m=>m.Id);
        }

        public ClientInformation GetClientInformationById(int Id)
        {
            if (Id > 0)
            {
                var clientInformation = GetAll().FirstOrDefault(x => x.Id == Id);
                if (clientInformation != null)
                {
                    return clientInformation;
                }
            }
            return new ClientInformation { Id = -1 };
        }

        public ClientInformation GetClient()
        {
            var clientInfo = unitOfWork.ClientInformationRepository.GetAll().FirstOrDefault();
            if (clientInfo != null)
            {
                return clientInfo;
            }
            else
            {
                return new ClientInformation { Id = -1 };
            }
        }
        #endregion
        #region Private Methods

        #endregion

    }
}
