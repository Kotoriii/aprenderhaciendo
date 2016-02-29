using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LEGO_Test.Startup))]
namespace LEGO_Test
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
