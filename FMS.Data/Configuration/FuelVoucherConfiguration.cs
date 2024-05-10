using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class FuelVoucherConfiguration : EntityTypeConfiguration<FuelVoucher>
    {
        public FuelVoucherConfiguration()
        {
            ToTable("MstFuelVoucher");

            HasKey<int>(k => k.VoucherNumber);


            Property(e => e.FuelAmount)
                .HasPrecision(18, 0);


            Property(e => e.FuelQuantity)
                .HasMaxLength(50);



            Property(e => e.Remarks)
                .HasMaxLength(250)
                .IsUnicode(false);

        }

    }
}
