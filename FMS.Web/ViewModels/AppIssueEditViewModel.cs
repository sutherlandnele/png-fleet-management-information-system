using FMS.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FMS.Web.ViewModels
{
    public  class AppIssueEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Issue Type")]     
        [Required]
        public int? AppIssueTypeId { get; set; }
        [StringLength(2000)]
        [Display(Name = "Brief Description of Request")]
        public string Description { get; set; }
        [Display(Name = "Requester Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email format is not valid")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Has Been Resolved?")]
        public bool? HasBeenResolved { get; set; }
        
    }
}
