using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class VehicleAllocationViewModel
    {
        #region Fields

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? VehicleId { get; set; }

        [Required]
        [Display(Name = "Driver/Custodian")]
        public int? OperatorId { get; set; }

        [Required]
        [Display(Name = "Allocated Start/End Date")]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public VehicleDisplayInfoViewModel VehicleDisplayInfoViewModel { get; set; }
        public OperatorDisplayInfoViewModel OperatorDisplayInfoViewModel { get; set; }
        #endregion

        #region Constructors
        public VehicleAllocationViewModel()
        {
            VehicleDisplayInfoViewModel = new VehicleDisplayInfoViewModel();
            OperatorDisplayInfoViewModel = new OperatorDisplayInfoViewModel();
        }
        #endregion

    }

}