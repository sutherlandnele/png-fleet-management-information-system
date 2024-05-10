using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Web.ViewModels
{
    public  class DepotDailyMeasurementEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tank")]
        [UIHint("DepotTankByCenterEditor")]
        public string DeportTankId { get; set; }

        [Display(Name = "Center")]
        [UIHint("CenterByRegionEditor")]
        public int? CenterId { get; set; }

        [Display(Name = "Region")]
        [UIHint("RegionEditor")]
        public int? RegionId { get; set; }

        [Display(Name = "Measurement Date")]
        [UIHint("NullableDateEditor")]        
        public DateTime? Date { get; set; }

        [UIHint("NumericNullableDecimalTextBox")]
        [Display(Name = "Start Volume (Litres)")]
        public decimal? StartVolume { get; set; }

        [UIHint("NumericNullableDecimalTextBox")]
        [Display(Name = "End Volume (Litres)")]
        public decimal? EndVolume { get; set; }

        [Display(Name = "Bowser #")]
        public string BowserNumber { get; set; }
        public string CenterDisplay { get; set; }
        public string RegionDisplay { get; set; }
        public string StartVolumeDisplay { get; set; }
        public string EndVolumeDisplay { get; set; }

    }
}
