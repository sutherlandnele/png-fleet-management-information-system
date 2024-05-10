using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;
using FMS.Common;
using System.Linq;

namespace FMS.Data.Repositories
{
    internal class SystemParameterRepository : RepositoryBase<SystemParameter>, ISystemParameterRepository
    {
        internal SystemParameterRepository(IDbFactory dbFactory): base(dbFactory) {

        }

        #region Get methods
        public IEnumerable<SystemParameter> GetAllFilterByParameterType(int parameterType)
        {
            var result = GetAll();

            if (parameterType > 0)
            {
                result = result.Where(p => p.ParameterCodeId == parameterType).ToList();
            }

            return result.OrderBy(m=>m.ParameterCodeId);
        }
        #endregion
    }

}
