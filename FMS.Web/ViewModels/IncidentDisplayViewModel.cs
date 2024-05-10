using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{ 
    public  class IncidentDisplayViewModel
    {
        #region Fields

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }


        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

   
        [Display(Name = "Incident Date")]
        public string IncidentDate { get; set; }
        
        [Display(Name = "Incident Type")]
        public string IncidentType { get; set; }

        public string Description { get; set; }

        [Display(Name = "Accident Location")]
        public string Location { get; set; }

        [Display(Name = "Driver")]
        public string Driver { get; set; }

        [Display(Name = "Incident Requires Service?")]
        public string IncidentRequiresService { get; set; }

        [Display(Name = "Has Service Been Done?")]
        public string HasServiceBeenDone { get; set; }

        [Display(Name = "Has Report?")]
        public string HasReport { get; set; }

        [Display(Name = "Incident File Number")]
        public string IncidentFileNumber { get; set; }
        
        [Display(Name = "Incident Status")]
        public string IncidentStatus { get; set; }

        [Display(Name = "Full Accident Report")]
        public string IncidentFileName { get; set; }

        [Display(Name = "Accident Report Submitted Date")]
        public string DateofAccident { get; set; }


        [Display(Name = "Created By")]
        public string CreatedBy{ get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime? LastUpdatedDate { get; set; }

        public VehicleDisplayInfoViewModel VehicleDisplayInfoViewModel { get; set; }
        public IncidentDisplayViewModel()
        {
            this.VehicleDisplayInfoViewModel = new VehicleDisplayInfoViewModel();
        }

        #endregion


    }
}
