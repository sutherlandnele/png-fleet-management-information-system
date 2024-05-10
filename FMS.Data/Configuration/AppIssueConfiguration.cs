using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AppIssueConfiguration : EntityTypeConfiguration<AppIssue>
    {
        public AppIssueConfiguration()
        {
            ToTable("AppIssue");

            HasKey<int>(k => k.Id);

            Property(e => e.Description)
            .HasMaxLength(2000)
            .IsUnicode(false);

        }

    }
}
