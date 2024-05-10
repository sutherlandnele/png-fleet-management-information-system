namespace FMS.Model
{
    public class AppRoleInterfaceAccess
    {
  
        public int InterfaceId { get; set; }

 
        public string RoleName { get; set; }

        public virtual AppInterface AppInterface { get; set; }
    }
}
