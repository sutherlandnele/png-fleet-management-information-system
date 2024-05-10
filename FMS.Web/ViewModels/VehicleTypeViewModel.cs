using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class VehicleTypeViewModel
    {


        #region Fields

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Type")]
        [Required]
        [UIHint("MaskedTextBoxEditor")]
        public string Type { get; set; }

        [Display(Name = "Life Span (In Years)")]
        [UIHint("NumericNullableDecimalTextBox")]
        [Required]
        public int? LifeSpan { get; set; }

        [Display(Name = "Mileage Span")]
        [UIHint("NumericNullableDecimalTextBox")]
        [Required]
        public int? MileageSpan { get; set; }


        #endregion


    }

}