namespace FMS.Model
{
   
    using System.Collections.Generic;


 
    public class AppInterface
    {
    
        public int InterfaceId { get; set; }

   
        public string Description { get; set; }

        public int MenuId { get; set; }

         //public virtual List<AppAction> AppActions { get; set; }
        public  List<AppAction> AppActions { get; set; }

        //public virtual List<AppRoleInterfaceAccess> AppRoleInterfaceAccesses { get; set; }
        public  List<AppRoleInterfaceAccess> AppRoleInterfaceAccesses { get; set; }

        //public virtual AppMenu AppMenu { get; set; }
        public  AppMenu AppMenu { get; set; }
    }
}

