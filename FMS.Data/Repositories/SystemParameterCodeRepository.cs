using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;
using FMS.Common;
using System.Linq;

namespace FMS.Data.Repositories
{
    internal class SystemParameterCodeRepository : RepositoryBase<SystemParameterCode>, ISystemParameterCodeRepository
    {
        internal SystemParameterCodeRepository(IDbFactory dbFactory): base(dbFactory) {

        }

    }

}
