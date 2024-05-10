using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class CenterSecurityConfiguration : EntityTypeConfiguration<CenterSecurity>
    {
        public CenterSecurityConfiguration()
        {
            ToTable("TrnCenterSecurity");

            HasKey<int>(k => k.Id);

            Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false);

        }

    }
}
