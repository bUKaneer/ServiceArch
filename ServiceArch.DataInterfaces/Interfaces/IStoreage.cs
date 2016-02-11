namespace ServiceArch.DataInterfaces.Interfaces
{
    public interface IStorage
    {
        IDataSet<T> GetRepository<T>() where T : class, IEntity, new();
        IDataContext DataContext { get; }
    }
}
