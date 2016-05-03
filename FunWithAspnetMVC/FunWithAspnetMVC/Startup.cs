using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FunWithAspnetMVC.Startup))]
namespace FunWithAspnetMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
