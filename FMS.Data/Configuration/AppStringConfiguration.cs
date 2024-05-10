using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppStringConfiguration : EntityTypeConfiguration<AppString>
    {
        public AppStringConfiguration()
        {
            ToTable("tr_String");

            HasKey<string>(k => k.Id);

            Property(e => e.Id)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            Property(e => e.Value)
                    .HasMaxLength(4000)
                    .IsRequired();

        }

    }
}
