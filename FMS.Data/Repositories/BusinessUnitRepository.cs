using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class BusinessUnitRepository : RepositoryBase<BusinessUnit>, IBusinessUnitRepository
    {
        internal BusinessUnitRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
