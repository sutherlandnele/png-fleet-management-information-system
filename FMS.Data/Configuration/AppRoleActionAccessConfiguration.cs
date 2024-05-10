using FMS.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppRoleActionAccessConfiguration : EntityTypeConfiguration<AppRoleActionAccess>
    {
        public AppRoleActionAccessConfiguration()
        {
            ToTable("AppRoleActionAccess");

            HasKey(k => new { k.ActionId, k.RoleName });

            Property(e => e.ActionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0);


            Property(e => e.RoleName)
                .HasColumnOrder(1)
                .IsUnicode(false)
                .HasMaxLength(250);

        }

    }
}
