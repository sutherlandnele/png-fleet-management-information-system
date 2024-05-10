using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class FuelVoucherRepository : RepositoryBase<FuelVoucher>, IFuelVoucherRepository
    {
        internal FuelVoucherRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
