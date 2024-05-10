using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class AppRoleInterfaceAccessRepository : RepositoryBase<AppRoleInterfaceAccess>, IAppRoleInterfaceAccessRepository
    {
        internal AppRoleInterfaceAccessRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
