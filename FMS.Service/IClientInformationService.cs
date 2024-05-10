
using System.Collections.Generic;
using FMS.Model;

namespace FMS.Service
{
    public interface IClientInformationService
    {
        #region Get methods
        IEnumerable<ClientInformation> GetAll();
        ClientInformation GetClientInformationById(int Id);
        ClientInformation GetClient();

        #endregion

        #region CRUD Methods
        void Create(ClientInformation clientInformation);
        void Update(ClientInformation clientInformation);
        void Delete(ClientInformation clientInformation);       
        int Save();
        #endregion
     

    }
}
