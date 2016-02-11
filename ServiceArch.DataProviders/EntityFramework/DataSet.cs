using ServiceArch.DataInterfaces.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace ServiceArch.DataProviders.EntityFramework
{
    public class DataSet<T> : IDataSet<T> where T : class, IEntity
    {
        private DbContext _dbContext;

        public void Init(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        private bool Exists(T entity)
        {
            return _dbContext.Set<T>().Local.Any(e => e == entity);
        }

        public void Create(T entity)
        {
            if (!Exists(entity)) _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Added;      
        }

        public void Update(T entity)
        {
            if (!Exists(entity)) _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            //if (!Exists(entity)) _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
    }
}
