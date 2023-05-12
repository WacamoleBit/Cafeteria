using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cafe.Web.Startup))]
namespace Cafe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
