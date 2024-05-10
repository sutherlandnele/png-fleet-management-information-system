using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class VehicleTypeConfiguration : EntityTypeConfiguration<VehicleType>
    {
        public VehicleTypeConfiguration()
        {
            ToTable("MstVehicleType");


            HasKey<int>(k => k.Id);


            Property(e => e.Type)
               .HasMaxLength(250)
               .IsUnicode(false);


            HasMany(e => e.Vehicles)
                .WithOptional(e => e.VehicleType)
                .HasForeignKey<int?>(e => e.VehicleTypeId);

        }

    }
}
