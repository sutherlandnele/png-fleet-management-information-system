using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class AppMenuRepository : RepositoryBase<AppMenu>, IAppMenuRepository
    {
        internal AppMenuRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
