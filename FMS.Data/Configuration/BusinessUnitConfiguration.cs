using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class BusinessUnitConfiguration : EntityTypeConfiguration<BusinessUnit>
    {
        public BusinessUnitConfiguration()
        {
            ToTable("MstBusinessUnit");


            HasKey<int>(k => k.UnitNumber);


            Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.Manager)
                .HasMaxLength(250)
                .IsUnicode(false);


            HasMany(e => e.BusinessGroups)
                .WithOptional(e => e.BusinessUnit)
                .HasForeignKey<int?>(e => e.BusinessUnitId);
        }

    }
}
