using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class SystemParameterCodeConfiguration : EntityTypeConfiguration<SystemParameterCode>
    {
        public SystemParameterCodeConfiguration()
        {
            ToTable("MstSystemParameterCode");

            HasKey<int>(k => k.Id);

            Property(e => e.ParameterCode)
                .HasMaxLength(250)
                .IsRequired()
                .IsUnicode(false);

            HasMany(e => e.SystemParameters)
                .WithOptional(e => e.SystemParameterCode)
                .HasForeignKey<int?>(e => e.ParameterCodeId);

        }

    }
}
