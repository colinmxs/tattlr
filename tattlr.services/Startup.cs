using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(tattlr.services.Startup))]

namespace tattlr.services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
