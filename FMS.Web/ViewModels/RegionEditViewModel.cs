using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Web.ViewModels;

namespace FMS.Web.ViewModels
{
    public class RegionEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int RegionNumber { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Regional Manager")]
        [UIHint("ManagerEditor")]
        public int? ContactDetailId { get; set; }

        public ContactDetailDisplayViewModel contactDetailDisplayViewModel { get; set; }

        public RegionEditViewModel()
        {
            this.contactDetailDisplayViewModel = new ContactDetailDisplayViewModel();
        }


    }
}
