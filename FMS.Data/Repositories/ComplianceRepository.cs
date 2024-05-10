using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class ComplianceRepository : RepositoryBase<Compliance>, IComplianceRepository
    {
        internal ComplianceRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
