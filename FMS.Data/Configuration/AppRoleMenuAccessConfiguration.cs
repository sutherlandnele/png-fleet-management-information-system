using FMS.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppRoleMenuAccessConfiguration : EntityTypeConfiguration<AppRoleMenuAccess>
    {
        public AppRoleMenuAccessConfiguration()
        {
            ToTable("AppRoleMenuAccess");

            HasKey(k => new { k.MenuId, k.RoleName });

            Property(e => e.MenuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(0);

            Property(e => e.RoleName)
                .HasColumnOrder(1)
                .IsUnicode(false)
                .HasMaxLength(250);
        }

    }
}
