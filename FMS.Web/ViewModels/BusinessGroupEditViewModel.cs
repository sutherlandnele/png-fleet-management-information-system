using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Web.ViewModels;

namespace FMS.Web.ViewModels
{
    public class BusinessGroupEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int GroupNumber { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string GroupName { get; set; }
        [Display(Name = "Business Unit")]
        [UIHint("BusinessUnitEditor")]
        [Required]
        public int? BusinessUnitId { get; set; }
        [Display(Name = "Business Group Manager")]
        [UIHint("ManagerEditor")]
        public int? CotactDetailId { get; set; }

        public ContactDetailDisplayViewModel contactDetailDisplayViewModel { get; set; }

        public BusinessGroupEditViewModel()
        {
            this.contactDetailDisplayViewModel = new ContactDetailDisplayViewModel();
        }


    }
}
