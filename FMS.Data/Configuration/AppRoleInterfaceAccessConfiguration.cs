using FMS.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppRoleInterfaceAccessConfiguration : EntityTypeConfiguration<AppRoleInterfaceAccess>
    {
        public AppRoleInterfaceAccessConfiguration()
        {
            ToTable("AppRoleInterfaceAccess");

           
                HasKey(k => new { k.InterfaceId, k.RoleName });

           
                Property(e => e.InterfaceId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                    .HasColumnOrder(0);

           
                Property(e => e.RoleName)
                    .HasColumnOrder(1)
                    .IsUnicode(false)
                    .HasMaxLength(250);

        }

    }
}
