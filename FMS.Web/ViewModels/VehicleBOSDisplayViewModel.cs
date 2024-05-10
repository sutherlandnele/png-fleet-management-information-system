using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public class VehicleBOSDisplayViewModel
    {
       
        #region Fields
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Age (Years)")]
        public int? Age { get; set; }

        [Display(Name = "Center")]
        public string Center { get; set; }
        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }       
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Current Mileage")]
        public string CurrentMileage { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Vehicle Condition")]
        public string Condition { get; set; }
        
        public bool IsConditionBOS { get; set; }

        public bool IsAgeBOS { get; set; }

        public bool IsOperationalStatusBOS { get; set; }

        public bool IsMileageBOS { get; set; }

        #endregion

        public VehicleBOSDisplayViewModel()
        {
            IsConditionBOS = IsAgeBOS = IsOperationalStatusBOS = IsMileageBOS = false;
        }



    }
}