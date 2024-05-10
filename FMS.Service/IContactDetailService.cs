
using System.Collections.Generic;
using FMS.Common;
using FMS.Model;



namespace FMS.Service
{
    public interface IContactDetailService
    {
        #region Get methods
        IEnumerable<ContactDetail> GetAll();
        IEnumerable<ContactDetail> GetDriverContacts();
        ContactDetail GetContactDetailById(int id);

        IEnumerable<ContactDetail> GetSupplierContacts(string contactName);
        IEnumerable<ContactDetail> GetFuelDistributorContacts();
        IEnumerable<ContactDetail> GetEmployeeContacts(Parameters.SystemParameterCode type, string contactName);
        IEnumerable<ContactDetail> GetManagerContacts();
        IEnumerable<ContactDetail> GetMechanicContacts();
        IEnumerable<ContactDetail> GetSystemUserContacts();
        IEnumerable<ContactDetail> GetCarDealerContacts();
        IEnumerable<ContactDetail> GetSupplierContacts();

        string GetNextPPLNumber();
        bool IsPPLNumberValid(string PPLNumber, int contactId);


        #endregion

        #region CRUD Methods
        void Create(ContactDetail contactDetail);
        void Update(ContactDetail contactDetail);
        void Delete(ContactDetail contactDetail);       
        int Save();
        #endregion
     

    }
}
