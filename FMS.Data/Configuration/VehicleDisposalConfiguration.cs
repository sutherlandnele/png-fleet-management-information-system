using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class VehicleDisposalConfiguration : EntityTypeConfiguration<VehicleDisposal>
    {
        public VehicleDisposalConfiguration()
        {
            ToTable("MstVehicleDisposal");


            HasKey<int>(k => k.Id);


            Property(e => e.Value)
               .HasMaxLength(250)
               .IsUnicode(false);


            Property(e => e.Referance)
               .HasMaxLength(250)
               .IsUnicode(false);


            Property(e => e.DisposalUserId)
               .HasMaxLength(50)
               .IsUnicode(false);


            Property(e => e.CODReport)                
                .IsUnicode(false);
        }

    }
}
