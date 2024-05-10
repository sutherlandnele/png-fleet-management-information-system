namespace FMS.Model
{
   
    using System.Collections.Generic;


    public class BusinessGroup
    {
               
        public int GroupNumber { get; set; }
              
        public string GroupName { get; set; }

        public int? BusinessUnitId { get; set; }
               
        public string GroupManager { get; set; }

        public int? CotactDetailId { get; set; }

        public virtual BusinessUnit BusinessUnit { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }

        public virtual List<Service> Services { get; set; }

        public virtual List<Operator> Operators { get; set; }

         public virtual List<Vehicle> Vehicles { get; set; }
    }
}
