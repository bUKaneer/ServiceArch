using MongoDB.Driver;
using ServiceArch.DataInterfaces.Interfaces;
using System;

namespace ServiceArch.DataProviders.MongoDb
{
    public sealed class DataContext : IDataContext
    {
        private readonly MongoClient _client;

        public DataContext()
        {
            _client = new MongoClient(Properties.Settings.Default.mongoDbConnectionString);
        }

        public void Dispose()
        { }

        public int SaveChanges()
        { return 0; }

        IDataSet<T> IDataContext.GetRepository<T>()
        {
            var t = new DataSet<T>();
            t.Init(_client.GetDatabase(Properties.Settings.Default.mongoDbDatabaseName));
            return t;
        }
    }
}
