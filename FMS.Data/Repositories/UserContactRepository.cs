using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class UserContactRepository : RepositoryBase<UserContact>, IUserContactRepository
    {
        internal UserContactRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
