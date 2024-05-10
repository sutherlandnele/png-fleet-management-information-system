using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            ToTable("MstVehicle");


            HasKey<int>(k => k.Id);


            Property(e => e.AssetNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            Property(e => e.LastUpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            Property(e => e.PurchasingReferance)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.VehicleColor)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.RegistrationNumber)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.RegistryClass)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.EngineNumber)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.ChassisNumber)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);


            Property(e => e.Comments)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.BosReport)               
                .IsUnicode(false);


            HasMany(e => e.Compliances)
                .WithOptional(e => e.Vehicle)
                .HasForeignKey<int?>(e => e.RegistrationNumber);


            HasMany(e => e.FuelVouchers)
                .WithOptional(e => e.Vehicle)
                .HasForeignKey<int?>(e => e.RegistrationNumber);


            HasMany(e => e.Incidents)
                .WithOptional(e => e.Vehicle)
                .HasForeignKey<int?>(e => e.VehicleId);


            HasMany(e => e.ScheduleServices)
                .WithOptional(e => e.Vehicle)
                .HasForeignKey<int?>(e => e.VehicleId);


            HasMany(e => e.Services)
                .WithOptional(e => e.Vehicle)
                .HasForeignKey<int?>(e => e.VehicleId);


            HasMany(e => e.VehicleAllocations)
                .WithOptional(e => e.Vehicle)
                .HasForeignKey<int?>(e => e.VehicleId);


            HasMany(e => e.VehicleDisposals)
                .WithOptional(e => e.Vehicle)
                .HasForeignKey<int?>(e => e.VehicleId);


            HasMany(e => e.VehicleRefuels)
                .WithOptional(e => e.Vehicle)
                .HasForeignKey<int?>(e => e.VehicleId);


            HasMany(e => e.VehicleTransfers)
                .WithOptional(e => e.Vehicle)
                .HasForeignKey<int?>(e => e.VehicleId);
        }

    }
}
