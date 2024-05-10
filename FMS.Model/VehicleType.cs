namespace FMS.Model
{

    using System.Collections.Generic;


    public  class VehicleType
    {

        public int Id { get; set; }

        public string Type { get; set; }

        public int? LifeSpan { get; set; }

        public decimal? MileageSpan { get; set; }
       public virtual List<Vehicle> Vehicles { get; set; }
    }
}
