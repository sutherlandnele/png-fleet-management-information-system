namespace FMS.Model
{
    public class AppRoleMenuAccess
    {
        public int MenuId { get; set; } 
        public string RoleName { get; set; }
        public virtual AppMenu AppMenu { get; set; }
    }
}
