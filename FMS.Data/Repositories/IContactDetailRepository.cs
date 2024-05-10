using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;
using FMS.Common;

namespace FMS.Data.Repositories
{
    public interface IContactDetailRepository : IRepository<ContactDetail>
    {
        IEnumerable<ContactDetail> GetDriverContacts();

        IEnumerable<ContactDetail> GetSupplierContacts(string contactName);
        IEnumerable<ContactDetail> GetFuelDistributorContacts();
        IEnumerable<ContactDetail> GetEmployeeContacts(Parameters.SystemParameterCode type, string contactName);
        IEnumerable<ContactDetail> GetManagerContacts();
        IEnumerable<ContactDetail> GetMechanicContacts();
        IEnumerable<ContactDetail> GetSystemUserContacts();
        IEnumerable<ContactDetail> GetCarDealerContacts();
        IEnumerable<ContactDetail> GetSupplierContacts();

        
    }
}
