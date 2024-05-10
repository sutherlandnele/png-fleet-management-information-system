using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class AppActionRepository : RepositoryBase<AppAction>, IAppActionRepository
    {
        internal AppActionRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
