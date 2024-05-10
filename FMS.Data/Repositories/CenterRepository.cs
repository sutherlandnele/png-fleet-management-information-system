using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace FMS.Data.Repositories
{
    internal class CenterRepository : RepositoryBase<Center>, ICenterRepository
    {
        #region Constructors
        internal CenterRepository(IDbFactory dbFactory): base(dbFactory) {

        }
        #endregion

        #region Get Methods

        #endregion
    }

}
