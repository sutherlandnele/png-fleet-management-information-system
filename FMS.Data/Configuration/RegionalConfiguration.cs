using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class RegionalConfiguration : EntityTypeConfiguration<Regional>
    {
        public RegionalConfiguration()
        {
            ToTable("MstRegional");


            HasKey<int>(k => k.RegionNumber);


            Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.Manager)
                .HasMaxLength(250)
                .IsUnicode(false);


            HasMany(e => e.Centers)
                .WithOptional(e => e.Regional)
                .HasForeignKey<int?>(e => e.RegionaNumberId);

        }

    }
}
