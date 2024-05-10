using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class ReportParameterBaseViewModel
    {
        #region Fields
        [HiddenInput(DisplayValue = false)]
        public int ReportType { get; set; }      
        [Display(Name = "Center")]
        public string Center { get; set; }        
        [Display(Name = "Business Unit")]
        public string BusinessUnit { get; set; }
        [Display(Name = "Business Group")]
        public string BusinessGroup{ get; set; }

        #endregion

    }

}