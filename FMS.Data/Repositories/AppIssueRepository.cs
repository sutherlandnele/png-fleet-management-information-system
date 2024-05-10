using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class AppIssueRepository : RepositoryBase<AppIssue>, IAppIssueRepository
    {
        internal AppIssueRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
