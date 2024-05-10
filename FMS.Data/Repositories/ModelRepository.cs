using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class ModelRepository : RepositoryBase<FMS.Model.Model>, IModelRepository
    {
        internal ModelRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
