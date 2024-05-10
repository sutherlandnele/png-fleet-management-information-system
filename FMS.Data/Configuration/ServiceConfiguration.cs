using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class ServiceConfiguration : EntityTypeConfiguration<Service>
    {
        public ServiceConfiguration()
        {
            ToTable("MstService");

            HasKey<int>(k => k.Id);

            Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);

            Property(e => e.CreatedBy)
                 .HasMaxLength(50)
                 .IsUnicode(false);

            Property(e => e.LastUpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            Property(e => e.ServiceJobNumber)
                .HasMaxLength(10)
                .IsUnicode(false);

            Property(e => e.PoReference)
                .HasMaxLength(250)
                .IsUnicode(false);

        }

    }
}
