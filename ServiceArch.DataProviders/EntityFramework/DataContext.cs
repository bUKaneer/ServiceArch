using ServiceArch.DataInterfaces.Interfaces;
using ServiceArch.DataInterfaces.TaskListService.Entities;
using System.Data.Entity;

namespace ServiceArch.DataProviders.EntityFramework
{
    public sealed class DataContext : DbContext, IDataContext
    {
        public DataContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
            Database.Connection.ConnectionString = Properties.Settings.Default.sqlServerConnectionString;
        }

        IDataSet<T> IDataContext.GetRepository<T>()
        {
            var t = new DataSet<T>();
            t.Init(this);
            return t;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskList>()
                        .HasMany(x => x.Tasks) 
                        .WithRequired(y => y.TaskList)     
                        .Map(m => m.MapKey("TaskListId"));
        }

        DbSet<TaskList> TaskLists { get; set; }
    }
}
