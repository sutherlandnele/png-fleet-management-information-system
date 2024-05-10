using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class AlertConfiguration : EntityTypeConfiguration<Alert>
    {
        public AlertConfiguration()
        {
            ToTable("TrnAlert");

            HasKey<int>(k => k.Id);

        }

    }
}
