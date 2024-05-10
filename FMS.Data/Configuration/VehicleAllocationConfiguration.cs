using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class VehicleAllocationConfiguration : EntityTypeConfiguration<VehicleAllocation>
    {
        public VehicleAllocationConfiguration()
        {
            ToTable("TrnVehicleAllocation");
            HasKey<int>(k => k.Id);

        }

    }
}
