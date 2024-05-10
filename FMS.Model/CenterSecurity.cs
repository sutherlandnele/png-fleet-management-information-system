namespace FMS.Model
{

    public class CenterSecurity
    {
        public int Id { get; set; }


        public string UserId { get; set; }

        public int? CenterId { get; set; }

        public virtual Center Center { get; set; }
    }
}
