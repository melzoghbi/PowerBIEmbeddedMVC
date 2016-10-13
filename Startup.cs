using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PBIEWebApp.Startup))]
namespace PBIEWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
