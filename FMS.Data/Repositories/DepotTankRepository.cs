using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class DepotTankRepository : RepositoryBase<DepotTank>, IDepotTankRepository
    {
        internal DepotTankRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
