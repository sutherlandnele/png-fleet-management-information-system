using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private FMSEntities _appDbContext;
        private DbSet<T> _dbSet;
        
        protected DbSet<T> Set
        {
            get { return _dbSet ?? (_dbSet = AppDbContext.Set<T>()); }
        }

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        public FMSEntities AppDbContext
        {
            get { return _appDbContext ?? (_appDbContext = DbFactory.Init()); }
        }
        #endregion
        #region Constructors

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = AppDbContext.Set<T>();
        }

        #endregion
        #region Implementation
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }       

        public virtual void Update(T entity)
        {

            var entry = _appDbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {

                CheckAndAttach(entity);
                entry = _appDbContext.Entry(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
           
            var entry = _appDbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                CheckAndAttach(entity);
            }

            _dbSet.Remove(entity);

        }

        public virtual void Clear(IEnumerable<T> dbSet)
        {
            _dbSet.RemoveRange(dbSet);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();

            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual List<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _dbSet.ToListAsync(cancellationToken);
        }

        public List<T> PageAll(int skip, int take)
        {
            return _dbSet.Skip(skip).Take(take).ToList();
        }

        public Task<List<T>> PageAllAsync(int skip, int take)
        {
            return _dbSet.Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<T>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            return _dbSet.Skip(skip).Take(take).ToListAsync(cancellationToken);
        }

        public T FindById(object id)
        {
            return _dbSet.Find(id);
        }

        public Task<T> FindByIdAsync(object id)
        {
            return _dbSet.FindAsync(id);
        }

        public Task<T> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            return _dbSet.FindAsync(cancellationToken, id);
        }

        #endregion
        #region Private Methods
        private object GetKeyValue(T entity)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)_appDbContext).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            string keyName = (set.EntitySet.ElementType
                                .KeyMembers
                                .Select(k => k.Name)).FirstOrDefault();

            Type type = entity.GetType();
            PropertyInfo key = type.GetProperty(keyName);

            return key.GetValue(entity);
        }
        private void CheckAndAttach(T entity)
        {
            //check and detach the entity if it is already attached
            var local = _appDbContext.Set<T>()
                        .Local
                        .FirstOrDefault(e => GetKeyValue(e).ToString() == GetKeyValue(entity).ToString());

            if (local != null)
            {
                _appDbContext.Entry(local).State = EntityState.Detached;
            }

            _dbSet.Attach(entity);
        }
        #endregion
    }
}
