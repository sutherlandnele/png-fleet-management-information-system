using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;

namespace FMS.Data.Repositories
{
    public interface IBusinessGroupRepository : IRepository<BusinessGroup>
    {
        IEnumerable<BusinessGroup> GetAll(string name, int manager, int businessUnit);
    }
}
