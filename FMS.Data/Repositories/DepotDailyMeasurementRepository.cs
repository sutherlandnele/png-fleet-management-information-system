using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class DepotDailyMeasurementRepository : RepositoryBase<DepotDailyMeasurement>, IDepotDailyMeasurementRepository
    {
        internal DepotDailyMeasurementRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
