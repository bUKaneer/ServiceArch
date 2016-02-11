using System;
using System.Linq;

namespace ServiceArch.DataInterfaces.Interfaces
{
    public interface IDataSet<TEntity> where TEntity : IEntity
    {
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
