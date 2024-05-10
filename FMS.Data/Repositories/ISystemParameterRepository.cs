using FMS.Model;
using FMS.Data.Infrastructure;
using System.Collections.Generic;

namespace FMS.Data.Repositories
{
    public interface ISystemParameterRepository : IRepository<SystemParameter>
    {
        #region Get Methods
        IEnumerable<SystemParameter> GetAllFilterByParameterType(int parameterType);
        #endregion
    }
}
