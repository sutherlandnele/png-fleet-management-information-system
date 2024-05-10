using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppLockConfiguration : EntityTypeConfiguration<AppLock>
    {
        public AppLockConfiguration()
        {
            ToTable("tr_AppLock");

            HasKey<string>(k => k.Id);

            Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false);

        }

    }
}
