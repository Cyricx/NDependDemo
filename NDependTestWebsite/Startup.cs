using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NDependTestWebsite.Startup))]
namespace NDependTestWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
