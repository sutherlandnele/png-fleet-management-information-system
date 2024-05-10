using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public  class NotificationEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Notification Type")]
        [UIHint("NotificationTypeEditor")]
        public int? NotificationTypeId { get; set; }
        [Display(Name = "When Appear Before")]
        [UIHint("WhenAppearBeforeEditor")]
        public int? WhenAppearId { get; set; }
        [Display(Name = "Severity")]
        [UIHint("SeverityEditor")]
        public int? SeverityId { get; set; }
        [Display(Name = "Email Template")]
        [UIHint("EmailTemplateEditor")]
        public int? EmailTemplateId { get; set; }
        public string NotificationTypeDisplay { get; set; }
        public string WhenAppearBeforeDisplay { get; set; }
        public string SeverityDisplay { get; set; }
        public string EmailTemplateDisplay { get; set; }

    }
}
