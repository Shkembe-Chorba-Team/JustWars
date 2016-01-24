using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JustWars.Web.Startup))]
namespace JustWars.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
