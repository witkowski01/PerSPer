using Microsoft.Owin;
using Owin;
using XSockets.Owin.Host;

[assembly: OwinStartupAttribute(typeof(PerSPer.Startup))]
namespace PerSPer
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
