using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DressZone.Server.Startup))]
namespace DressZone.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
