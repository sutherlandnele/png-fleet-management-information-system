using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppObjectConfiguration : EntityTypeConfiguration<AppObject>
    {
        public AppObjectConfiguration()
        {
            ToTable("tr_Object");

            HasKey<string>(k => k.Id);

            Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false);

            Property(e => e.Value)
                .IsRequired()
                .HasColumnType("image");

        }

    }
}
