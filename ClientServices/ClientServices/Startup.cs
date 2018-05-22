using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientServices.Startup))]
namespace ClientServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
