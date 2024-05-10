using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppActionConfiguration : EntityTypeConfiguration<AppAction>
    {
        public AppActionConfiguration()
        {
            ToTable("AppActions");

            HasKey<int>(k => k.ActionId);

            Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);

            HasMany(e => e.AppRoleActionAccesses)
                .WithRequired(e => e.AppAction)
                .HasForeignKey<int>(e => e.ActionId)
                .WillCascadeOnDelete(false);

        }

    }
}
