using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class IncidentFileUploadConfiguration : EntityTypeConfiguration<IncidentFileUpload>
    {
        public IncidentFileUploadConfiguration()
        {
            ToTable("MstIncidentFileUpload");

            HasKey<int>(k => k.Id);

            Property(e => e.Name)
                  .HasMaxLength(500)
                .IsUnicode(false);

            Property(e => e.ContaintType)
                 .HasMaxLength(500)
                .IsUnicode(false);
        }

    }
}
