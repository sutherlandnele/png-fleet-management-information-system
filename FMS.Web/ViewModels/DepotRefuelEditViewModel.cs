using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public  class DepotRefuelEditViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Bowser #")]
        [UIHint("DepotTankByCenterEditor")]
        public string DeportTankId { get; set; }
        [Display(Name = "Refuel Date")]
        [UIHint("NullableDateEditor")]
        public DateTime? Date { get; set; }
        [UIHint("NumericNullableDecimalTextBox")]
        [Display(Name = "Purchase Volume")]
        public decimal? PurchaseVolume { get; set; }
        [UIHint("NumericNullableDecimalTextBox")]
        [Display(Name = "Previous Volume")]
        public decimal? PreviousVolume { get; set; }
        [UIHint("NumericNullableDecimalTextBox")]
        [Display(Name = "Current Volume")]
        public decimal? CurrentVolume { get; set; }
        [Display(Name = "Center")]
        [UIHint("CenterByRegionEditor")]
        public int? CenterId { get; set; }
        [Display(Name = "Region")]
        [UIHint("RegionEditor")]
        public int? RegionId { get; set; }
        [UIHint("NumericNullableDecimalTextBox")]
        public Decimal? MaximumCapacity { get; set; }
        public string CenterDisplay { get; set; }
        public string RegionDisplay { get; set; }
        public string PreviousVolumeDisplay { get; set; }
        public string CurrentVolumeDisplay { get; set; }
        public string PurchaseVolumeDisplay { get; set; }
    }
}
