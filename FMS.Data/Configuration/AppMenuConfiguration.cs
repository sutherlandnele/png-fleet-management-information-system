using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppMenuConfiguration : EntityTypeConfiguration<AppMenu>
    {
        public AppMenuConfiguration()
        {
            ToTable("AppMenus");


            HasKey<int>(k => k.MenuId);


            Property(e => e.Description)
            .HasMaxLength(50)
            .IsUnicode(false);


            HasMany(e => e.AppInterfaces)
            .WithRequired(e => e.AppMenu)
            .HasForeignKey<int>(e => e.MenuId)
            .WillCascadeOnDelete(false);


            HasMany(e => e.AppRoleMenuAccesses)
            .WithRequired(e => e.AppMenu)
            .HasForeignKey<int>(e => e.MenuId)
            .WillCascadeOnDelete(false);



        }

    }
}
