using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class DashboardRepository : RepositoryBase<Dashboard>, IDashboardRepository
    {
        internal DashboardRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
