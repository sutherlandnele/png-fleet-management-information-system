using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class SqlAuditViewModel
    {
        #region Fields

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }


        [Display(Name = "Date & Time")]
        public string DateAndTime { get; set; }

        [Display(Name = "User Name")]
        public string Username { get; set; }

        public string Role { get; set; }

        [Display(Name = "Computer Name")]
        public string ComputerName { get; set; }

        public string SubSystem { get; set; }

        [Display(Name = "Database Table")]
        public string DatabaseTable { get; set; }

        [Display(Name = "Database Action")]
        public string DatabaseAction { get; set; }

        #endregion
    }

}