using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class ComplianceConfiguration : EntityTypeConfiguration<Compliance>
    {
        public ComplianceConfiguration()
        {
            ToTable("MstCompliance");

           HasKey<int>(k => k.ComplianceNumber);

            Property(e => e.CreatedBy)
                 .HasMaxLength(50)
                 .IsUnicode(false);

            Property(e => e.LastUpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false);
        }

    }
}
