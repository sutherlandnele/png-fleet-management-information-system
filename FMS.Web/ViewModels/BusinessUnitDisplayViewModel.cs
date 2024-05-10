using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Web.ViewModels;

namespace FMS.Web.ViewModels
{
    public class BusinessUnitDisplayViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int UnitNumber { get; set; }
        public string Name { get; set; }

        [Display(Name = "Business Unit Manager")]
        public string Manager { get; set; }

        public ContactDetailDisplayViewModel contactDetailDisplayViewModel { get; set; }

        public BusinessUnitDisplayViewModel()
        {
            this.contactDetailDisplayViewModel = new ContactDetailDisplayViewModel();
        }


    }
}
