using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace FMS.Data.Repositories
{
    internal class CenterSecurityRepository : RepositoryBase<CenterSecurity>, ICenterSecurityRepository
    {
        internal CenterSecurityRepository(IDbFactory dbFactory): base(dbFactory) {

        }

        public IEnumerable<CenterSecurity> GetAll(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                return GetAll().Where(x => x.UserId.ToLower() == username.ToLower());
            }
            return GetAll();
        }
    }

}
