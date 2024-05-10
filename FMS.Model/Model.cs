namespace FMS.Model
{
 
    using System.Collections.Generic;



    public partial class Model
    {


        public int Id { get; set; }

        public string Name { get; set; }

        public int? MakeId { get; set; }

        public virtual SystemParameter SystemParameter { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
