using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class ModelConfiguration : EntityTypeConfiguration<Model.Model>
    {
        public ModelConfiguration()
        {
            ToTable("MstModel");

            HasKey<int>(k => k.Id);

            Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);

            HasMany(e => e.Vehicles)
                .WithOptional(e => e.Model)
                .HasForeignKey<int?>(e => e.ModelId);
        }

    }
}
