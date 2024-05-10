using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class ManagementReportParameterViewModel : ReportParameterBaseViewModel
    {
        #region Fields

        [Display(Name = "Purchase Year From")]
        public DateTime? PurchaseYearFrom { get; set; }
        [Display(Name = "Purchase Year To")]
        public DateTime? PurchaseYearTo { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        #endregion

    }

}