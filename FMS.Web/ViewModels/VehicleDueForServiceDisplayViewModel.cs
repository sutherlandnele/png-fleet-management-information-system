using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{ 
    public  class VehicleDueForServiceDisplayViewModel
    {
        #region Fields

        public int? Id { get; set; }

        [Display(Name = "Center")]
        public string Center { get; set; }

        [Display(Name = "Rego #")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Current Milage")]
        public string CurrentMileage { get; set; }

        [Display(Name = "Alert Milage")]
        public string AlertMileage { get; set; }

        [Display(Name = "Alert Date")]
        public DateTime? AlertDate { get; set; }

        #endregion


    }
}
