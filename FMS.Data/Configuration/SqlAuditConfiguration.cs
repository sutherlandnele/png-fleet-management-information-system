using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class SqlAuditConfiguration : EntityTypeConfiguration<SqlAudit>
    {
        public SqlAuditConfiguration()
        {
            ToTable("MstSqlAudit");

            HasKey<int>(k => k.Id);


            Property(e => e.Username)
                .HasMaxLength(150)
                .IsUnicode(false);


            Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.ComputerName)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.SubSystem)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.DatabaseTable)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.DatabaseAction)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.SqlStatement)
                .HasMaxLength(250)
                .IsUnicode(false);

        }

    }
}
