using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace FMS.Data.Repositories
{
    internal class ClientInformationRepository : RepositoryBase<ClientInformation>, IClientInformationRepository
    {
        #region Constructors
        internal ClientInformationRepository(IDbFactory dbFactory): base(dbFactory) {

        }
        #endregion

        #region Get Methods

        #endregion
    }

}
