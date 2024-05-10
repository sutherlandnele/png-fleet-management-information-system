using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public class VehicleServiceScheduleDisplayViewModel
    {
    
        #region Properties
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Vehicle Registration #")]
        public string VehicleRegistration { get; set; }
        [Display(Name = "Service Alert Date")]

        public string ServiceAlertDate { get; set; }
        [Display(Name = "Service Alert Mileage")]

        public string ServiceAlertMileage { get; set; }
        [Display(Name = "Schedule Service Type")]
        public string ScheduleServiceType { get; set; }
        public string CurrentMileage { get; set; }
        public bool HasServiceBeenDone { get; set; }
        public bool ServiceExists { get; set; }
    
        public int? VehicleId { get; set; }
        public int? ScheduleServiceTypeId { get; set; }
        public VehicleDisplayInfoViewModel VehicleDisplayInfoViewModel { get; set; }
        public VehicleServiceDisplayViewModel VehicleServiceDisplayViewModel { get; set; }
        #endregion

        #region Constructors
        public VehicleServiceScheduleDisplayViewModel()
        {
            this.VehicleDisplayInfoViewModel = new VehicleDisplayInfoViewModel();
            this.VehicleServiceDisplayViewModel = new VehicleServiceDisplayViewModel();
        }
        #endregion


    }
}
