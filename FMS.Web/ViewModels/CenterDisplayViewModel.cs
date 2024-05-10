using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class CenterDisplayViewModel
    {
        #region Fields

        [HiddenInput(DisplayValue = false)]
        public int CenterNumber { get; set; }
        [Display(Name = "Center Code")]
        public string CenterCode { get; set; }

        public string Name { get; set; }

        [Display(Name = "Max. Vehicle Service Count")]
        public int? MaxVehicleServiceCapacityPerMonth { get; set; }

        [Display(Name = "Max. Vehicle Fuel Voucher Count")]
        public int? MaxVehicleFuelVoucherCapacityPerMonth { get; set; }

        public string Region { get; set; }
        [Display(Name = "Center Manager")]
        public string Manager { get; set; }

        public ContactDetailDisplayViewModel contactDetailDisplayViewModel { get; set; }

        #endregion

        #region Constructors

        public CenterDisplayViewModel()
        {
            this.contactDetailDisplayViewModel = new ContactDetailDisplayViewModel();
        }


        #endregion


    }

}