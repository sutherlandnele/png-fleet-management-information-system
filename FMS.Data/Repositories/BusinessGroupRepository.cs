using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace FMS.Data.Repositories
{
    internal class BusinessGroupRepository : RepositoryBase<BusinessGroup>, IBusinessGroupRepository
    {
        internal BusinessGroupRepository(IDbFactory dbFactory): base(dbFactory) {

        }
        public IEnumerable<BusinessGroup> GetAll(string name, int manager, int businessUnit)
        {
            IEnumerable<BusinessGroup> result = GetAll();
            if (manager != -1)
            {
                result = result.Where(x => x.ContactDetail != null && x.ContactDetail.Id == manager);
            }

            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(x => x.GroupName != null && x.GroupName.ToLower().Contains(name.ToLower()) || x.BusinessUnit != null && x.GroupName.ToLower().Contains(name.ToLower()));
            }
            if (businessUnit != -1)
            {
                result = result.Where(x => x.BusinessUnit != null && x.BusinessUnitId == businessUnit);
            }
            return result.OrderByDescending(m=>m.GroupNumber);
        }
    }

}
