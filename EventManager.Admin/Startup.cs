using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventManager.Admin.Startup))]
namespace EventManager.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
