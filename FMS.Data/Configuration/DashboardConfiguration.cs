using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class DashboardConfiguration : EntityTypeConfiguration<Dashboard>
    {
        public DashboardConfiguration()
        {
            ToTable("MstDashboard");

           HasKey<int>(k => k.ID);

           Property(e => e.Role)
                .HasMaxLength(250)
                .IsRequired()
                .IsUnicode(false);

            Property(e => e.DashBoardPath)
                .HasMaxLength(250)
                .IsUnicode(false);

        }

    }
}
