using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class TreeViewBaseDisplayViewModel
    {
        #region Fields
        [HiddenInput(DisplayValue = false)]
        public int? id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public bool? hasChildren { get; set; }
        public bool? @checked { get;set;}

        #endregion

        #region Constructors
        public TreeViewBaseDisplayViewModel()
        {
            this.hasChildren = false;
            this.@checked = false;
        }
        #endregion
    }

}