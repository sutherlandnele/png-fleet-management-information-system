namespace FMS.Model
{
    using System;
    using System.Collections.Generic;


    public class AppAction
    {
                      
        public int ActionId { get; set; }

    
        public string Description { get; set; }

        public int InterfaceId { get; set; }

        //public virtual AppInterface AppInterface { get; set; }
        public AppInterface AppInterface { get; set; }

        //public virtual List<AppRoleActionAccess> AppRoleActionAccesses { get; set; }
        public List<AppRoleActionAccess> AppRoleActionAccesses { get; set; }
    }
}
