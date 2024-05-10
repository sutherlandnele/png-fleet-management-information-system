using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class IncidentConfiguration : EntityTypeConfiguration<Incident>
    {
        public IncidentConfiguration()
        {
            ToTable("MstIncident");


            HasKey<int>(k => k.Id);


            Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);

            Property(e => e.CreatedBy)
                 .HasMaxLength(50)
                 .IsUnicode(false);

            Property(e => e.LastUpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            Property(e => e.Location)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.IncidentFileNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            Property(e => e.IncidentFileName)
                .HasMaxLength(50)
                .IsUnicode(false);


            HasMany(e => e.IncidentFileUploads)
                .WithOptional(e => e.Incident)
                .HasForeignKey<int?>(e => e.IncidentId);


            HasMany(e => e.Services)
                .WithOptional(e => e.Incident)
                .HasForeignKey<int?>(e => e.IncidentId);

        }

    }
}
