using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ServiceArch.Api.Startup))]

namespace ServiceArch.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
