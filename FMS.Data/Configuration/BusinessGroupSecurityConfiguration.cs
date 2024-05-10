using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class BusinessGroupSecurityConfiguration : EntityTypeConfiguration<BusinessGroupSecurity>
    {
        public BusinessGroupSecurityConfiguration()
        {
            ToTable("TrnBusinessGroupSecurity");

            HasKey<int>(k => k.Id);

            Property(e => e.UserId)
                .HasMaxLength(250)
                .IsUnicode(false);

        }

    }
}
