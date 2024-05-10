namespace FMS.Model
{

    using System.Collections.Generic;
 
    public class Center
    {
     
        public int CenterNumber { get; set; }

        public string CenterCode { get; set; }

        public string Name { get; set; }

        public int? MaxVehicleServiceCapacityPerMonth { get; set; }

        public int? MaxVehicleFuelVoucherCapacityPerMonth { get; set; }

        public int? RegionaNumberId { get; set; }
   
        public string Manager { get; set; }

        public int? ContactDetailId { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }

        public virtual Regional Regional { get; set; }

        public virtual List<CenterSecurity> CenterSecurities { get; set; }

        public virtual List<DepotDailyMeasurement> DepotDailyMeasurements { get; set; }

        public virtual List<DepotRefuel> DepotRefuels { get; set; }

        public virtual List<DepotTank> DepotTanks { get; set; }

         public virtual List<ContactDetail> ContactDetails { get; set; }

         public virtual List<Operator> Operators { get; set; }

        public virtual List<Service> Services { get; set; }

         public virtual List<Vehicle> Vehicles { get; set; }

         public virtual List<VehicleRefuel> VehicleRefuels { get; set; }
    }
}
