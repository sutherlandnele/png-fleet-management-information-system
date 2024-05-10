using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class BusinessGroupConfiguration : EntityTypeConfiguration<BusinessGroup>
    {
        public BusinessGroupConfiguration()
        {
            ToTable("MstBusinessGroup");

            HasKey<int>(k => k.GroupNumber);

            Property(e => e.GroupName)
                .HasMaxLength(250)
                .IsUnicode(false);

            Property(e => e.GroupManager)
                .HasMaxLength(250)
                .IsUnicode(false);

            HasMany(e => e.Services)
                .WithOptional(e => e.BusinessGroup)
                .HasForeignKey<int?>(e => e.BusinessGroupId);

            HasMany(e => e.Operators)
                .WithOptional(e => e.BusinessGroup)
                .HasForeignKey<int?>(e => e.BusinessGroupId);

            HasMany(e => e.Vehicles)
                .WithOptional(e => e.BusinessGroup)
                .HasForeignKey<int?>(e => e.BusinessGroupId);
        }

    }
}
