using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class AppRoleActionAccessRepository : RepositoryBase<AppRoleActionAccess>, IAppRoleActionAccessRepository
    {
        internal AppRoleActionAccessRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
