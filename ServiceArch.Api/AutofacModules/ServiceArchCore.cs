using Autofac;
using FluentValidation;
using ServiceArch.Api.FluentValidation;
using ServiceArch.DataInterfaces;
using ServiceArch.DataInterfaces.Interfaces;
using ServiceArch.DataProviders.MongoDb; //TODO: Choose a data store: MongoDb || EntityFramework
using System.Reflection;

namespace ServiceArch.Api.AutofacModules
{
    public class ServiceArchCore : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>()
                    .As<IDataContext>().InstancePerLifetimeScope();

            builder.RegisterType<Storage>()
                    .As<IStorage>().InstancePerLifetimeScope();

            builder.RegisterType<AutofacValidationFactory>()
                    .As<IValidatorFactory>()
                    .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(DataSet<>))
                                       .As(typeof(IDataSet<>))
                                       .InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(Assembly.Load("ServiceArch.DataInterfaces"))
                   .Where(t => t.Name.EndsWith("Validator")
                            || t.Name.Equals("Service"))
                   .AsImplementedInterfaces();
        }
    }
}