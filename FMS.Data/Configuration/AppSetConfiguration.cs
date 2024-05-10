using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppSetConfiguration : EntityTypeConfiguration<AppSet>
    {
        public AppSetConfiguration()
        {
            ToTable("tr_Set");


            HasKey(k => new { k.Id, k.Member });

            Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnOrder(0)
                .IsUnicode(false);

            Property(e => e.Member)
                .HasMaxLength(255)
                .HasColumnOrder(1)
                .IsUnicode(false);

        }

    }
}
