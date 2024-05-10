using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class IncidentRepository : RepositoryBase<Incident>, IIncidentRepository
    {
        internal IncidentRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
