using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace ServiceArch.Api.AutofacModules
{
    public class WebApi : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
        }
    }
}