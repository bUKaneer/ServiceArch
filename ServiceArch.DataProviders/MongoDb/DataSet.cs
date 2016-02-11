using MongoDB.Driver;
using ServiceArch.DataInterfaces.Interfaces;
using System;
using System.Linq;

namespace ServiceArch.DataProviders.MongoDb
{
    public class DataSet<T> : IDataSet<T> where T : class, IEntity
    {
        private IMongoDatabase _mongoDb;

        public void Init(IMongoDatabase mongoDb)
        {
            _mongoDb = mongoDb;
        }

        public T GetById(Guid id)
        {
            return (T)GetCollection().Find(GetFilterForId(id));
        }

        private static FilterDefinition<T> GetFilterForId(Guid id)
        {
            return Builders<T>.Filter.Eq("_id", id);
        }

        public IQueryable<T> GetAll()
        {
            return GetCollection().AsQueryable();
        }

        public void Create(T entity)
        {
            GetCollection().InsertOne(entity);
        }

        public void Update(T entity)
        {
            GetCollection().ReplaceOne(GetFilterForId(entity.Id),entity);
        }

        public void Delete(Guid id)
        {
            GetCollection().DeleteOne(GetFilterForId(id));
        }

        private IMongoCollection<T> GetCollection()
        {
            return _mongoDb.GetCollection<T>(typeof(T).ToString());
        }
    }
}
