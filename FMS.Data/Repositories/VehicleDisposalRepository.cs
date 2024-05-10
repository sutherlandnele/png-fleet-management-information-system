using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class VehicleDisposalRepository : RepositoryBase<VehicleDisposal>, IVehicleDisposalRepository
    {
        internal VehicleDisposalRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
