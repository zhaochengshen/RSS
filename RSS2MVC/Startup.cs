using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RSS2MVC.Startup))]
namespace RSS2MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
