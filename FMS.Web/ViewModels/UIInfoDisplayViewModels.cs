using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{

    public class VehicleDisplayInfoViewModel
    {
        #region Fields

        [Display(Name = "Rego No.")]
        [UIHint("DisplayForEmphasized")]
        public string VehicleRegistrationNumber { get; set; }
        [Display(Name = "Status")]
        public string VehicleStatus { get; set; }
        [Display(Name = "Condition")]
        public string VehicleCondition { get; set; }
        [Display(Name = "Model")]
        public string VehicleModel { get; set; }
        [Display(Name = "Make")]
        public string VehicleMake { get; set; }
        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }
        [Display(Name = "Color")]
        public string VehicleColor { get; set; }
        [Display(Name = "Business Group")]
        public string BusinessGroup { get; set; }
        [Display(Name = "Center")]
        public string Center { get; set; }
        [Display(Name = "Current Mileage")]
        public string CurrentMileage { get; set; }

        #endregion
    }

    public class OperatorDisplayInfoViewModel
    {
        #region Fields

        [Display(Name = "Staff Number")]
        public string StaffNumber { get; set; }  

        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }

        [Display(Name = "Mobile Number")]
        public string DriverMobile { get; set; }

        [Display(Name = "Email")]
        public string DriverEmail { get; set; }

        [Display(Name = "Licence Number")]
        public string DriverLicenceNumber { get; set; }

        [Display(Name = "Date Of Birth")]
        public string DriverDateOfBirth { get; set; }

        #endregion

    }

    public class ListOfValuesDisplayViewModel
    {
        public int? Value { get; set; }
        public string Text { get; set; }
    }

}