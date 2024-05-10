namespace FMS.Model
{

    using System.Collections.Generic;


    public class DepotTank
    {


        public int? FuelTypeId { get; set; }

        public decimal? CurrentVolume { get; set; }

        public decimal? MaximumCapacity { get; set; }


        public string Name { get; set; }

        public int? CenterId { get; set; }

        public string BowserNumber { get; set; }

        public virtual Center Center { get; set; }

   
        public virtual List<DepotRefuel> DepotRefuels { get; set; }

   
        public virtual List<DepotDailyMeasurement> DepotDailyMeasurements { get; set; }

        public virtual SystemParameter SystemParameter { get; set; }

    
        public virtual List<VehicleRefuel> VehicleRefuels { get; set; }
    }
}
