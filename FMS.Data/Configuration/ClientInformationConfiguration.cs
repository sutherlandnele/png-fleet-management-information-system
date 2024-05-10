using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class ClientInformationConfiguration : EntityTypeConfiguration<ClientInformation>
    {
        public ClientInformationConfiguration()
        {
            ToTable("MstClientInformation");

            HasKey<int>(k => k.Id);


            Property(e => e.ClientName)
                .HasMaxLength(250)
                .IsRequired()
                .IsUnicode(false);


            Property(e => e.Logo)
                .HasColumnType("image");


            Property(e => e.Slogan)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.PostalAddress)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.BusinessAddress)
            .HasMaxLength(250)
            .IsUnicode(false);


            Property(e => e.Telephone)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.Facsimile)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.Website)
                .HasMaxLength(250)
                .IsUnicode(false);

        }

    }
}
