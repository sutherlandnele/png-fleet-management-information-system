using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class VehicleDisposalEditViewModel
    {
        #region Fields
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }      
        [HiddenInput(DisplayValue = false)]
        public int? VehicleId { get; set; }
        [Required]
        [Display(Name = "Disposal Date")]
        public DateTime Date { get; set; }

        public string VehicleRegoNumber { get; set; }
        public string VehicleType { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleStatus { get; set; }
        public string VehicleCondition { get; set; }

        [Required]
        [Display(Name = "Disposal Value (Kina)")]
        public decimal Value { get; set; }
        [Required]
        [Display(Name = "Disposal Reference")]
        public string Referance { get; set; }       
        [Display(Name = "Disposal User Id")]
        public string DisposalUserId { get; set; }
        [Display(Name = "COD Report")]
        public string CODReport { get; set; }
        #endregion

    }

}