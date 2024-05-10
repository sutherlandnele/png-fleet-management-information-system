using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppInterfaceConfiguration : EntityTypeConfiguration<AppInterface>
    {
        public AppInterfaceConfiguration()
        {
            ToTable("AppInterface");


            HasKey<int>(k => k.InterfaceId);


            Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);


            HasMany(e => e.AppActions)
                .WithRequired(e => e.AppInterface)
                .HasForeignKey<int>(e => e.InterfaceId)
                .WillCascadeOnDelete(false);


            HasMany(e => e.AppRoleInterfaceAccesses)
                .WithRequired(e => e.AppInterface)
                .HasForeignKey<int>(e => e.InterfaceId)
                .WillCascadeOnDelete(false);



        }

    }
}
