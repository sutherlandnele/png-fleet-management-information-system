using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class OperatorRepository : RepositoryBase<Operator>, IOperatorRepository
    {
        internal OperatorRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
