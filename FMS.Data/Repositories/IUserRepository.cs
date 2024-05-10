using FMS.Model;
using System.Threading;
using System.Threading.Tasks;
using FMS.Data.Infrastructure;
using System.Collections.Generic;

namespace FMS.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUserName(string username);
        Task<User> FindByUserNameAsync(string username);
        Task<User> FindByUserNameAsync(CancellationToken cancellationToken, string username);



    }
}
