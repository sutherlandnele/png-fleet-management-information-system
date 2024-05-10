using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class VehicleTransferRepository : RepositoryBase<VehicleTransfer>, IVehicleTransferRepository
    {
        internal VehicleTransferRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
