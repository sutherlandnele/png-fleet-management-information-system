using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class UserContactConfiguration : EntityTypeConfiguration<UserContact>
    {
        public UserContactConfiguration()
        {
            ToTable("UserContact");

            HasKey<int>(k => k.Id);

            Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false);

        }

    }
}
