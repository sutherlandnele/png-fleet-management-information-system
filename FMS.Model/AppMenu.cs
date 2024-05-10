namespace FMS.Model
{
    using System;
    using System.Collections.Generic;
    public class AppMenu
    {

        public int MenuId { get; set; }

        public string Description { get; set; }

        //public virtual List<AppInterface> AppInterfaces { get; set; }
        public List<AppInterface> AppInterfaces { get; set; }
        //public virtual List<AppRoleMenuAccess> AppRoleMenuAccesses { get; set; }
        public List<AppRoleMenuAccess> AppRoleMenuAccesses { get; set; }
    }
}
