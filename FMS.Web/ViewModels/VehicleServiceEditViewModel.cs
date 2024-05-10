using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Web.ViewModels;

namespace FMS.Web.ViewModels
{
    public class VehicleServiceEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Vehicle Registration #")]
        [Required]
        public int? VehicleId { get; set; }
        public int? ScheduleServiceId { get; set; }

        [Display(Name = "Service Start Date")]
        [Required]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Service End Date")]        
        public DateTime? EndDate { get; set; }

        [Display(Name = "Service Type")]
        [Required]
        public int? ServiceTypeId { get; set; }

        [Display(Name = "Schedule Service Type")]
        public int? ScheduleServiceTypeId { get; set; }

        public string Description { get; set; }
        [Display(Name = "Service Provider")]
        public int? ProviderId { get; set; }

        [Display(Name = "Service Cost (Kina)")]
        public decimal? Cost { get; set; }

        [Display(Name = "Current Mileage")]
        public int? CurrentMileage { get; set; }

        [Display(Name = "Incident")]
        public int? IncidentId { get; set; }

        [Display(Name = "Service Mechanic")]
        public int? ServiceMechanic { get; set; }

        [Display(Name = "PO No. Reference")]
        public string PoReference { get; set; }
        [Display(Name = "Center")]
        public int? CenterId { get; set; }
        [Display(Name = "Business Group")]
        public int? BusinessGroupId { get; set; }

        [Display(Name = "Service Job Number")]

        [UIHint("DisplayForEmphasized")]
        public string ServiceJobNumber { get; set; }

        public bool? IsIncidentService { get; set; }
        public bool? IsAmountPaid { get; set; }
   
        public string CreatedBy { get; set; } 
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByDisplay { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDateDisplay { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime? LastUpdatedDate { get; set; }
        public VehicleDisplayInfoViewModel VehicleDisplayInfoViewModel { get; set; }

        public VehicleServiceEditViewModel()
        {
            this.VehicleDisplayInfoViewModel = new VehicleDisplayInfoViewModel();
        }


    }
}
