using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class DepotRefuelRepository : RepositoryBase<DepotRefuel>, IDepotRefuelRepository
    {
        internal DepotRefuelRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
