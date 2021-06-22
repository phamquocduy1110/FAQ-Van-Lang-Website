using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CNTTFAQ.Startup))]
namespace CNTTFAQ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
