using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class VehicleTransferViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? VehicleId { get; set; }

        [Required]
        [Display(Name = "Business Group")]
        public int? BusinessGroupId { get; set; }

        [Required]
        [Display(Name = "Center")]
        public int? CenterId { get; set; }

        [Required]
        [Display(Name = "Transfer Date")]
        public DateTime? Date { get; set; }

        public VehicleDisplayInfoViewModel VehicleDisplayInfoViewModel { get; set; }

        #region Constructors
        public VehicleTransferViewModel()
        {
            VehicleDisplayInfoViewModel = new VehicleDisplayInfoViewModel();
        }
        #endregion


    }

}