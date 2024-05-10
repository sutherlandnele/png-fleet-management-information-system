
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FMS.Data.Infrastructure;
using FMS.Model;

namespace FMS.Data.Repositories
{
    internal class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {


        internal RoleRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Role FindByName(string roleName)
        {
            return Set.FirstOrDefault(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}