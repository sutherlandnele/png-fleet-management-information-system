using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class ClientInformationEditViewModel
    {


        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        public byte[] Logo { get; set; }
        public string Slogan { get; set; }
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }
        [Display(Name = "Business Address")]
        public string BusinessAddress { get; set; }
        public string Telephone { get; set; }
        public string Facsimile { get; set; }
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email format is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [RegularExpression(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?", ErrorMessage = "Website format is not valid")]
        [DataType(DataType.Url)]
        public string Website { get; set; }
    }

}