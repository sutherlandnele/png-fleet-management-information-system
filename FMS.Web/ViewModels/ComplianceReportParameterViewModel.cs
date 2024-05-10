using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class ComplianceReportParameterViewModel : ReportParameterBaseViewModel
    {
        #region Fields

        [Display(Name = "Expiry Date From")]
        public DateTime? ExpiryDateFrom { get; set; }
        [Display(Name = "Expiry Date To")]
        public DateTime? ExpiryDateTo { get; set; }


        #endregion

    }

}