using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class VehicleRefuelConfiguration : EntityTypeConfiguration<VehicleRefuel>
    {
        public VehicleRefuelConfiguration()
        {
            ToTable("MstVehicleRefuel");

            HasKey<int>(k => k.Id);

            Property(e => e.CreatedBy)
             .HasMaxLength(50)
             .IsUnicode(false);

            Property(e => e.LastUpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.DocketNumber)
               .HasMaxLength(250)
               .IsUnicode(false);

            Property(e => e.BowserNumber)
               .HasMaxLength(100)
               .IsUnicode(false);

            Property(e => e.TotalCost)
                .HasPrecision(18, 0);

            Property(e => e.RegistrationNumber)
               .HasMaxLength(50)
               .IsUnicode(false);

            Property(e => e.VoucherNumber)
            .HasMaxLength(10)
            .IsUnicode(false);

            Property(e => e.VoucherReceiptNumber)
            .HasMaxLength(50)
            .IsUnicode(false);

        }

    }
}
