using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class VehicleIncidentReportParameterViewModel : ReportParameterBaseViewModel
    {
        #region Fields

        [Display(Name = "Incident Date From")]
        public DateTime? IncidentDateFrom { get; set; }
        [Display(Name = "Incident Date To")]
        public DateTime? IncidentDateTo { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Incident Type")]
        public string IncidentType { get; set; }
        [Display(Name = "Incident Status")]
        public string IncidentStatus { get; set; }


        #endregion

    }

}