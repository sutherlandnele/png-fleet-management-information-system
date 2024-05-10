using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class DepotRefuelConfiguration : EntityTypeConfiguration<DepotRefuel>
    {
        public DepotRefuelConfiguration()
        {
            ToTable("MstDepotRefuel");

          HasKey<int>(k => k.Id);

         Property(e => e.BowserNumber)
                .HasMaxLength(100)
                .IsUnicode(false);


        }

    }
}
