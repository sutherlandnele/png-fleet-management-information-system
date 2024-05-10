using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class VehicleTransferConfiguration : EntityTypeConfiguration<VehicleTransfer>
    {
        public VehicleTransferConfiguration()
        {
            ToTable("MstVehicleTransfer");

            HasKey<int>(k => k.Id);
        }

    }
}
