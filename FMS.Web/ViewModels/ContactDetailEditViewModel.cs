using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class ContactDetailEditViewModel
    {

        #region Properties
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string ContactName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? Contacttype { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string Facsimile { get; set; } 
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email format is not valid")]        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Telephone { get; set; }

        public string Fax { get; set; }
        [RegularExpression(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?", ErrorMessage = "Website format is not valid")]
        [DataType(DataType.Url)]
        public string Website { get; set; }

        public string Mobile { get; set; }
        public string Comments { get; set; }
        public bool? IsDriver { get; set; }
        [Display(Name = "Supplier Type")]
        public int? SupplierType { get; set; }
        [UIHint("NullableDateEditor")]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [UIHint("GenderEditor")]
        public int? Gender { get; set; }
        [Display(Name = "Licence #")]
        public string LicenceNumber { get; set; }
        [Display(Name = "Licence Class")]
        public string LicenceClass { get; set; }
        [UIHint("NullableDateEditor")]
        [Display(Name = "Licence Expiry Date")]
        public DateTime? LicenceExpiryDate { get; set; }
        [Display(Name = "PPL Permit #")]
        public string PPLPermitNumber { get; set; }
        [Display(Name = "Center")]
        [UIHint("CenterSecurityEditor")]
        public int? CenterId { get; set; }
        [UIHint("NullableDateEditor")]
        [Display(Name = "PPL Permit Issue Date")]
        public DateTime? PPLPermitIssueDate { get; set; }
        #endregion

        #region Constructors
        #endregion


    }

}