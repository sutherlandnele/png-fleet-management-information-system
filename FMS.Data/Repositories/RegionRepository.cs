using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace FMS.Data.Repositories
{
    internal class RegionRepository : RepositoryBase<Regional>, IRegionRepository
    {
        internal RegionRepository(IDbFactory dbFactory): base(dbFactory) {

        }

    }

}
