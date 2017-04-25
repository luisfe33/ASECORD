using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsecordLogin.Startup))]
namespace AsecordLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
