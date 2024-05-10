using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Data.Repositories
{
    internal class ContactDetailRepository : RepositoryBase<ContactDetail>, IContactDetailRepository
    {
        internal ContactDetailRepository(IDbFactory dbFactory): base(dbFactory) {

        }
        #region Get Methods
        public IEnumerable<ContactDetail> GetCarDealerContacts()
        {
            return GetAll().Where(o => o.Contacttype == (int)Parameters.SystemParameterCode.Supplier 
                && o.SupplierType == (int)Parameters.SystemParameterCode.Motor_Dealers);
        }


        public IEnumerable<ContactDetail> GetContactsByContactType(Parameters.SystemParameterCode type, string contactName)
        {
            if (!string.IsNullOrEmpty(contactName))
            {
                return GetAll().Where(x => x.Contacttype == (int)type).Where(x => x.ContactName.ToLower().Contains(contactName.ToLower()) || x.ContactPerson.ToLower().Contains(contactName.ToLower()) || x.Email.ToLower().Contains(contactName.ToLower()) || x.Telephone.ToLower().Contains(contactName.ToLower()) || x.Mobile.ToLower().Contains(contactName.ToLower())).OrderBy(x => x.ContactName);
            }
            else
            {
                return GetAll().Where(x => x.Contacttype == (int)type);
            }
        }

        public IEnumerable<ContactDetail> GetDriverContacts()
        {
            return GetAll().Where( o => 
                //o.Contacttype == (int)Parameters.SystemParameterCode.Driver &&
                 o.IsDriver == true);
        }

        public IEnumerable<ContactDetail> GetEmployeeContacts(Parameters.SystemParameterCode type, string contactName)
        {

            IEnumerable<ContactDetail> result = GetAll();

            if (type == Parameters.SystemParameterCode.Mechanics)
            {
                result = result.Where(x => x.Contacttype == Convert.ToInt32(Parameters.SystemParameterCode.Mechanics));
            }
            else if (type == Parameters.SystemParameterCode.Driver)
            {
                result = result.Where(x => x.Contacttype == Convert.ToInt32(Parameters.SystemParameterCode.Driver));
            }
            else
            {
                result = result.Where(x => x.Contacttype == Convert.ToInt32(Parameters.SystemParameterCode.Employee));
            }

            if (!string.IsNullOrEmpty(contactName))
            {
                result = result.Where(x => x.ContactName.ToLower().Contains(contactName.ToLower()));
            }

            return result.OrderByDescending(m=>m.Id);

        }

        public IEnumerable<ContactDetail> GetFuelDistributorContacts()
        {
            return GetAll().Where(o => o.Contacttype == (int)Parameters.SystemParameterCode.Supplier
                && o.SupplierType == (int)Parameters.SystemParameterCode.Fuel_Distributors);
        }

        public IEnumerable<ContactDetail> GetManagerContacts()
        {
            return GetAll().Where(o => o.Contacttype == (int)Parameters.SystemParameterCode.Employee);
        }

        public IEnumerable<ContactDetail> GetMechanicContacts()
        {
            return GetAll().Where(o => o.Contacttype == (int)Parameters.SystemParameterCode.Mechanics);
        }

        public IEnumerable<ContactDetail> GetSupplierContacts(string contactName)
        {
            int contactType = (int)Parameters.SystemParameterCode.Supplier;


            if (!string.IsNullOrEmpty(contactName))
            {
                return GetAll().Where(x => x.Contacttype == contactType)
                    .Where(x => x.ContactName.ToLower()
                    .Contains(contactName.ToLower()) || 
                    x.ContactPerson.ToLower().Contains(contactName.ToLower()) || 
                    x.Email.ToLower().Contains(contactName.ToLower()) || 
                    x.Telephone.ToLower().Contains(contactName.ToLower()) || 
                    x.Mobile.ToLower().Contains(contactName.ToLower())).OrderBy(x => x.ContactName)
                    .OrderByDescending(m=>m.Id);
            }
            else
            {
                return GetAll().Where(x => x.Contacttype == contactType).OrderByDescending(m => m.Id);
            }
        }

        public IEnumerable<ContactDetail> GetSupplierContacts()
        {
            return GetAll().Where(x => x.Contacttype == (int)Parameters.SystemParameterCode.Supplier);
        }

        public IEnumerable<ContactDetail> GetSystemUserContacts()
        {
            return GetAll().Where(o => o.Contacttype == (int)Parameters.SystemParameterCode.Employee);
        }
        #endregion
    }

}
