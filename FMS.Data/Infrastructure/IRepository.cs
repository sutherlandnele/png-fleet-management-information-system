using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Clear(IEnumerable<T> dbSet);

        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id and object
        T GetById(int id); 
        T FindById(object id);
        Task<T> FindByIdAsync(CancellationToken cancellationToken, object id);
        Task<T> FindByIdAsync(object id);
        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);
        // Gets all entities of type T
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);

        // Gets entities using delegate
        List<T> GetMany(Expression<Func<T, bool>> where);

        // Paging
        List<T> PageAll(int skip, int take);
        Task<List<T>> PageAllAsync(int skip, int take);
        Task<List<T>> PageAllAsync(CancellationToken cancellationToken, int skip, int take);
    }
}
