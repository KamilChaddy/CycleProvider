using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CycleProvider.MVC.Startup))]
namespace CycleProvider.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
