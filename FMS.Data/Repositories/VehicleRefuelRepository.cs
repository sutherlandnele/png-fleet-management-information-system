using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class VehicleRefuelRepository : RepositoryBase<VehicleRefuel>, IVehicleRefuelRepository
    {
        internal VehicleRefuelRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
