using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FMS.Common;
using FMS.Model;

namespace FMS.Web.ViewModels
{
    public class TreeViewRolePermissionDisplayViewModel : TreeViewBaseDisplayViewModel
    {
        #region Fields
        public Parameters.RolePermissionType RolePermissionType { get; set; }
        public string RoleName { get; set; }

        #endregion

        #region Constructors
        public TreeViewRolePermissionDisplayViewModel():base()
        {

        }
        #endregion
    }

}