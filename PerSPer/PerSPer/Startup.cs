using Microsoft.Owin;
using Owin;
using XSockets.Owin.Host;

[assembly: OwinStartupAttribute(typeof(InterVision.Startup))]
namespace InterVision
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseXSockets();
        }
    }
}
