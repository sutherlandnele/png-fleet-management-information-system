using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class VehicleAllocationRepository : RepositoryBase<VehicleAllocation>, IVehicleAllocationRepository
    {
        internal VehicleAllocationRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
