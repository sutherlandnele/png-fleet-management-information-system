using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public  class FuelUsageBarChartViewModel
    {
        
        public decimal? Litres { get; set; }
        public DateTime? Date { get; set; }
    }
}
