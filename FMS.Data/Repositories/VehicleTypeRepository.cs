using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class VehicleTypeRepository : RepositoryBase<VehicleType>, IVehicleTypeRepository
    {
        internal VehicleTypeRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
