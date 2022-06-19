using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyProfileApp.Startup))]
namespace MyProfileApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
