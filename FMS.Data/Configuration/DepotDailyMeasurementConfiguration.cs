using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class DepotDailyMeasurementConfiguration : EntityTypeConfiguration<DepotDailyMeasurement>
    {
        public DepotDailyMeasurementConfiguration()
        {
            ToTable("TrnDepotDailyMeasurement");

            HasKey<int>(k => k.Id);

            Property(e => e.DeportTankId)
                .HasMaxLength(100)
                .IsUnicode(false);

        }

    }
}
