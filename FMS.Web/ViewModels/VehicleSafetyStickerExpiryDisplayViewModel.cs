using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{ 
    public  class VehicleSafetyStickerExpiryDisplayViewModel
    {
        #region Fields

        public int? Id { get; set; }

        [Display(Name = "Center")]
        public string Center { get; set; }

        [Display(Name = "Rego #")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Safety Sticker Expiry")]
        public DateTime? SafetyStickerExpiry { get; set; }


        #endregion


    }
}
