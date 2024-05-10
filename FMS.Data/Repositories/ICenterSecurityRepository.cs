using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;

namespace FMS.Data.Repositories
{
    public interface ICenterSecurityRepository : IRepository<CenterSecurity>
    {
        IEnumerable<CenterSecurity> GetAll(string username);
    }
}
