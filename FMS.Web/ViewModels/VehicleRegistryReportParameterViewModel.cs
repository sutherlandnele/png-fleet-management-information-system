using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class VehicleRegistryReportParameterViewModel : ReportParameterBaseViewModel
    {
        #region Fields

        [Display(Name = "Purchase Year From")]
        public DateTime? YearPurchaseFrom { get; set; }
        [Display(Name = "Purchase Year To")]
        public DateTime? YearPurchaseTo { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Vehicle Status")]
        public string Status { get; set; }
        [Display(Name = "Vehicle Condition")]
        public string Condition { get; set; }
        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }
        [Display(Name = "Transmission Type")]
        public string Transmission { get; set; }
        public bool? BOS_Recommendation { get; set; }

        #endregion

    }

}