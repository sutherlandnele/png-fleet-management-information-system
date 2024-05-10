using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class ContactDetailDisplayViewModel
    {
        #region Constructors
        #endregion

        #region Properties
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? Contacttype { get; set; }
        [Display(Name = "Name")]
        public string ContactName { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string Facsimile { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Mobile { get; set; }
        public string Comments { get; set; }
        public string IsDriver { get; set; }
        [Display(Name = "Supplier Type")]
        public string SupplierType { get; set; }
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Licence #")]
        public string LicenceNumber { get; set; }
        [Display(Name = "Licence Class")]
        public string LicenceClass { get; set; }
        [Display(Name = "Licence Expiry Date")]
        public string LicenceExpiryDate { get; set; }
        [Display(Name = "PPL Permit #")]
        public string PPLPermitNumber { get; set; }
        public string Center { get; set; }
        [Display(Name = "PPL Permit Issue Date")]
        public string PPLPermitIssueDate { get; set; }
        #endregion
    }

}