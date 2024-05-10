using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class CenterSecurityViewModel
    {


        #region Fields

        [HiddenInput(DisplayValue = false)]
        public int? CenterId { get; set; }
        public string UserId { get; set; }
        public string Center { get; set; }
        public bool HasAccess { get; set; }

        #endregion


    }

}