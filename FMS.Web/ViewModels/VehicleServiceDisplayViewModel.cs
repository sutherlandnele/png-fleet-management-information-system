using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Web.ViewModels;

namespace FMS.Web.ViewModels
{
    public class VehicleServiceDisplayViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Vehicle Registration #")]        
        public string VehicleRegistration { get; set; }
        [Display(Name = "Schedule Service")]
        public string ScheduleService { get; set; }
        [Display(Name = "Service Start Date")]        
        public string StartDate { get; set; }
        [Display(Name = "Service End Date")]        
        public string EndDate { get; set; }
        [Display(Name = "Service Type")]        
        public string ServiceType { get; set; }
        [Display(Name = "Schedule Service Type")]
        public string ScheduleServiceType { get; set; }
        public string Description { get; set; }
        [Display(Name = "Service Provider")]
        public string Provider { get; set; }
        [Display(Name = "Service Cost (Kina)")]
        public string Cost { get; set; }
        [Display(Name = "Current Mileage")]
        public string CurrentMileage { get; set; }
        [Display(Name = "Incident")]
        public string Incident { get; set; }
        [Display(Name = "Service Mechanic")]
        public string ServiceMechanic { get; set; }
        [Display(Name = "PO No. Reference")]
        public string PoReference { get; set; }
        [Display(Name = "Center")]
        public string Center { get; set; }
        [Display(Name = "Business Group")]
        public string BusinessGroup { get; set; }
        [Display(Name = "Service Job Number")]
        [UIHint("DisplayForEmphasized")]
        public string ServiceJobNumber { get; set; }
        [Display(Name = "Is Incident Service?")]
        public bool IsIncidentService { get; set; }
        [Display(Name = "Is Invoice Amount Paid?")]
        public bool IsAmountPaid { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime? LastUpdatedDate { get; set; }
        public VehicleDisplayInfoViewModel VehicleDisplayInfoViewModel { get; set; }

        public VehicleServiceDisplayViewModel()
        {
            this.VehicleDisplayInfoViewModel = new VehicleDisplayInfoViewModel();
        }
    }
}
