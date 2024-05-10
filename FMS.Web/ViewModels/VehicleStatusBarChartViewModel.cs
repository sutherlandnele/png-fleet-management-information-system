using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public  class VehicleStatusBarChartViewModel
    {
        public string Status { get; set; }        
        public int? Count { get; set; }
    }
}
