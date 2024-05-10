using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        internal ServiceRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
