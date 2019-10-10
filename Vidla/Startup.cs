using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidla.Startup))]
namespace Vidla
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
