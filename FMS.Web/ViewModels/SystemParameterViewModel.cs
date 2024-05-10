using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class SystemParameterViewModel
    {


        #region Fields

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "User Defined Code")]
        [UIHint("MaskedTextBoxEditor")]
        [Required]
        public string ParameterName { get; set; }

        
        [UIHint("YesNoBooleanEditor")]
        public bool? IsHardCoded { get; set; }

        [Display(Name = "User Defined Code Type")]
        [Required]
        [UIHint("SystemParameterCodeEditor")]
        public int? ParameterCodeId { get; set; }

        public string ParameterCode { get; set; }
        [Display(Name = "Is Hard Coded?")]
        public string HardCoded { get; set; }

        #endregion

        #region Constructor
        public SystemParameterViewModel()
        {
            IsHardCoded = false;
        }
        #endregion


    }

}