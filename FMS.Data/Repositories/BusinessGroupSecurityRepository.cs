using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class BusinessGroupSecurityRepository : RepositoryBase<BusinessGroupSecurity>, IBusinessGroupSecurityRepository
    {
        internal BusinessGroupSecurityRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
