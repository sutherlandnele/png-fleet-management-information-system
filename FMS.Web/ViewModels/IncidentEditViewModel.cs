using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{ 
    public  class IncidentEditViewModel
    {
        #region Fields

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        
        [UIHint("VehicleIdByCenterSecurityEditor")]
        public int? VehicleId { get; set; }

        [Required]
        [Display(Name = "Incident Date")]
        [UIHint("NullableDateEditor")]
        public DateTime? DateAndTime { get; set; }

        [Required]
        [Display(Name = "Incident Type")]
        public int? IncidentTypeId { get; set; }

        public string Description { get; set; }

        [Display(Name = "Accident Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Driver")]
        [UIHint("OperatorEditor")]
        public int? OperatorId { get; set; }


        [Display(Name = "Incident Requires Service?")]
        public bool? RequiredService { get; set; }

        [Display(Name = "Has Service Been Done?")]
        public bool? ServiceDone { get; set; }

        [Display(Name = "Has Report?")]
        public bool? HasReport { get; set; }

        [Display(Name = "Incident File Number")]
        [Required]
        public string IncidentFileNumber { get; set; }

        [Required]
        [Display(Name = "Incident Status")]
        public int? IncidentStatusId { get; set; }

        [Display(Name = "Full Accident Report")]
        public string IncidentFileName { get; set; }

        [Display(Name = "Accident Report Submitted Date")]
        [UIHint("NullableDateEditor")]
        public DateTime? DateofAccident { get; set; }


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

        #endregion

        #region Constructors
        public IncidentEditViewModel()
        {
            this.VehicleDisplayInfoViewModel = new VehicleDisplayInfoViewModel();
        }
        #endregion


    }
}
