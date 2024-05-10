
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class ContactDetailService : IContactDetailService
    {

        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public ContactDetailService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion
        
        #region CRUD Methods
        public void Create(ContactDetail contactDetail)
        {
            unitOfWork.ContactDetailRepository.Add(contactDetail);
        }
        public void Delete(ContactDetail contactDetail)
        {
            unitOfWork.ContactDetailRepository.Delete(contactDetail);
        }
        public void Update(ContactDetail contactDetail)
        {
            unitOfWork.ContactDetailRepository.Update(contactDetail);
        }
        public int Save()
        {
            return unitOfWork.Commit();
        }
        #endregion

        #region Get methods
        public IEnumerable<ContactDetail> GetAll()
        {
            return unitOfWork.ContactDetailRepository.GetAll();
        }

        public ContactDetail GetContactDetailById(int id)
        {
            return unitOfWork.ContactDetailRepository.GetAll().FirstOrDefault(m=>m.Id==id);
        }

        public IEnumerable<ContactDetail> GetDriverContacts()
        {
            return unitOfWork.ContactDetailRepository.GetDriverContacts();
        }
          

        public IEnumerable<ContactDetail> GetSupplierContacts(string contactName)
        {
            return unitOfWork.ContactDetailRepository.GetSupplierContacts(contactName);
        }
        public IEnumerable<ContactDetail> GetFuelDistributorContacts()
        {
            return unitOfWork.ContactDetailRepository.GetFuelDistributorContacts();
        }
        public IEnumerable<ContactDetail> GetEmployeeContacts(Parameters.SystemParameterCode type, string contactName)
        {
            return unitOfWork.ContactDetailRepository.GetEmployeeContacts(type,contactName);
        }

        public IEnumerable<ContactDetail> GetManagerContacts()
        {
            return unitOfWork.ContactDetailRepository.GetManagerContacts();
        }

        public IEnumerable<ContactDetail> GetMechanicContacts()
        {
            return unitOfWork.ContactDetailRepository.GetMechanicContacts();
        }

        public IEnumerable<ContactDetail> GetSystemUserContacts()
        {
            return unitOfWork.ContactDetailRepository.GetSystemUserContacts();
        }

        public IEnumerable<ContactDetail> GetCarDealerContacts()
        {
            return unitOfWork.ContactDetailRepository.GetCarDealerContacts();
        }

        public IEnumerable<ContactDetail> GetSupplierContacts()
        {
            return unitOfWork.ContactDetailRepository.GetSupplierContacts();
        }
        #endregion

        #region Other Methods
        public string GetNextPPLNumber()
        {
            var contacts = GetAll().OrderByDescending(x => x.PPLPermitNumber);
            string NewPPLNumber = string.Empty;
            string PPLNumber = string.Empty;

            try
            {
                if (contacts.Count() > 0)
                {
                    PPLNumber = contacts.FirstOrDefault().PPLPermitNumber;
                }

                if (!string.IsNullOrEmpty(PPLNumber))
                {
                    char firstChar = PPLNumber[0];

                    var PPLNumberSplit = PPLNumber.Split(firstChar);

                    string PPLDigits = (Convert.ToInt32(PPLNumberSplit.LastOrDefault()) + 1).ToString();

                    if (PPLDigits.Length == 1)
                    {
                        NewPPLNumber = PPLDigits.Insert(0, "000");
                    }
                    else if (PPLDigits.Length == 2)
                    {
                        NewPPLNumber = PPLDigits.Insert(0, "00");
                    }
                    else if (PPLDigits.Length == 3)
                    {
                        NewPPLNumber = PPLDigits.Insert(0, "0");
                    }
                    else if (PPLDigits.Length == 4)
                    {
                        NewPPLNumber = PPLDigits;
                    }
                    else if (PPLDigits.Length == 5)
                    {
                        firstChar++;
                        NewPPLNumber = firstChar + "0001";
                    }
                    NewPPLNumber = firstChar + NewPPLNumber;
                }
                else
                {
                    NewPPLNumber = "A0001";
                }
            }
            catch (Exception)
            {

            }
            return NewPPLNumber;
        }
        public bool IsPPLNumberValid(string PPLNumber, int contactId)
        {
            var result = true;
            if (PPLNumber.Length > 10)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(PPLNumber))
            {
                var remainingText = PPLNumber.Split(PPLNumber[0]);
                int lastfour;
                int.TryParse(remainingText.LastOrDefault().ToString(), out lastfour);
                int firstChar = Convert.ToInt32(PPLNumber[0]);

                if (remainingText.Count() != 2 || lastfour == 0 || firstChar <= 9)
                {
                    return false;
                }
                else
                {
                    result = true; 
                }
            }
            return result;
        }
        #endregion

    }
}
