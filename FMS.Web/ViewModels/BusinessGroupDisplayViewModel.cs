using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Web.ViewModels;

namespace FMS.Web.ViewModels
{
    public class BusinessGroupDisplayViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int GroupNumber { get; set; }

        [Display(Name ="Name")]
        public string GroupName { get; set; }
        [Display(Name = "Business Unit")]
        public string BusinessUnit { get; set; }
        [Display(Name = "Business Group Manager")]
        public string Manager { get; set; }

        public ContactDetailDisplayViewModel contactDetailDisplayViewModel { get; set; }

        public BusinessGroupDisplayViewModel()
        {
            this.contactDetailDisplayViewModel = new ContactDetailDisplayViewModel();
        }


    }
}
