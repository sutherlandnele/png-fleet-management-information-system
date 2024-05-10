using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class VehicleServiceReportParameterViewModel : ReportParameterBaseViewModel
    {
        #region Fields

        [Display(Name = "Service Alert Date From")]
        public DateTime? ServiceAlertDateFrom { get; set; }
        [Display(Name = "Service Alert Date To")]
        public DateTime? ServiceAlertDateTo { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Service Type")]
        public string ServiceType { get; set; }
        [Display(Name = "Service Provider")]
        public string ServiceProvider { get; set; }
        [Display(Name = "In Service")]
        public string IsInService { get; set; }

        #endregion

    }

}