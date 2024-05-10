using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class OperatorConfiguration : EntityTypeConfiguration<Operator>
    {
        public OperatorConfiguration()
        {
            ToTable("MstOperator");


            HasKey<int>(k => k.Id);


            Property(e => e.DriverName)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.LicenseNumber)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.LicenseClass)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.StaffNumber)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.PermiteNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

        }

    }
}
