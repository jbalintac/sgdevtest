using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using sgdal;

[assembly: OwinStartupAttribute(typeof(sgdevtest.Startup))]
namespace sgdevtest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        protected void Application_Start()
        {
            new SgInitializer().InitializeDatabase(new SgContext());
        }
    }
}
