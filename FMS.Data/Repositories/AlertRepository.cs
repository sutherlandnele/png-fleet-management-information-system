using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class AlertRepository : RepositoryBase<Alert>, IAlertRepository
    {
        internal AlertRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
