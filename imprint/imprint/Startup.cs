using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(imprint.Startup))]
namespace imprint
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
