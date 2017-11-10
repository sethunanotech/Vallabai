using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(source.Startup))]
namespace source
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
           // ConfigureAuth(app);
        }
    }
}
