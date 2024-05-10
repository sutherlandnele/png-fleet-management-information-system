using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class ScheduleServiceConfiguration : EntityTypeConfiguration<ScheduleService>
    {
        public ScheduleServiceConfiguration()
        {
            ToTable("MstScheduleService");

            HasKey<int>(k => k.Id);
        }

    }
}
