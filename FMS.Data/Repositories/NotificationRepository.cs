using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        internal NotificationRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
