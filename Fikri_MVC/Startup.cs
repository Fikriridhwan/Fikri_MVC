using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fikri_MVC.Startup))]
namespace Fikri_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
