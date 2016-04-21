using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_DEMO.Startup))]
namespace MVC_DEMO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
