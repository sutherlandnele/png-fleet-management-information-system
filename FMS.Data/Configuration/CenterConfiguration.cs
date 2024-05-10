using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class CenterConfiguration : EntityTypeConfiguration<Center>
    {
        public CenterConfiguration()
        {
            ToTable("MstCenter");

            HasKey<int>(k => k.CenterNumber);

            Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);

            Property(e => e.Manager)
                .HasMaxLength(50)
                .IsUnicode(false);

            Property(e => e.CenterCode)
                .HasMaxLength(2)
                .IsRequired()
                .IsUnicode(false);

            HasMany(e => e.CenterSecurities)
                .WithOptional(e => e.Center)
                .HasForeignKey<int?>(e => e.CenterId);


            HasMany(e => e.DepotDailyMeasurements)
                .WithOptional(e => e.Center)
                .HasForeignKey<int?>(e => e.CenterId);


            HasMany(e => e.DepotRefuels)
                .WithOptional(e => e.Center)
                .HasForeignKey<int?>(e => e.CenterId);


            HasMany(e => e.DepotTanks)
                .WithOptional(e => e.Center)
                .HasForeignKey<int?>(e => e.CenterId);


            HasMany(e => e.ContactDetails)
                .WithOptional(e => e.Center)
                .HasForeignKey<int?>(e => e.CenterId);


            HasMany(e => e.Operators)
                .WithOptional(e => e.Center)
                .HasForeignKey<int?>(e => e.CenterId);


            HasMany(e => e.Services)
                .WithOptional(e => e.Center)
                .HasForeignKey<int?>(e => e.CenterId);


            HasMany(e => e.Vehicles)
                .WithOptional(e => e.Center)
                .HasForeignKey<int?>(e => e.CenterId);


            HasMany(e => e.VehicleRefuels)
                .WithOptional(e => e.Center)
                .HasForeignKey<int?>(e => e.CenterId);

        }

    }
}
