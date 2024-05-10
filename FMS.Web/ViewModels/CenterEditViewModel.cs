using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class CenterEditViewModel
    {
        #region Fields

        [HiddenInput(DisplayValue = false)]
        public int CenterNumber { get; set; }
        [Display(Name = "Center Code")]
        [StringLength(2)]
        [Required]
        public string CenterCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Max. Service")]
        public int? MaxVehicleServiceCapacityPerMonth { get; set; }
        [Required]
        [Display(Name = "Max. Voucher")]
        public int? MaxVehicleFuelVoucherCapacityPerMonth { get; set; }

        [UIHint("RegionEditor")]
        [Display(Name = "Region")]
        public int? RegionId { get; set; }

        [UIHint("ManagerEditor")]
        [Display(Name = "Center Manager")]
        public int? ContactDetailId { get; set; }

        public ContactDetailDisplayViewModel contactDetailDisplayViewModel { get; set; }

        #endregion

        #region Constructors

        public CenterEditViewModel()
        {
            this.contactDetailDisplayViewModel = new ContactDetailDisplayViewModel();
        }


        #endregion


    }

}