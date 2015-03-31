using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sgdevtest.Startup))]
namespace sgdevtest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
