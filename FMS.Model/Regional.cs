namespace FMS.Model
{
 
    using System.Collections.Generic;

    public  class Regional
    {
  
        public int RegionNumber { get; set; }

  
        public string Name { get; set; }

 
        public string Manager { get; set; }

        public int? ContactDetailId { get; set; }

         public virtual List<Center> Centers { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }
    }
}
