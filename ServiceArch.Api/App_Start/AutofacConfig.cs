using Autofac;
using Autofac.Integration.WebApi;
using ServiceArch.Api.AutofacModules;
using System.Web.Http;

namespace ServiceArch.Api
{
    public class AutofacConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration.DependencyResolver = 
                new AutofacWebApiDependencyResolver(RegisterModules());
        }

        private static IContainer RegisterModules()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<WebApi>();
            builder.RegisterModule<ServiceArchCore>();
            return builder.Build();
        }
    }
}

