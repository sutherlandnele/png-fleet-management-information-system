namespace FMS.Model
{

    public class AppRoleActionAccess
    {

        public int ActionId { get; set; }

        public string RoleName { get; set; }

        public virtual AppAction AppAction { get; set; }
    }
}
