using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetworkingHelper.Startup))]
namespace NetworkingHelper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
