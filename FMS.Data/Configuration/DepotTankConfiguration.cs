using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class DepotTankConfiguration : EntityTypeConfiguration<DepotTank>
    {
        public DepotTankConfiguration()
        {
            ToTable("MstDepotTank");


            HasKey<string>(k => k.BowserNumber);


            Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.BowserNumber)
                .HasMaxLength(100)
                .IsUnicode(false);


            HasMany(e => e.DepotDailyMeasurements)
                .WithOptional(e => e.DepotTank)
                .HasForeignKey<string>(e => e.DeportTankId);


            HasMany(e => e.VehicleRefuels)
                .WithOptional(e => e.DepotTank)
                .HasForeignKey<string>(e => e.BowserNumber);

        }

    }
}
