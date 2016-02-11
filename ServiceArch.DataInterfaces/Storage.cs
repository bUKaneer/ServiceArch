using ServiceArch.DataInterfaces.Interfaces;

namespace ServiceArch.DataInterfaces
{
    public class Storage : IStorage
    {
        private readonly IDataContext _dataContext;

        public IDataContext DataContext { get { return _dataContext; } }

        public Storage(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IDataSet<T> GetRepository<T>() where T : class, IEntity, new()
        {
            return _dataContext.GetRepository<T>();
        }
    }
}
