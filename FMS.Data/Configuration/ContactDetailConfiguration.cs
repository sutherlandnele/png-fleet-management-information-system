using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class ContactDetailConfiguration : EntityTypeConfiguration<ContactDetail>
    {
        public ContactDetailConfiguration()
        {
            ToTable("MstContactDetail");


            HasKey<int>(k => k.Id);


            Property(e => e.ContactName)
              .HasMaxLength(250)
            .IsUnicode(false);


            Property(e => e.ContactPerson)
             .HasMaxLength(250)
            .IsUnicode(false);


            Property(e => e.PostalAddress)
             .HasMaxLength(500)
            .IsUnicode(false);


            Property(e => e.StreetAddress)
             .HasMaxLength(500)
            .IsUnicode(false);


            Property(e => e.Facsimile)
             .HasMaxLength(500)
            .IsUnicode(false);


            Property(e => e.Email)
             .HasMaxLength(250)
            .IsUnicode(false);


            Property(e => e.Telephone)
             .HasMaxLength(50)
            .IsUnicode(false);


            Property(e => e.Fax)
             .HasMaxLength(250)
            .IsUnicode(false);


            Property(e => e.Website)
            .HasMaxLength(250)
            .IsUnicode(false);


            Property(e => e.Mobile)
             .HasMaxLength(50)
            .IsUnicode(false);


            Property(e => e.Comments)
             .HasMaxLength(500)
            .IsUnicode(false);


            Property(e => e.LicenceNumber)
             .HasMaxLength(50)
            .IsUnicode(false);


            Property(e => e.LicanceClass)
             .HasMaxLength(50)
            .IsUnicode(false);


            Property(e => e.PPLPermitNumber)
            .HasMaxLength(10)
            .IsUnicode(false);


            HasMany(e => e.BusinessGroups)
             .WithOptional(e => e.ContactDetail)
             .HasForeignKey<int?>(e => e.CotactDetailId);


            HasMany(e => e.BusinessUnits)
            .WithOptional(e => e.ContactDetail)
            .HasForeignKey<int?>(e => e.ContactDetailId);


            HasMany(e => e.Centers)
            .WithOptional(e => e.ContactDetail)
            .HasForeignKey<int?>(e => e.ContactDetailId);


            HasMany(e => e.Incidents)
            .WithOptional(e => e.ContactDetail)
            .HasForeignKey<int?>(e => e.OperatorId);


            HasMany(e => e.FuelVouchers)
            .WithOptional(e => e.ContactDetail)
            .HasForeignKey<int?>(e => e.FuelDistributor);


            HasMany(e => e.Operators)
            .WithOptional(e => e.ContactDetail)
            .HasForeignKey<int?>(e => e.ContactDetailId);


            HasMany(e => e.Regionals)
            .WithOptional(e => e.ContactDetail)
            .HasForeignKey<int?>(e => e.ContactDetailId);


            HasMany(e => e.Services)
            .WithOptional(e => e.ContactDetail)
            .HasForeignKey<int?>(e => e.ServiceMechanic);


            HasMany(e => e.Services1)
            .WithOptional(e => e.ContactDetail1)
            .HasForeignKey<int?>(e => e.ProviderId);


            HasMany(e => e.Alerts)
            .WithOptional(e => e.MstContactDetail)
            .HasForeignKey<int?>(e => e.ContactId);


            HasMany(e => e.Vehicles)
            .WithOptional(e => e.ContactDetail)
            .HasForeignKey<int?>(e => e.Supplier);


            HasMany(e => e.VehicleAllocations)
            .WithOptional(e => e.ContactDetail)
            .HasForeignKey<int?>(e => e.OperatorId);


            HasMany(e => e.VehicleRefuels)
            .WithOptional(e => e.ContactDetail)
            .HasForeignKey<int?>(e => e.OperatorId);

            HasMany(e => e.VehicleRefuels1)
            .WithOptional(e => e.ContactDetail1)
            .HasForeignKey<int?>(e => e.FuelDistributorId);


        }

    }
}
