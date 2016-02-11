using System;

namespace ServiceArch.DataInterfaces.Interfaces
{
    public interface IDataContext : IDisposable
    {
        IDataSet<T> GetRepository<T>() where T: class, IEntity;
        int SaveChanges();
    }
}
