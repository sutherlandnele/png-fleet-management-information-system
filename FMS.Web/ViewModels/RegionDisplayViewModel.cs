using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Web.ViewModels;

namespace FMS.Web.ViewModels
{
    public class RegionDisplayViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int RegionNumber { get; set; }
        public string Name { get; set; }

        [Display(Name = "Regional Manager")]
        public string Manager { get; set; }

        public ContactDetailDisplayViewModel contactDetailDisplayViewModel { get; set; }

        public RegionDisplayViewModel()
        {
            this.contactDetailDisplayViewModel = new ContactDetailDisplayViewModel();
        }


    }
}
