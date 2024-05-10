using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FMS.Data.Infrastructure;
using FMS.Model;

namespace FMS.Data.Repositories
{
    internal class UserRepository : RepositoryBase<User>, IUserRepository
    {
        internal UserRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public User FindByUserName(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }

    }
}