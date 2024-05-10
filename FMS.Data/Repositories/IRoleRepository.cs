using FMS.Model;
using System.Threading;
using System.Threading.Tasks;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}
