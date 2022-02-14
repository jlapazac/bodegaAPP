using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bodegaAPP.Startup))]
namespace bodegaAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
