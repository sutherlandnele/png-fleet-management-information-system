using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using FMS.Model;
using FMS.Data.Infrastructure;
using AutoMapper;
using Entities = FMS.Model;

namespace FMS.Web.Identity
{
    public class RoleStore : IRoleStore<IdentityRole, Guid>
        , IQueryableRoleStore<IdentityRole, Guid>
        , IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region IRoleStore<IdentityRole, Guid> Members
        public System.Threading.Tasks.Task CreateAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            
            var roleEntity = Mapper.Map<IdentityRole, Entities.Role>(role);

            _unitOfWork.RoleRepository.Add(roleEntity);
            return _unitOfWork.CommitAsync();
        }

        public System.Threading.Tasks.Task DeleteAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

           
            var roleEntity = Mapper.Map<IdentityRole, Entities.Role>(role);

            _unitOfWork.RoleRepository.Delete(roleEntity);
            return _unitOfWork.CommitAsync();
        }

        public System.Threading.Tasks.Task<IdentityRole> FindByIdAsync(Guid roleId)
        {
            var role = _unitOfWork.RoleRepository.FindById(roleId);

            var identityRole = Mapper.Map<Entities.Role, IdentityRole>(role);

            return Task.FromResult<IdentityRole>(identityRole);
        }

        public System.Threading.Tasks.Task<IdentityRole> FindByNameAsync(string roleName)
        {
            var role = _unitOfWork.RoleRepository.FindByName(roleName);

            var identityRole = Mapper.Map<Entities.Role, IdentityRole>(role);

            return Task.FromResult<IdentityRole>(identityRole);
        }

        public System.Threading.Tasks.Task UpdateAsync(IdentityRole role)
        {
            if (role == null)
                throw new ArgumentNullException("role");
           
            var roleEntity = Mapper.Map<IdentityRole, Entities.Role>(role);
            _unitOfWork.RoleRepository.Update(roleEntity);
            return _unitOfWork.CommitAsync();
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            // Dispose does nothing since we want Unity to manage the lifecycle of our Unit of Work
        }
        #endregion

        #region IQueryableRoleStore<IdentityRole, Guid> Members
        public IQueryable<IdentityRole> Roles
        {
            get
            {              

                return _unitOfWork.RoleRepository
                    .GetAll()
                    .Select(x => Mapper.Map<Entities.Role, IdentityRole>(x))
                    .AsQueryable();
            }
        }
        #endregion

        #region Private Methods
     
        #endregion
    }
}