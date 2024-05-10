using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Web.ViewModels;

namespace FMS.Web.ViewModels
{
    public class BusinessUnitEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int UnitNumber { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Business Unit Manager")]
        [UIHint("ManagerEditor")]
        public int? ContactDetailId { get; set; }

        public ContactDetailDisplayViewModel contactDetailDisplayViewModel { get; set; }

        public BusinessUnitEditViewModel()
        {
            this.contactDetailDisplayViewModel = new ContactDetailDisplayViewModel();
        }


    }
}
