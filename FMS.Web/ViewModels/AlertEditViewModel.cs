using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public  class AlertEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Alert Type")]
        [UIHint("AlertTypeEditor")]
        public int? AlertTypeId { get; set; }
        [Display(Name = "Contact")]
        [UIHint("ContactEditor")]
        public int? ContactId { get; set; }        
        public string ContactDisplay { get; set; }
        public string AlertTypeDisplay { get; set; }
        [Display(Name = "Email")]
        [UIHint("MaskedTextBoxEditor")]
        public string EmailDisplay { get; set; }
        
    }
}
