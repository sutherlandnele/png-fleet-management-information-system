using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class VehicleModelViewModel
    {

        #region Fields
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [UIHint("MaskedTextBoxEditor")]
        [Display(Name = "Model")]
        public string Name { get; set; }

        [Display(Name = "Make")]
        [Required]
        [UIHint("VehicleMakeEditor")]
        public int? MakeId { get; set; }

        public string Make { get; set; }

        #endregion


    }

}