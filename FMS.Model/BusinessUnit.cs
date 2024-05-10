namespace FMS.Model
{

    using System.Collections.Generic;

    public class BusinessUnit
    {     
        public int UnitNumber { get; set; }
     
        public string Name { get; set; }
  
        public string Manager { get; set; }

        public int? ContactDetailId { get; set; }

       public virtual List<BusinessGroup> BusinessGroups { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }
    }
}
