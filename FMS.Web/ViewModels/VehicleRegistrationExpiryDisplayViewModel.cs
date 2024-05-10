using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{ 
    public  class VehicleRegistrationExpiryDisplayViewModel
    {
        #region Fields

        public int? Id { get; set; }

        [Display(Name = "Center")]
        public string Center { get; set; }

        [Display(Name = "Rego #")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Registration Expiry")]
        public DateTime? RegistrationExpiry { get; set; }


        #endregion


    }
}
