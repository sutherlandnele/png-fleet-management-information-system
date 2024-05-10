using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class ScheduleServiceRepository : RepositoryBase<ScheduleService>, IScheduleServiceRepository
    {
        internal ScheduleServiceRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
