using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.UX.ASPNetApp.Startup))]
namespace Web.UX.ASPNetApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
