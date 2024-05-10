using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public  class DepotTankEditViewModel
    {
        [UIHint("MaskedTextBoxEditor")]
        public string BowserNumber { get; set; }

        [UIHint("FuelTypeIdEditor")]
        [Display(Name = "Fuel Type")]
        public int? FuelTypeId { get; set; }

        [UIHint("NumericNullableDecimalTextBox")]      
        public decimal? CurrentVolume { get; set; }

        [UIHint("NumericNullableDecimalTextBox")]
        public decimal? MaximumCapacity { get; set; }
        
        [UIHint("MaskedTextBoxEditor")]
        public string Name { get; set; }

        [Display(Name = "Center")]
        [UIHint("CenterByRegionEditor")]
        public int? CenterId { get; set; }
        [Display(Name = "Region")]
        [UIHint("RegionEditor")]
        public int? RegionId { get; set; }
        public string RegionDisplay { get; set; }
        public string CenterDisplay { get; set; }
        public string FuelTypeDisplay { get; set; }
        public string MaximumCapacityDisplay { get; set; }
        public string CurrentVolumeDisplay { get; set; }
      
    }
}
