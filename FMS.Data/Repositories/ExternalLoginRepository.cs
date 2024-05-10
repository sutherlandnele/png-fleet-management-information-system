
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FMS.Data.Infrastructure;
using FMS.Model;

namespace FMS.Data.Repositories
{
    internal class ExternalLoginRepository : RepositoryBase<ExternalLogin>, IExternalLoginRepository
    {

        internal ExternalLoginRepository(IDbFactory dbFactory): base(dbFactory) { }

        public ExternalLogin GetByProviderAndKey(string loginProvider, string providerKey)
        {
            return  Set.FirstOrDefault(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            return Set.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<ExternalLogin> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey)
        {
            return Set.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey, cancellationToken);
        }
    }
}