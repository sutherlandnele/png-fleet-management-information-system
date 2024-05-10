using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class AppInterfaceRepository : RepositoryBase<AppInterface>, IAppInterfaceRepository
    {
        internal AppInterfaceRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
