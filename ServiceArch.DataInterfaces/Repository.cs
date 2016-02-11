using ServiceArch.DataInterfaces.Interfaces;
using System;
using System.Linq;

namespace ServiceArch.DataInterfaces
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        readonly IDataSet<TEntity> _dataProvider;

        public Repository(IDataContext dataContext)
        {
            _dataProvider = dataContext.GetRepository<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return _dataProvider.GetById(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dataProvider.GetAll();
        }

        public void Create(TEntity entity)
        {
            _dataProvider.Create(entity);
        }

        public void Update(TEntity entity)
        {
            _dataProvider.Update(entity);
        }

        public void Delete(Guid id)
        {
            _dataProvider.Delete(id);
        }
    }
}
