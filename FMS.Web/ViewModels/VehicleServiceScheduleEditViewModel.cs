using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public class VehicleServiceScheduleEditViewModel
    {
        #region Properties
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Vehicle Registration #")]
        [Required]
        public int? VehicleId { get; set; }
        [Display(Name = "Service Alert Date")]
        [Required]
        public DateTime? ServiceAlertDate { get; set; }
        [Display(Name = "Service Alert Mileage")]
        [Required]
        public int? ServiceAlertMileage { get; set; }
        [Display(Name = "Schedule Service Type")]
        [Required]
        public int? ScheduleServiceTypeId { get; set; }
        public int? CurrentMileage { get; set; }
        public bool? HasServiceBeenDone { get; set; }       
        public VehicleDisplayInfoViewModel VehicleDisplayInfoViewModel { get; set; }
        public VehicleServiceDisplayViewModel VehicleServiceDisplayViewModel { get; set; }
        #endregion

        #region Constructors
        public VehicleServiceScheduleEditViewModel()
        {
            this.VehicleDisplayInfoViewModel = new VehicleDisplayInfoViewModel();
            this.VehicleServiceDisplayViewModel = new VehicleServiceDisplayViewModel();

        }
        #endregion


    }
}
