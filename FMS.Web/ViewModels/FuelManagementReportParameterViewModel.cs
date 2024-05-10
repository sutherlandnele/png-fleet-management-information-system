using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class FuelManagementReportParameterViewModel : ReportParameterBaseViewModel
    {
        #region Fields

        [Display(Name = "Refuel Date From")]
        public DateTime? RefuelDateFrom { get; set; }
        [Display(Name = "Refuel Date To")]
        public DateTime? RefuelDateTo { get; set; }
        [Display(Name = "Tank Refuel Date From")]
        public DateTime? TankRefuelDateFrom { get; set; }
        [Display(Name = "Tank Refuel Date To")]
        public DateTime? TankRefuelDateTo { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Fuel Usage Group")]
        public string FuelUsageGroup { get; set; }

        #endregion

    }

}